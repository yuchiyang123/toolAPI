using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Common.Helper.Key;
using blog.Dtos;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace blog.Services.Redis
{
    public class BlogCacheService(
        IDistributedCache cache,
        IConnectionMultiplexer connectionMultiplexer,
        CacheHelper cacheHelper,
        PostRepository repository,
        OllamaHelper ollamaHelper
    )
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

        #region PostDetail Cache
        public async Task<PostDetailDto?> GetPostDetailAsync(int id, CancellationToken ct = default)
        {
            var key = CacheKeys.Post(id);
            var cached = await cache.GetStringAsync(key, ct);

            if (cached is not null)
            {
                if (cached.IsCachedNull())
                    return null;
                var dto = JsonSerializer.Deserialize<PostDetailDto>(cached);
                if (dto is null)
                    return null;
                var view = await GetViewCountAsync(id);
                dto.View = view.ToString();
                return dto;
            }

            return await cacheHelper.SaveCacheAsync<PostDetailDto>(
                key,
                () => repository.GetPostDetail(),
                x => x.Id == id,
                ct
            );
        }

        public async Task InvalidatePostAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.Post(id));
        }
        #endregion

        #region PostList
        public async Task InvalidatePostListAsync()
        {
            await cache.BumpListVersionAsync(PageEnums.PostList);
        }
        #endregion

        #region Post Summary
        /// <summary>搶 lock 最多重試次數（50ms × 20 = 1 秒），超過就直接產生摘要、不寫快取</summary>
        private const int MaxLockAttempts = 20;

        public async Task<string?> GetPostSummaryAsync(
            int id,
            CancellationToken ct = default,
            int attempt = 0
        )
        {
            var key = CacheKeys.PostSummary(id);
            var cached = await cache.GetStringAsync(key, ct);

            if (cached is not null)
            {
                if (cached.IsCachedNull())
                    return null;
                return cached;
            }

            var lockKey = CacheKeys.LockKey(key);
            if (attempt >= MaxLockAttempts)
                return await GenerateSummaryAsync(id, ct);

            if (await cacheHelper.AcquireLock(lockKey, TimeSpan.FromMinutes(10)))
            {
                try
                {
                    var content = await repository
                        .GetPostNoIncludeAny()
                        .Where(x => x.Id == id)
                        .Select(x => x.Content)
                        .FirstOrDefaultAsync(ct);

                    if (content is null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    var dto = ollamaHelper.GetAiDtoRequest(content);
                    var aiResponse = await ollamaHelper.GetOllamaResponse(dto);

                    if (aiResponse is not null)
                    {
                        await cache.SaveRedisForStringAsync(key, aiResponse, ct);
                    }
                    else
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    return aiResponse;
                }
                finally
                {
                    await cacheHelper.ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(50, ct);
                return await GetPostSummaryAsync(id, ct, attempt + 1);
            }
        }

        /// <summary>不經快取、不搶 lock 直接產生摘要（lock 重試耗盡時的 fallback）</summary>
        private async Task<string?> GenerateSummaryAsync(int id, CancellationToken ct)
        {
            var content = await repository
                .GetPostNoIncludeAny()
                .Where(x => x.Id == id)
                .Select(x => x.Content)
                .FirstOrDefaultAsync(ct);
            if (content is null)
                return null;
            return await ollamaHelper.GetOllamaResponse(ollamaHelper.GetAiDtoRequest(content));
        }

        public async Task InvalidatePostSummaryAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.PostSummary(id));
        }
        #endregion

        #region Post Views
        /// <summary>
        /// 瀏覽數 +1（Redis INCR）。Redis 沒有這把 key 時先從 DB 帶入現值再加。
        /// 回傳加完後的值；DB 回寫由呼叫端決定（建議定時批次）。
        /// </summary>
        public async Task<long> IncrementViewAsync(int id)
        {
            var key = CacheKeys.PostViews(id);
            if (!await _database.KeyExistsAsync(key))
            {
                var dbView = await GetViewCountFromDbAsync(id);
                // NX：若同時有另一個請求已經初始化，這裡不會覆蓋
                await _database.StringSetAsync(key, dbView, when: When.NotExists);
            }
            return await _database.StringIncrementAsync(key);
        }

        /// <summary>
        /// 讀瀏覽數：Redis 優先，沒有才回 DB（並順手寫進 Redis）。
        /// </summary>
        public async Task<long> GetViewCountAsync(int id)
        {
            var key = CacheKeys.PostViews(id);
            var cached = await _database.StringGetAsync(key);
            if (cached.HasValue && cached.TryParse(out long v))
                return v;
            var dbView = await GetViewCountFromDbAsync(id);
            await _database.StringSetAsync(key, dbView, when: When.NotExists);
            return dbView;
        }

        private async Task<int> GetViewCountFromDbAsync(int id)
        {
            return await repository
                .GetPostNoIncludeAny()
                .Where(x => x.Id == id)
                .Select(x => x.View)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 批次讀取多篇文章目前的瀏覽數（一次 Redis MGET，不是逐篇查）。
        /// 給文章列表用：列表本身整頁快取（見 PageHelper.ToPageResponseDtoWithCache），
        /// 瀏覽數是唯一「看一次就變」的欄位，不能跟著整頁一起快取到 TTL 到期才更新，
        /// 所以列表快取命中後還是要在這裡把每篇的 View 蓋成即時值 ——
        /// 跟 GetPostDetailAsync 對單篇做的事一樣，只是這裡一次做完一整頁。
        /// </summary>
        public async Task<Dictionary<int, long>> GetViewCountsAsync(IEnumerable<int> ids)
        {
            var idList = ids.Distinct().ToList();
            if (idList.Count == 0)
                return [];

            var keys = idList.Select(id => (RedisKey)CacheKeys.PostViews(id)).ToArray();
            var values = await _database.StringGetAsync(keys);

            var result = new Dictionary<int, long>();
            var missingIds = new List<int>();
            for (var i = 0; i < idList.Count; i++)
            {
                if (values[i].HasValue && values[i].TryParse(out long v))
                    result[idList[i]] = v;
                else
                    missingIds.Add(idList[i]);
            }

            if (missingIds.Count > 0)
            {
                var dbViews = await repository
                    .GetPostNoIncludeAny()
                    .Where(x => missingIds.Contains(x.Id))
                    .Select(x => new { x.Id, x.View })
                    .ToListAsync();
                foreach (var item in dbViews)
                {
                    result[item.Id] = item.View;
                    // NX：跟單篇的 GetViewCountAsync 一致，避免蓋掉同時間別的請求剛寫入的值
                    await _database.StringSetAsync(
                        CacheKeys.PostViews(item.Id),
                        item.View,
                        when: When.NotExists
                    );
                }
            }

            return result;
        }
        #endregion
    }
}

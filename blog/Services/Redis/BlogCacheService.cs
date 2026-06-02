using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services.Redis
{
    public class BlogCacheService(IDistributedCache cache, IMapper mapper, CacheHelper cacheHelper, PostRepository repository, OllamaHelper ollamaHelper)
    {
        #region PostDetail Cache
        public async Task<PostDetailDto?> GetPostDetailAsync(int id, CancellationToken ct = default)
        {
            var key = CacheKeys.Post(id);
            var cached = await cache.GetStringAsync(key, ct);

            if (cached is not null)
            {
                if (cached == "null") return null;
                var dto = JsonSerializer.Deserialize<PostDetailDto>(cached);
                if (dto is null) return null;
                var view = await GetViewCountFromDbAsync(id);
                dto.View = view.ToString();
                return dto;
            }

            var lockKey = CacheKeys.LockKey(key);
            if (await cacheHelper.AcquireLock(lockKey, TimeSpan.FromMinutes(10)))
            {
                try
                {
                    var postDetail = await repository.GetPostDetail().ProjectTo<PostDetailDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id, ct);
                    if (postDetail is null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    var entity = JsonSerializer.Serialize(postDetail);
                    await cache.SetStringAsync(key, entity, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30 + Random.Shared.Next(0, 10))
                    }, ct);

                    return postDetail;
                }
                finally
                {
                    await cacheHelper.ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(50, ct);
                return await GetPostDetailAsync(id, ct);
            }
        }

        public async Task InvalidatePostAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.Post(id));
        }
        #endregion

        #region Post Summary
        public async Task<string?> GetPostSummaryAsync(int id, CancellationToken ct = default)
        {
            var key = CacheKeys.PostSummary(id);
            var cached = await cache.GetStringAsync(key, ct);

            if (cached is not null)
            {
                if (cached == "null") return null;
                return cached;
            }

            var lockKey = CacheKeys.LockKey(key);
            if (await cacheHelper.AcquireLock(lockKey, TimeSpan.FromMinutes(10)))
            {
                try
                {
                    var content = await repository.GetPostNoIncludeAny().Where(x => x.Id == id).Select(x => x.Content).FirstOrDefaultAsync(ct);

                    if (content is null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    var dto = ollamaHelper.GetAiDtoRequest(content);
                    var aiResponse = await ollamaHelper.GetOllamaResponse(dto);

                    if (aiResponse is not null)
                    {
                        await cache.SetStringAsync(key, aiResponse, new DistributedCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30 + Random.Shared.Next(0, 10))
                        }, ct);
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
                return await GetPostSummaryAsync(id, ct);
            }
        }

        public async Task InvalidataPostSummaryAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.PostSummary(id));
        }
        #endregion

        /// <summary>
        /// TODO: 改用 Redis INCR 累加，定時批次回寫 DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<int> GetViewCountFromDbAsync(int id)
        {
            return await repository.GetPostNoIncludeAny().Where(x => x.Id == id).Select(x => x.View).FirstOrDefaultAsync();
        }
    }
}



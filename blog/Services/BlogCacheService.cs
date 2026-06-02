using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace blog.Services
{
    public class BlogCacheService(IDistributedCache cache, IConnectionMultiplexer multiplexer, PostRepository repository, IMapper mapper)
    {
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
            if (await AcquireLock(lockKey, TimeSpan.FromMinutes(10)))
            {
                try
                {
                    var postDetail = await repository.GetPostDetail().ProjectTo<PostDetailDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id, ct);
                    if (postDetail is null)
                    {
                        await cache.SetStringAsync(key, "null", new DistributedCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                        }, ct);
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
                    await ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(50, ct);
                return await GetPostDetailAsync(id, ct);
            }
        }

        public async Task<bool> AcquireLock(string lockKey, TimeSpan expiry)
        {
            var db = multiplexer.GetDatabase();
            return await db.StringSetAsync(lockKey, "1", expiry, When.NotExists);
        }

        public async Task<bool> ReleaseLock(string lockKey)
        {
            var db = multiplexer.GetDatabase();
            return await db.KeyDeleteAsync(lockKey);
        }

        public async Task InvalidatePostAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.Post(id));
        }

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

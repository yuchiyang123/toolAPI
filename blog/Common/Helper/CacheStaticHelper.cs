using Microsoft.Extensions.Caching.Distributed;

namespace blog.Common.Helper
{
    public static class CacheStaticHelper
    {
        public static async Task SaveRedisForNullAsync(this IDistributedCache cache, string key, CancellationToken ct, TimeSpan? time = null)
        {
            await cache.SetStringAsync(key, "null", new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = time ?? TimeSpan.FromMinutes(5)
            }, ct);
        }
    }
}

using Microsoft.Extensions.Caching.Distributed;

namespace blog.Common.Helper
{
    public static class CacheHelper
    {
        public static async Task SaveRedisForNull(this IDistributedCache cache, string key, CancellationToken ct, TimeSpan? time = null)
        {
            await cache.SetStringAsync(key, "null", new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = time ?? TimeSpan.FromMinutes(5)
            }, ct);
        }
    }
}

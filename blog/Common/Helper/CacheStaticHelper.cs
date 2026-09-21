using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Common.Helper
{
    public static class CacheStaticHelper
    {
        public static async Task SaveRedisForNullAsync(
            this IDistributedCache cache,
            string key,
            CancellationToken ct,
            TimeSpan? time = null
        )
        {
            await cache.SetStringAsync(
                key,
                "null",
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = time ?? TimeSpan.FromMinutes(5),
                },
                ct
            );
        }

        public static async Task SaveRedisForObjectAsync<T>(
            this IDistributedCache cache,
            string key,
            T saveData,
            CancellationToken ct
        )
            where T : class
        {
            var saveDataString = JsonSerializer.Serialize<T>(saveData);

            await cache.SaveRedisForStringAsync(key, saveDataString, ct);
        }

        public static async Task SaveRedisForStringAsync(
            this IDistributedCache cache,
            string key,
            string saveData,
            CancellationToken ct,
            TimeSpan? time = null
        )
        {
            await cache.SetStringAsync(
                key,
                saveData,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        time ?? TimeSpan.FromMinutes(30 + Random.Shared.Next(0, 10)),
                },
                ct
            );
        }

        public static bool IsCachedNull(this string? cached) => cached == "null";
    }
}

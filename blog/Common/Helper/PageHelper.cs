using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using blog.Common.Enum;
using blog.Common.Helper.Key;
using blog.Dtos.Page;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace blog.Common.Helper
{
    public static class PageHelper
    {
        public static async Task<PageResponseDto<T>> ToPageResponseDto<T>(
            this IQueryable<T> query,
            int pageIndex,
            int pageSize
        )
        {
            var total = await query.CountAsync();
            var item = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return GetPageResponseDto(item, pageIndex, pageSize, total);
        }

        /// <summary>
        /// 給已經分頁的Dto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageResponseDto<T> ToPageResponseDto<T>(
            this List<T> dto,
            int pageIndex,
            int pageSize
        )
        {
            var total = dto.Count;

            return GetPageResponseDto(dto, pageIndex, pageSize, total);
        }

        public static PageResponseDto<T> GetPageResponseDto<T>(
            List<T> dto,
            int pageIndex,
            int pageSize,
            int total
        )
        {
            return new PageResponseDto<T>
            {
                PageIndex = pageIndex,
                PageTotal = (int)Math.Ceiling(total / (double)pageSize),
                PageSize = pageSize,
                TotalSize = total,
                HasNextPage = total > pageIndex * pageSize,
                Items = dto,
            };
        }

        /// <summary>
        /// 讀取列表快取版本號（不存在視為 0）。
        /// 列表失效 = <see cref="BumpListVersionAsync"/>，舊版本 key 由 TTL 自然過期，不再 SCAN keyspace。
        /// </summary>
        public static async Task<long> GetListVersionAsync(
            this IDistributedCache cache,
            PageEnums service,
            CancellationToken ct = default
        )
        {
            var raw = await cache.GetStringAsync(CacheKeys.ListVersion(service), ct);
            return long.TryParse(raw, out var v) ? v : 0;
        }

        /// <summary>
        /// 列表快取失效：版本號 +1（原子 INCR）。
        /// </summary>
        public static async Task BumpListVersionAsync(
            this IConnectionMultiplexer multiplexer,
            PageEnums service,
            string instanceName = "Blog"
        )
        {
            // IDistributedCache 會在 key 前面加 InstanceName，這裡直接用 IDatabase 操作同一把 key
            var db = multiplexer.GetDatabase();
            await db.StringIncrementAsync(instanceName + CacheKeys.ListVersion(service));
        }

        public static async Task<PageResponseDto<T>> ToPageResponseDtoWithCache<T>(
            this IQueryable<T> query,
            int pageIndex,
            int pageSize,
            PageEnums service,
            string filterSHA,
            IDistributedCache cache,
            TimeSpan? ttl = null,
            CancellationToken ct = default
        )
        {
            var version = await cache.GetListVersionAsync(service, ct);
            var fullKey = CacheKeys.PageList(service, version, pageIndex, pageSize, filterSHA);
            var cached = await cache.GetStringAsync(fullKey, ct);
            if (cached is not null)
            {
                var hit = JsonSerializer.Deserialize<PageResponseDto<T>>(cached);
                if (hit is not null)
                    return hit;
            }

            var total = await query.CountAsync(ct);
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(ct);
            var result = GetPageResponseDto(items, pageIndex, pageSize, total);

            await cache.SetStringAsync(
                fullKey,
                JsonSerializer.Serialize(result),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        ttl ?? TimeSpan.FromMinutes(30 + Random.Shared.Next(0, 10)),
                },
                ct
            );

            return result;
        }

        public static string ComputeFilterHash<T>(T filter)
            where T : class
        {
            var sorted = typeof(T)
                .GetProperties()
                .OrderBy(p => p.Name)
                .Select(p => $"{p.Name}={p.GetValue(filter) ?? "null"}")
                .ToArray();

            var raw = string.Join("&", sorted);
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(raw));
            return Convert.ToHexString(bytes)[..12].ToLower();
        }
    }
}

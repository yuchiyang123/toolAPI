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
        /// <remarks>
        /// 一定要跟 <see cref="BumpListVersionAsync"/> 走同一條路（IDistributedCache）。
        /// StackExchangeRedis 的 IDistributedCache 實作把值存成 Redis Hash（HSET），
        /// 如果 Bump 端改用 IConnectionMultiplexer 直接 INCR，會在同一把 key 建立
        /// Redis String 型別，下次這裡讀取時 HGETALL 就會丟 WRONGTYPE（曾在 prod 發生過，
        /// 導致所有分頁列表 500）。遇到殘留的舊型別 key 就直接刪掉重算，等同一次快取失效。
        /// </remarks>
        public static async Task<long> GetListVersionAsync(
            this IDistributedCache cache,
            PageEnums service,
            CancellationToken ct = default
        )
        {
            var key = CacheKeys.ListVersion(service);
            try
            {
                var raw = await cache.GetStringAsync(key, ct);
                return long.TryParse(raw, out var v) ? v : 0;
            }
            catch (RedisServerException)
            {
                await cache.RemoveAsync(key, ct);
                return 0;
            }
        }

        /// <summary>
        /// 列表快取失效：版本號 +1。非原子操作（讀取後寫回），但失效只在寫入時觸發，
        /// 併發碰撞頂多讓某次失效少算一次版本，不會造成錯誤，換來型別與讀取端一致。
        /// </summary>
        public static async Task BumpListVersionAsync(
            this IDistributedCache cache,
            PageEnums service,
            CancellationToken ct = default
        )
        {
            var next = await cache.GetListVersionAsync(service, ct) + 1;
            await cache.SetStringAsync(
                CacheKeys.ListVersion(service),
                next.ToString(),
                new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromDays(30) },
                ct
            );
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

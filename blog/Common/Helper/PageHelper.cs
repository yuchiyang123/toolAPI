using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using blog.Common.Enum;
using blog.Common.Helper.Key;
using blog.Dtos.Page;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

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
            var total = query.Count();
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
            var fullKey = CacheKeys.PageList(service, pageIndex, pageSize, filterSHA);
            var cached = await cache.GetStringAsync(fullKey, ct);
            if (cached is not null)
                return JsonSerializer.Deserialize<PageResponseDto<T>>(cached!)!;

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

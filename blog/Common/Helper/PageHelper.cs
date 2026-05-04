using blog.Dtos.Page;
using Microsoft.EntityFrameworkCore;

namespace blog.Common.Helper
{
    public static class PageHelper
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public static async Task<PageResponseDto<T>> ToPageResponseDto<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            var total = query.Count();

            return new PageResponseDto<T>
            {
                PageIndex = pageIndex,
                PageTotal = (int)Math.Ceiling(total / (double)pageSize),
                HasNextPage = total > pageIndex * pageSize,
                Items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync()
            };
        }
    }
}

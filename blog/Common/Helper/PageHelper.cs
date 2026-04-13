using blog.Dtos.Page;
using Microsoft.EntityFrameworkCore;

namespace blog.Common.Helper
{
    public static class PageHelper
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageIndex)
        {
            return query.Skip((pageIndex - 1) * 10).Take(10);
        }

        public static async Task<PageResponseDto<T>> ToPageResponseDto<T>(this IQueryable<T> query, int pageIndex)
        {
            return new PageResponseDto<T>
            {
                PageIndex = pageIndex + 1,
                PageTotal = (int)Math.Ceiling(query.Count() / 10.0),
                HasNextPage = query.Count() > pageIndex * 10,
                Items = await query.ToListAsync()
            };
        }
    }
}

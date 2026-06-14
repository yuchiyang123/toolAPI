using blog.Dtos.Page;
using Microsoft.EntityFrameworkCore;

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

        private static PageResponseDto<T> GetPageResponseDto<T>(List<T> dto, int pageIndex, int pageSize, int total)
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
    }
}

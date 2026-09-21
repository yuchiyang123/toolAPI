using System.ComponentModel.DataAnnotations;

namespace blog.Dtos.Page
{
    public class PageDto
    {
        /// <summary>
        /// 每頁顯示數量（1–100，預設 10）
        /// </summary>
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 當前頁碼（從 1 開始）
        /// </summary>
        [Range(1, int.MaxValue)]
        public required int PageIndex { get; set; }

        /// <summary>
        /// 總頁數
        /// </summary>
        public int PageTotal { get; set; }

        /// <summary>
        /// 總筆數
        /// </summary>
        public int TotalSize { get; set; }

        /// <summary>
        /// 是否有下一頁
        /// </summary>
        public bool HasNextPage { get; set; }
    }

    public class PageQueryDto
    {
        /// <summary>
        /// 每頁顯示數量（1–100，預設 10）
        /// </summary>
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 當前頁碼（從 1 開始）
        /// </summary>
        [Range(1, int.MaxValue)]
        public required int PageIndex { get; set; }
    }

    public class PageResponseDto<T> : PageDto
    {
        public List<T> Items { get; set; } = [];
    }
}

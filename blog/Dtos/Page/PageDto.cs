namespace blog.Dtos.Page
{
    public class PageDto
    {
        /// <summary>
        /// 每頁顯示數量
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 當前頁碼
        /// </summary>
        public required int PageIndex { get; set; }
        /// <summary>
        /// 總頁數
        /// </summary>
        public int PageTotal { get; set; }
        /// <summary>
        /// 是否有下一頁
        /// </summary>
        public bool HasNextPage { get; set; }
    }

    public class PageQueryDto
    {
        /// <summary>
        /// 每頁顯示數量
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 當前頁碼
        /// </summary>
        public required int PageIndex { get; set; }
    }

    public class PageResponseDto<T> : PageDto
    {
        public List<T> Items { get; set; } = [];
    }
}

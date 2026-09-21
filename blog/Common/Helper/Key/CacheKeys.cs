using blog.Common.Enum;

namespace blog.Common.Helper.Key
{
    public static class CacheKeys
    {
        public static string Post(int id) => $"Post:{id}";

        public static string LockKey(string key) => $"lock:{key}";

        public static string PostSummary(int id) => $"PostSummary:{id}";

        public static string Recipe(int id) => $"Recipe:{id}";

        public static string FlowDetail(int id) => $"FlowDetail:{id}";

        public static string Problems(int id) => $"Problems:{id}";

        public static string Sequencer(int id) => $"Sequencer:{id}";

        /// <summary>
        /// 列表快取的版本號 key；invalidate 列表 = 版本 +1，舊 key 自然過期（不再 SCAN keyspace）
        /// </summary>
        public static string ListVersion(PageEnums service) => $"ver:{service}";

        public static string PageList(
            PageEnums service,
            long version,
            int index,
            int size,
            string filterSHA
        ) => $"{service}:v{version}:{filterSHA}:pi{index}:ps{size}";

        public static string PostViews(int id) => $"views:{id}";
    }
}

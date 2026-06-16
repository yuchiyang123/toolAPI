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
    }
}

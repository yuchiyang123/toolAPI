namespace blog.Common.Helper
{
    public static class CacheKeys
    {
        public static string Post(int id) => $"Post:{id}";
        public static string LockKey(string key) => $"lock:{key}";
    }
}

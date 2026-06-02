using StackExchange.Redis;

namespace blog.Common.Helper
{
    public class CacheHelper(IConnectionMultiplexer multiplexer)
    {
        public async Task<bool> AcquireLock(string lockKey, TimeSpan expiry)
        {
            var db = multiplexer.GetDatabase();
            return await db.StringSetAsync(lockKey, "1", expiry, When.NotExists);
        }

        public async Task<bool> ReleaseLock(string lockKey)
        {
            var db = multiplexer.GetDatabase();
            return await db.KeyDeleteAsync(lockKey);
        }
    }
}

using System.Linq.Expressions;
using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper.Key;
using blog.Dtos.Page;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace blog.Common.Helper
{
    public class CacheHelper(
        IConnectionMultiplexer multiplexer,
        IDistributedCache cache,
        IMapper mapper
    )
    {
        /// <summary>搶 lock 最多重試次數（50ms × 20 = 1 秒），超過就直接查資料來源、不寫快取</summary>
        private const int MaxLockAttempts = 20;
        private static readonly TimeSpan LockRetryDelay = TimeSpan.FromMilliseconds(50);
        private static readonly TimeSpan LockExpiry = TimeSpan.FromMinutes(10);

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

        public async Task<T?> SaveCacheAsync<T>(
            string key,
            Func<IQueryable> saveData,
            Expression<Func<T, bool>> predicate,
            CancellationToken ct,
            int attempt = 0
        )
            where T : class
        {
            var lockKey = CacheKeys.LockKey(key);
            if (attempt >= MaxLockAttempts)
            {
                return await saveData()
                    .ProjectTo<T>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(predicate, ct);
            }
            if (await AcquireLock(lockKey, LockExpiry))
            {
                try
                {
                    var data = await saveData()
                        .ProjectTo<T>(mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(predicate, ct);
                    if (data is null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    await cache.SaveRedisForObjectAsync<T>(key, data, ct);

                    return data;
                }
                finally
                {
                    await ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(LockRetryDelay, ct);
                return await SaveCacheAsync(key, saveData, predicate, ct, attempt + 1);
            }
        }

        public async Task<T?> SaveCacheAsync<T>(
            string key,
            Func<Task<T?>> factory,
            CancellationToken ct,
            int attempt = 0
        )
            where T : class
        {
            var lockKey = CacheKeys.LockKey(key);
            if (attempt >= MaxLockAttempts)
                return await factory();
            if (await AcquireLock(lockKey, LockExpiry))
            {
                try
                {
                    var saveData = await factory();
                    if (saveData is null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    await cache.SaveRedisForObjectAsync<T>(key, saveData, ct);

                    return saveData;
                }
                finally
                {
                    await ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(LockRetryDelay, ct);
                return await SaveCacheAsync(key, factory, ct, attempt + 1);
            }
        }

        public async Task<string?> SaveCacheAsync(
            string key,
            Func<Task<string?>> factory,
            CancellationToken ct,
            int attempt = 0
        )
        {
            var lockKey = CacheKeys.LockKey(key);
            if (attempt >= MaxLockAttempts)
                return await factory();
            if (await AcquireLock(lockKey, LockExpiry))
            {
                try
                {
                    var stringData = await factory();
                    if (stringData is null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    await cache.SaveRedisForStringAsync(key, stringData, ct);

                    return stringData;
                }
                finally
                {
                    await ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(LockRetryDelay, ct);
                return await SaveCacheAsync(key, factory, ct, attempt + 1);
            }
        }
    }
}

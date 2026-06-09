using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            CancellationToken ct
        )
            where T : class
        {
            var lockKey = CacheKeys.LockKey(key);
            if (await AcquireLock(lockKey, TimeSpan.FromMinutes(10)))
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

                    await cache.SaveReditForObjectAsync<T>(key, data, ct);

                    return data;
                }
                finally
                {
                    await ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(50, ct);
                return await SaveCacheAsync(key, saveData, predicate, ct);
            }
        }

        public async Task<T?> SaveCacheAsync<T>(
            string key,
            Func<Task<T?>> factory,
            CancellationToken ct
        )
            where T : class
        {
            var lockKey = CacheKeys.LockKey(key);
            if (await AcquireLock(lockKey, TimeSpan.FromMinutes(10)))
            {
                try
                {
                    var saveData = await factory();
                    if (saveData is null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    await cache.SaveReditForObjectAsync<T>(key, saveData, ct);

                    return saveData;
                }
                finally
                {
                    await ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(50, ct);
                return await SaveCacheAsync(key, factory, ct);
            }
        }

        public async Task<string?> SaveCacheAsync(
            string key,
            Func<Task<string?>> factory,
            CancellationToken ct
        )
        {
            var lockKey = CacheKeys.LockKey(key);
            if (await AcquireLock(lockKey, TimeSpan.FromMinutes(10)))
            {
                try
                {
                    var stringData = await factory();
                    if (stringData is null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    await cache.SaveReditForStringAsync(key, stringData, ct);

                    return stringData;
                }
                finally
                {
                    await ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(50, ct);
                return await SaveCacheAsync(key, factory, ct);
            }
        }
    }
}

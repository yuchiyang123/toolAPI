using System.Text.Json;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace blog.Services.Redis
{
    public class JudgaCacheService(
        IDistributedCache cache,
        CacheHelper cacheHelper,
        IConnectionMultiplexer connectionMultiplexer,
        JudgeService judgeService
    )
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

        public async Task<ProblemDetail?> GetProblemsDetail(int id, CancellationToken ct = default)
        {
            var key = CacheKeys.Problems(id);
            var cached = await cache.GetStringAsync(key, ct);
            if (cached is not null)
            {
                if (cached.IsCachedNull())
                    return null;
                return JsonSerializer.Deserialize<ProblemDetail?>(cached);
            }

            return await cacheHelper.SaveCacheAsync(
                key,
                async () => await judgeService.GetProblemDetailAsync(id),
                ct
            );
        }

        public async Task InvalidateProblemsDetailAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.Problems(id));
        }

        public async Task InvalidateProblemsListAsync()
        {
            var service = connectionMultiplexer.GetServer(
                connectionMultiplexer.GetEndPoints().First()
            );
            var keys = service.KeysAsync(pattern: $"Blog{PageEnums.ProblemsList}:*");
            await foreach (var key in keys)
                await _database.KeyDeleteAsync(key);
        }
    }
}

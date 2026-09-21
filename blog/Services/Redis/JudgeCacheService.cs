using System.Text.Json;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace blog.Services.Redis
{
    public class JudgeCacheService(
        IDistributedCache cache,
        CacheHelper cacheHelper,
        IConnectionMultiplexer connectionMultiplexer,
        JudgeService judgeService
    )
    {
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
            await connectionMultiplexer.BumpListVersionAsync(PageEnums.ProblemsList);
        }
    }
}

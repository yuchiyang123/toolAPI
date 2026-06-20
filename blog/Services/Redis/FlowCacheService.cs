using System.Text.Json;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Common.Helper.Key;
using blog.Dtos.Flow;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace blog.Services.Redis
{
    public class FlowCacheService(
        IDistributedCache cache,
        IConnectionMultiplexer connectionMultiplexer,
        CacheHelper cacheHelper,
        FlowService flowService
    )
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

        public async Task<FlowDetailResponseDto?> GetFlowDetail(
            int id,
            CancellationToken ct = default
        )
        {
            var key = CacheKeys.FlowDetail(id);
            var cached = await cache.GetStringAsync(key, ct);
            if (cached is not null)
            {
                if (cached.IsCachedNull())
                    return null;
                return JsonSerializer.Deserialize<FlowDetailResponseDto?>(cached);
            }

            return await cacheHelper.SaveCacheAsync(
                key,
                async () => await flowService.GetFlowDetailAsync(id),
                ct
            );
        }

        public async Task InvalidateFlowDetailAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.FlowDetail(id));
        }

        public async Task InvalidateFlowListAsync()
        {
            var service = connectionMultiplexer.GetServer(
                connectionMultiplexer.GetEndPoints().First()
            );
            var keys = service.KeysAsync(pattern: $"Blog{PageEnums.FlowList}:*");
            await foreach (var key in keys)
                await _database.KeyDeleteAsync(key);
        }
    }
}

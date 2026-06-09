using System.Text.Json;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.Flow;
using blog.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services.Redis
{
    public class FlowCacheService(
        IDistributedCache cache,
        CacheHelper cacheHelper,
        FlowService flowService
    )
    {
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
    }
}

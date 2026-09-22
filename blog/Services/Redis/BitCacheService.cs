using System.Text.Json;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Common.Helper.Key;
using blog.Dtos._8bit;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services.Redis
{
    public class BitCacheService(
        IDistributedCache cache,
        CacheHelper cacheHelper,
        BitService service
    )
    {
        public async Task<SequencerResponseDto?> Get8BitDetail(
            int id,
            CancellationToken ct = default
        )
        {
            var key = CacheKeys.Sequencer(id);
            var cached = await cache.GetStringAsync(key, ct);
            if (cached is not null)
            {
                if (cached.IsCachedNull())
                    return null;
                return JsonSerializer.Deserialize<SequencerResponseDto?>(cached);
            }

            return await cacheHelper.SaveCacheAsync(
                key,
                async () => await service.Get8BitDetailAsync(id),
                ct
            );
        }

        public async Task Invalidate8BitDetailAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.Sequencer(id));
        }

        public async Task Invalidate8BitListAsync()
        {
            await cache.BumpListVersionAsync(PageEnums._8BitList);
        }
    }
}

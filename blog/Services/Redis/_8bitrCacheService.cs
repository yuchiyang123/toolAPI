using System.Text.Json;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Common.Helper.Key;
using blog.Dtos._8bit;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace blog.Services.Redis
{
    public class _8bitrCacheService(
        IDistributedCache cache,
        IConnectionMultiplexer connectionMultiplexer,
        CacheHelper cacheHelper,
        _8BitService service
    )
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

        public async Task<SequencerResponseDto?> Get8BitDetail(
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
            await cache.RemoveAsync(CacheKeys.FlowDetail(id));
        }

        public async Task Invalidate8BitListAsync()
        {
            var service = connectionMultiplexer.GetServer(
                connectionMultiplexer.GetEndPoints().First()
            );
            var keys = service.KeysAsync(pattern: $"Blog{PageEnums._8BitList}:*");
            await foreach (var key in keys)
                await _database.KeyDeleteAsync(key);
        }
    }
}

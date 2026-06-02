using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services.Redis
{
    public class RecipeCacheService(IDistributedCache cache, IMapper mapper, RecipeRepository recipeRepository, CacheHelper cacheHelper)
    {
        public async Task<RecipeDetailResponse?> GetRecipeDetailAsync(int id, CancellationToken ct = default)
        {
            var key = CacheKeys.Recipe(id);
            var cached = await cache.GetStringAsync(key, ct);
            if (cached is not null)
            {
                if (cached == null) return null;
                return JsonSerializer.Deserialize<RecipeDetailResponse?>(cached);
            }

            var lockKey = CacheKeys.LockKey(key);
            if (await cacheHelper.AcquireLock(lockKey, TimeSpan.FromMinutes(10)))
            {
                try
                {
                    var dto = await recipeRepository.GetRecipesNoInclaude().ProjectTo<RecipeDetailResponse>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id, ct);
                    if (dto == null)
                    {
                        await cache.SaveRedisForNullAsync(key, ct);
                        return null;
                    }

                    var dtoString = JsonSerializer.Serialize(dto);
                    await cache.SetStringAsync(key, dtoString, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30, Random.Shared.Next(0, 10))
                    }, ct);

                    return dto;
                }
                finally
                {
                    await cacheHelper.ReleaseLock(lockKey);
                }
            }
            else
            {
                await Task.Delay(100, ct);
                return await GetRecipeDetailAsync(id, ct);
            }
        }

        public async Task InvalidateRecipeAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.Recipe(id));
        }
    }
}

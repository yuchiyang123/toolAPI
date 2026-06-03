using System.Text.Json;
using blog.Common.Helper;
using blog.Dtos;
using blog.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services.Redis
{
    public class RecipeCacheService(
        IDistributedCache cache,
        RecipeRepository recipeRepository,
        CacheHelper cacheHelper
    )
    {
        public async Task<RecipeDetailResponse?> GetRecipeDetailAsync(
            int id,
            CancellationToken ct = default
        )
        {
            var key = CacheKeys.Recipe(id);
            var cached = await cache.GetStringAsync(key, ct);
            if (cached is not null)
            {
                if (cached.IsCachedNull())
                    return null;
                return JsonSerializer.Deserialize<RecipeDetailResponse?>(cached);
            }

            return await cacheHelper.SaveCacheAsync<RecipeDetailResponse>(
                key,
                () => recipeRepository.GetRecipesNoInclaude(),
                x => x.Id == id,
                ct
            );
        }

        public async Task InvalidateRecipeAsync(int id)
        {
            await cache.RemoveAsync(CacheKeys.Recipe(id));
        }
    }
}

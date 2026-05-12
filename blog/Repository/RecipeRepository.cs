using blog.Entities;
using blog.Entities.Recipes;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository
{
    public class RecipeRepository(BlogContext context)
    {
        public IQueryable<Recipe> GetRecipes()
        {
            return context.Recipe.AsSplitQuery()
                .Include(x => x.RecipeDetailMappings)
                    .ThenInclude(x => x.RecipeDetail)
                .Include(x => x.RecipeTagMappings)
                    .ThenInclude(x => x.RecipeTag)
                .Include(x => x.RecipeIngredientsMappings)
                    .ThenInclude(x => x.RecipeIngredients)
                        .ThenInclude(x => x.RecipeIngredientsDetailMappings)
                            .ThenInclude(x => x.RecipeIngredientsDetail)
                .Include(x => x.RecipeStepMappings)
                    .ThenInclude(x => x.RecipeStep)
                .Include(x => x.RecipeFileMappings)
                    .ThenInclude(x => x.Files)
                .AsQueryable();
        }
    }
}

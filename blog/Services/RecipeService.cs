using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.Page;
using blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class RecipeService(BlogContext context, IMapper mapper)
    {
        public async Task<PageResponseDto<RecipeResponse>> GetRecipe(RecipeQueryDto queryDto)
        {
            return await context.Recipe.ProjectTo<RecipeResponse>(mapper.ConfigurationProvider).ToPageResponseDto(queryDto.PageIndex, queryDto.PageSize);
        }

        public async Task<RecipeDetailResponse> GetRecipeDetail(int id)
        {
            return await context.Recipe.ProjectTo<RecipeDetailResponse>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("找不到對應的文章");
        }
    }
}

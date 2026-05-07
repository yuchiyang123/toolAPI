using blog.Dtos;
using blog.Dtos.Page;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class RecipeController(RecipeService service) : ControllerBase
    {
        /// <summary>
        /// 取得食譜列表
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<PageResponseDto<RecipeResponse>> GetRecipe([FromQuery]RecipeQueryDto queryDto)
        {
            return await service.GetRecipe(queryDto);
        }

        /// <summary>
        /// 取得對應的食譜
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<RecipeDetailResponse> GetRecipeDetail(int id)
        {
            return await service.GetRecipeDetail(id);
        }
    }
}

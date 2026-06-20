using blog.Dtos;
using blog.Dtos.Page;
using blog.Services;
using blog.Services.Redis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController(RecipeService service, RecipeCacheService cacheService)
        : ControllerBase
    {
        /// <summary>
        /// 取得食譜列表
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<PageResponseDto<RecipeResponse>> GetRecipe(
            [FromQuery] RecipeQueryDto queryDto
        )
        {
            return await service.GetRecipe(queryDto);
        }

        /// <summary>
        /// 取得對應的食譜
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<RecipeDetailResponse?> GetRecipeDetail(int id)
        {
            return await cacheService.GetRecipeDetailAsync(id);
        }

        /// <summary>
        /// 新增食譜
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateRecipe([FromForm] RecipeRequest requestDto)
        {
            await service.CreateRecipe(requestDto);
            await cacheService.InvalidateRecipeListAsync();
            return Ok();
        }

        /// <summary>
        /// 異動食譜
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateRcipe(int id, [FromForm] RecipeRequest requestDto)
        {
            await service.UpdateRecipe(id, requestDto);
            await cacheService.InvalidateRecipeAsync(id);
            await cacheService.InvalidateRecipeListAsync();
            return Ok();
        }

        /// <summary>
        /// 刪除食譜
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await service.DeleteRecipe(id);
            await cacheService.InvalidateRecipeListAsync();
            await cacheService.InvalidateRecipeAsync(id);
            return Ok();
        }
    }
}

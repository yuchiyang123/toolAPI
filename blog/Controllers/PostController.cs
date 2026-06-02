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
    public class PostController(PostService service, BlogCacheService blogCacheService) : ControllerBase
    {
        [HttpGet()]
        public async Task<PageResponseDto<PostDto>> GetPostAsync([FromQuery] PostRequestDto dto)
        {
            return await service.GetPostAsync(dto);
        }

        [HttpGet("{id}")]
        public async Task<PostDto?> GetPostDetailAsync(int id)
        {
            return await blogCacheService.GetPostDetailAsync(id);
        }

        [HttpPost()]
        [Authorize]
        public async Task<ActionResult> CreatePostAsync([FromBody] CreatePostDto dto)
        {
            try
            {
                await service.CreatePostAsync(dto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        [Authorize]
        public async Task<ActionResult> UpdatePostAsync([FromBody] UpdatePostDto dto)
        {
            try
            {
                await service.UpdatePostAsync(dto);
                await blogCacheService.InvalidatePostAsync(dto.Id);
                await blogCacheService.InvalidataPostSummaryAsync(dto.Id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletePostAsync(int id)
        {
            await service.DeletePostAsync(id);
            await blogCacheService.InvalidatePostAsync(id);
            await blogCacheService.InvalidataPostSummaryAsync(id);
            return Ok();
        }

        [HttpPatch("view/{id}")]
        public async Task<ActionResult> UpdatePostsViewAsync(int id)
        {
            await service.UpdatePostsViewAsync(id);
            return Ok();
        }

        [HttpGet("{id}/summary")]
        public async Task<ActionResult<string>> GetAiSummaryAsync(int id)
        {
            var content = await blogCacheService.GetPostSummaryAsync(id);
            return Ok(content);
        }

        [HttpGet("tags")]
        public async Task<ActionResult<List<string>>> GetTags()
        {
            return Ok(await service.GetTags());
        }
    }
}

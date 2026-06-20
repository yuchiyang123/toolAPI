using System.Security.Claims;
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
    public class PostController(PostService service, BlogCacheService cacheService) : ControllerBase
    {
        [HttpGet()]
        public async Task<PageResponseDto<PostDto>> GetPostAsync([FromQuery] PostRequestDto dto)
        {
            return await service.GetPostAsync(dto);
        }

        [HttpGet("{id}")]
        public async Task<PostDto?> GetPostDetailAsync(int id)
        {
            return await cacheService.GetPostDetailAsync(id);
        }

        [HttpPost()]
        [Authorize]
        public async Task<ActionResult> CreatePostAsync([FromBody] CreatePostDto dto)
        {
            try
            {
                await service.CreatePostAsync(dto);
                await cacheService.InvalidatePostListAsync();
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await service.ValidUpdatePostUser(dto.Id, userId))
                return Forbid();
            try
            {
                await service.UpdatePostAsync(dto);
                await cacheService.InvalidatePostAsync(dto.Id);
                await cacheService.InvalidataPostSummaryAsync(dto.Id);
                await cacheService.InvalidatePostListAsync();
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await service.ValidUpdatePostUser(id, userId))
                return Forbid();

            await service.DeletePostAsync(id);
            await cacheService.InvalidatePostAsync(id);
            await cacheService.InvalidataPostSummaryAsync(id);
            await cacheService.InvalidatePostListAsync();
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
            var content = await cacheService.GetPostSummaryAsync(id);
            return Ok(content);
        }

        [HttpGet("tags")]
        public async Task<ActionResult<List<string>>> GetTags()
        {
            return Ok(await service.GetTags());
        }
    }
}

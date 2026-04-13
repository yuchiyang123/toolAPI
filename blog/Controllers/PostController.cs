using blog.Dtos;
using blog.Entities.Page;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(PostService service) : ControllerBase
    {
        [HttpGet()]
        public async Task<PageResponseDto<PostDto>> GetPostAsync([FromQuery] PostRequestDto dto)
        {
            return await service.GetPostAsync(dto);
        }

        [HttpPost()]
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
    }
}

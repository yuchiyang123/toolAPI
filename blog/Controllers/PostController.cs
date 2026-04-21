using blog.Dtos;
using blog.Dtos.Page;
using blog.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(PostService service, AiService aiService) : ControllerBase
    {
        [HttpGet()]
        public async Task<PageResponseDto<PostDto>> GetPostAsync([FromQuery] PostRequestDto dto)
        {
            return await service.GetPostAsync(dto);
        }

        [HttpGet("{id}")]
        public async Task<PostDto> GetPostDetailAsync(int id)
        {
            return await service.GetPostDetailAsync(id);
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

        [HttpPut()]
        public async Task<ActionResult> UpdatePostAsync([FromBody] UpdatePostDto dto)
        {
            try
            {
                await service.UpdatePostAsync(dto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostAsync(int id)
        {
            await service.DeletePostAsync(id);
            return Ok();
        }

        [HttpPatch("view/{id}")]
        public async Task<ActionResult> UpdatePostsView(int id)
        {
            await service.UpdatePostsViewAsync(id);
            return Ok();
        }

        [HttpGet("{id}/summary")]
        public async Task<ActionResult> GetAiSummary(int id)
        {
            await aiService.GetPostAISummary(id);
            return Ok();
        }
    }
}

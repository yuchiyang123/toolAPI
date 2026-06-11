using blog.Dtos._8bit;
using blog.Dtos.Page;
using blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitController(_8BitService service) : ControllerBase
    {
        [HttpGet("list")]
        public async Task<ActionResult<PageResponseDto<SequencerListRequestDto>>> Get8BitListAsync(
            [FromQuery] PageDto queryDto
        )
        {
            var pageDto = await service.Get8BitListAsync(queryDto);
            return Ok(pageDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SequencerResponseDto>> Get8BitDetailAsync(int id)
        {
            var detailDto = await service.Get8BitDetailAsync(id);
            return Ok(detailDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add8BitAsync([FromBody] SequencerRequestDto dto)
        {
            await service.Add8BitAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete8bitAsync(int id)
        {
            await service.Delete8bitAsync(id);
            return Ok();
        }
    }
}

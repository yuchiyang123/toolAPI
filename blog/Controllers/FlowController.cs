using blog.Dtos.Flow;
using blog.Dtos.Page;
using blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController(FlowService flowService) : ControllerBase
    {
        [HttpGet("list")]
        public async Task<ActionResult<PageResponseDto<FlowList>>> GetFlowListAsync(
            [FromQuery] FlowListQueryDto queryDto
        )
        {
            var dtos = await flowService.GetFlowListAsync(queryDto);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlowDetailResponseDto>> GetFlowDetailAsync(int id)
        {
            return Ok(await flowService.GetFlowDetailAsync(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddFlowAsync([FromBody] CreateFlowDto dto)
        {
            await flowService.AddFlowAsync(dto);
            return Ok();
        }

        [HttpPost("detail")]
        [Authorize]
        public async Task<IActionResult> PostFlowAsync([FromBody] FlowDetailsRequestDto dto)
        {
            await flowService.AddFlowDetailAsync(dto);
            return Ok();
        }
    }
}

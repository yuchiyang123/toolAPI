using blog.Dtos;
using blog.Dtos.Flow;
using blog.Dtos.Page;
using blog.Services;
using blog.Services.Redis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController(FlowService flowService, FlowCacheService cacheService)
        : ControllerBase
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
            var dto = await cacheService.GetFlowDetail(id);
            return Ok(dto);
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

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFlow(int id)
        {
            await flowService.DeleteFlow(id);
            return Ok();
        }

        [HttpDelete("detail/{verionsId}")]
        [Authorize]
        public async Task<IActionResult> DeleteFlowVerions(int verionsId)
        {
            await flowService.DeleteFlowVerions(verionsId);
            await cacheService.InvalidateFlowDetailAsync(verionsId);
            return Ok();
        }

        [HttpGet("list/dropdown")]
        public async Task<ActionResult<List<DropDownListDto>>> GetMainFlowDropDownInfoAsync()
        {
            var dtos = await flowService.GetMainFlowDropDownInfoAsync();
            return Ok(dtos);
        }
    }
}

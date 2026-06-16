using blog.Dtos.Judge;
using blog.Dtos.Page;
using blog.Services;
using blog.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeController(JudgeService service, JudgaCacheService cacheService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<JudgeResult>> GetRunAsync([FromBody] JudgeDto judge)
        {
            var dto = await service.RunAsync(judge);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<PageResponseDto<ProblemsList>>> GetProblemsListAsync(
            [FromQuery] ProblemsListQuery query
        )
        {
            var dto = await service.GetProblemListAsync(query);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProblemDetail>> GetProblemsDetailAsync(int id)
        {
            var dto = await cacheService.GetProblemsDetail(id);
            return Ok(dto);
        }
    }
}

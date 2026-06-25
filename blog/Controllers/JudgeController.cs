using blog.Common.Enum;
using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using blog.Dtos.Page;
using blog.Messaging;
using blog.Messaging.Consumers;
using blog.Migrations;
using blog.Services;
using blog.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeController(
        JudgeService service,
        JudgaCacheService cacheService,
        Publisher publisher
    ) : ControllerBase
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

        [HttpPost("id")]
        public async Task<IActionResult> GetRun([FromBody] JudgeRequestDto judge)
        {
            await cacheService.InvalidateProblemsDetailAsync(judge.Id);
            await publisher.PublishAsync(judge, MQNameKey.JudgeQueue);
            return StatusCode(202);
        }

        [HttpPost("id/test")]
        public async Task<IActionResult> GetRunTest([FromBody] JudgeTestRequestDto dto)
        {
            await publisher.PublishAsync(dto, MQNameKey.JudgeTestQueue);
            return StatusCode(202);
        }
    }
}

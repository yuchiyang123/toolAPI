using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using blog.Dtos.Page;
using blog.Messaging;
using blog.Messaging.Consumers;
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
        public async Task<ActionResult<SubmissionResponse>> GetRunById(
            [FromBody] JudgeRequestDto judge
        )
        {
            await cacheService.InvalidateFlowDetailAsync(judge.Id);
            var dto = await publisher.SendAsync<JudgeRequestDto, SubmissionResponse>(
                judge,
                TimeSpan.FromSeconds(60),
                MQNameKey.JudgeQueue,
                MQNameKey.JudgeReply
            );
            //var dto = await service.GetJudgeResultById(judge);
            return Ok(dto);
        }
    }
}

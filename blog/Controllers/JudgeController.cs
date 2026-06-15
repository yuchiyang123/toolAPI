using blog.Dtos.Judge;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeController(JudgeService service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<JudgeResult>> GetRunAsync([FromBody] JudgeDto judge)
        {
            var dto = await service.RunAsync(judge);
            return Ok(dto);
        }
    }
}

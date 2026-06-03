using blog.Dtos;
using blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController(ToolService service) : ControllerBase
    {
        [HttpGet("sql")]
        public string GetSql([FromQuery] ToolDto dto)
        {
            return service.GetSql(dto);
        }
    }
}

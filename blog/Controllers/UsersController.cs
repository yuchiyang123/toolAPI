using blog.Dtos;
using blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserService service) : ControllerBase
    {
        [HttpGet("dropdown")]
        [Authorize]
        public async Task<ActionResult<List<DropDownListDto>>> GetUserDropDownListAsync()
        {
            var dtos = await service.GetUserDropDownAsync();
            return Ok(dtos);
        }
    }
}

using blog.Dtos;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(UserService service) : Controller
    {
        [HttpGet()]
        public async Task<ActionResult> Login()
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<ActionResult> Create(CreateUserDto userDto)
        {
            var valid = await service.ValidUserName(userDto.UserName);
            if (!valid)
                return BadRequest();
            return Ok();
        }
    }
}

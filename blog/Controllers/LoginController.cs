using blog.Dtos;
using blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(UserService service, JwtService jwtService) : Controller
    {
        [HttpPost()]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto dto)
        {
            if (await service.LoginAsync(dto.UserName, dto.Password))
            {
                int userId = await service.GetIdByUserName(dto.UserName);
                string token = jwtService.GenerateeToken(userId.ToString());
                return Ok(token);
            }
            return BadRequest();
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult> Create(CreateUserDto userDto)
        {
            var valid = await service.ValidUserName(userDto.UserName);
            if (!valid)
                return BadRequest();
            await service.CreateUserAsync(userDto);
            return Ok();
        }

        [HttpGet("dropdown")]
        [Authorize]
        public async Task<ActionResult<List<DropDownListDto>>> GetUserDropDownListAsync()
        {
            var dtos = await service.GetUserDropDownAsync();
            return Ok(dtos);
        }
    }
}

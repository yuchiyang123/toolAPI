using blog.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpGet()]
        public async Task<ActionResult> Login()
        {
            return Ok();
        }
    }
}

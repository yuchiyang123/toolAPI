using blog.Entities.User;
using System.Security.Claims;

namespace blog.Common.Helper
{
    public class TokenHelper(IConfiguration config)
    {
        private readonly IConfiguration configuration = config;

        //public string GenerateToken(Users user)
        //{
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //    };
        //}
    }
}

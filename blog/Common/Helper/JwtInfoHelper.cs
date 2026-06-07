using blog.Entities;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace blog.Common.Helper
{
    public class JwtInfoHelper(IHttpContextAccessor httpContextAccessor, BlogContext context)
    {
        public async Task<int> GetUserIdForJwt()
        {
            var user = httpContextAccessor.HttpContext?.User;
            var jwtUserId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? user?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            return await GetUserId(jwtUserId);
        }

        private async Task<int> GetUserId(string? jwtUserId)
        {
            if (!int.TryParse(jwtUserId, out int userId))
                throw new FormatException(jwtUserId);
            var exist = await context.Users.AnyAsync(x => x.Id == userId);
            if (!exist) throw new KeyNotFoundException();
            return userId;
        }
    }
}

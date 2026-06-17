using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace blog.Common.Helper
{
    public class JwtInfoHelper(IHttpContextAccessor httpContextAccessor, BlogContext context)
    {
        public async Task<int> GetUserIdForJwt()
        {
            var jwtUserId = GetUserId();
            return await GetUserId(jwtUserId);
        }

        public async Task<bool> HasUserIdAsync()
        {
            var jwtUserId = GetUserId();
            int userId = ConvertStringToInt(jwtUserId);
            return await HasUserIdAsync(userId);
        }

        private async Task<int> GetUserId(string? jwtUserId)
        {
            int userId = ConvertStringToInt(jwtUserId);
            var exist = await HasUserIdAsync();
            if (!exist)
                throw new KeyNotFoundException();
            return userId;
        }

        private async Task<bool> HasUserIdAsync(int userId)
        {
            return await context.Users.AnyAsync(x => x.Id == userId);
        }

        private static int ConvertStringToInt(string? id)
        {
            if (!int.TryParse(id, out int userId))
                throw new FormatException(id);
            return userId;
        }

        private string? GetUserId()
        {
            var user = httpContextAccessor.HttpContext?.User;
            return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? user?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        }
    }
}

using AutoMapper;
using blog.Dtos;
using blog.Entities;
using blog.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class UserService(BlogContext context, IMapper mapper)
    {
        public async Task CreateUserAsync(CreateUserDto userDto)
        {
            var entity = mapper.Map<Users>(userDto);
            var hasher = new PasswordHasher<Users>();
            entity.PasswordHash = hasher.HashPassword(entity, userDto.Password);
            context.Users.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ValidUserName(string userName)
        {
            var isRepeat = await context.Users.AnyAsync(x => x.UserName == userName);
            return !isRepeat;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            var users = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (users is null)
                return false;
            var hasher = new PasswordHasher<Users>();
            var result = hasher.VerifyHashedPassword(users, users.PasswordHash, password);
            return result != PasswordVerificationResult.Failed;
        }
    }
}

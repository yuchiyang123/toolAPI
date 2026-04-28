using AutoMapper;
using blog.Dtos;
using blog.Entities;
using blog.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class UserService(BlogContext context, IMapper mapper)
    {
        public async Task CreateUserAsync(CreateUserDto userDto)
        {
            var entity = mapper.Map<Users>(userDto);
            context.Users.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ValidUserName(string userName)
        {
            var isRepeat = await context.Users.AnyAsync(x => x.UserName == userName);
            return isRepeat ? false : true;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            return await context.Users.AnyAsync(x => x.UserName == userName && x.Password == password);
        }
    }
}

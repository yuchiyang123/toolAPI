using AutoMapper;
using blog.Dtos;
using blog.Entities.User;

namespace blog.Common.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, Users>();
        }
    }
}

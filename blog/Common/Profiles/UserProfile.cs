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

            CreateMap<Users, DropDownListDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.UserName));
        }
    }
}

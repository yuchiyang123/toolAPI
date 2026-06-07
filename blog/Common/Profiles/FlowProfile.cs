using AutoMapper;
using blog.Dtos;
using blog.Dtos.Flow;
using blog.Entities.Flows;
using blog.Entities.User;

namespace blog.Common.Profiles
{
    public class FlowProfile : Profile
    {
        public FlowProfile()
        {
            CreateMap<Flow, FlowList>()
                .ForMember(dest => dest.UpdateUserData, opt => opt.MapFrom(src => src.UpdateUsers))
                .ForMember(dest => dest.CreateUserData, opt => opt.MapFrom(src => src.CreateUsers))
                .ForMember(dest => dest.FlowActionVersion, opt => opt.MapFrom(src => src.FlowVersion.Where(x => x.IsActive).Select(y => y.Version)))
                .ForMember(dest => dest.FlowVersionList, opt => opt.MapFrom(src => src.FlowVersion));
            CreateMap<Users, UserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));
            CreateMap<FlowVersion, FlowVersionList>()
                .ForMember(dest => dest.VersionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FlowVersion, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.UpdateUserData, opt => opt.MapFrom(src => src.UpdateUsers))
                .ForMember(dest => dest.CreateUserData, opt => opt.MapFrom(src => src.CreateUsers));
        }
    }
}

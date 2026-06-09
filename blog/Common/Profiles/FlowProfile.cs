using System.Text.Json;
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
                .ForMember(dest => dest.FlowVersionList, opt => opt.MapFrom(src => src.FlowVersion))
                .ForMember(dest => dest.FlowName, opt => opt.MapFrom(src => src.Name))
                .AfterMap(
                    (src, dest) =>
                    {
                        dest.FlowActionVersion = src
                            .FlowVersion?.Where(x => x.IsActive)
                            .Select(y => y.Version)
                            .First();
                    }
                );
            CreateMap<Users, UserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));
            CreateMap<FlowVersion, FlowVersionList>()
                .ForMember(dest => dest.VersionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FlowVersion, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.UpdateUserData, opt => opt.MapFrom(src => src.UpdateUsers))
                .ForMember(dest => dest.CreateUserData, opt => opt.MapFrom(src => src.CreateUsers));

            CreateMap<FlowVersion, FlowDetailResponseDto>()
                .ForMember(dest => dest.VersionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FlowVersion, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.UpdateUserData, opt => opt.MapFrom(src => src.UpdateUsers))
                .ForMember(dest => dest.CreateUserData, opt => opt.MapFrom(src => src.CreateUsers))
                .ForMember(dest => dest.Nodes, opt => opt.MapFrom(src => src.FlowNodes))
                .ForMember(dest => dest.Edges, opt => opt.MapFrom(src => src.FlowEdges));
            CreateMap<FlowNode, FlowNodeDto>()
                .ForMember(dest => dest.Rules, opt => opt.MapFrom(src => src.FlowRules));
            CreateMap<FlowRule, FlowRuleDto>()
                .AfterMap(
                    (src, dest) =>
                    {
                        dest.Condition = string.IsNullOrEmpty(src.ConditionJson)
                            ? null
                            : JsonSerializer.Deserialize<ConditionGroup>(src.ConditionJson);
                        dest.Action = string.IsNullOrEmpty(src.ActionJson)
                            ? null
                            : JsonSerializer.Deserialize<Dtos.Flow.Action>(src.ActionJson);
                    }
                );
            CreateMap<FlowEdge, FlowEdgeDto>()
                .AfterMap(
                    (src, dest) =>
                    {
                        dest.Condition = string.IsNullOrEmpty(src.DataJson)
                            ? null
                            : JsonSerializer.Deserialize<ConditionGroup>(src.DataJson);
                    }
                );

            CreateMap<CreateFlowDto, Flow>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FlowName));

            CreateMap<Flow, DropDownListDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name));
        }
    }
}

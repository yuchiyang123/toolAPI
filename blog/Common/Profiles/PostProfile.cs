using AutoMapper;
using blog.Dtos;
using blog.Entities.Blog;

namespace blog.Common.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Posts, PostDto>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.PostsTagsMapping.Select(x => x.PostsTag.Tag)))
                .ForMember(dest => dest.CreateUserName, opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<Posts, PostDetailDto>()
                .IncludeBase<Posts, PostDto>()
                .ForMember(dest => dest.ChangeRecords, opt => opt.MapFrom(src => src.PostsChangeRecords));
            CreateMap<PostsChangeRecord, ChangeRecords>();

            CreateMap<CreatePostDto, Posts>();
        }
    }
}

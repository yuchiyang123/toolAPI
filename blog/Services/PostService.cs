using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Entities;
using blog.Entities.Blog;
using blog.Entities.Page;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class PostService(IMapper mapper, BlogContext context)
    {
        public async Task<PageResponseDto<PostDto>> GetPostAsync(PostRequestDto requestDto)
        {
            return await context.Posts.Include(x => x.User).OrderByDescending(x => x.CreateDate).Page(requestDto.PageIndex).ProjectTo<PostDto>(mapper.ConfigurationProvider).ToPageResponseDto(requestDto.PageIndex);           
        }

        public async Task CreatePostAsync(CreatePostDto postDto)
        {
            var entity = mapper.Map<Posts>(postDto);
            context.Posts.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}

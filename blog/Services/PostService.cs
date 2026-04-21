using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class PostService(IMapper mapper, BlogContext context)
    {
        public async Task<PageResponseDto<PostDto>> GetPostAsync(PostRequestDto requestDto)
        {
            return await context.Posts.Include(x => x.User).OrderByDescending(x => x.CreateDate).Page(requestDto.PageIndex, requestDto.PageSize)
                .ProjectTo<PostDto>(mapper.ConfigurationProvider).ToPageResponseDto(requestDto.PageIndex, requestDto.PageSize);
        }

        public async Task<PostDto> GetPostDetailAsync(int id)
        {
            return await context.Posts.Include(x => x.User).ProjectTo<PostDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("找不到對應的文章");
        }

        public async Task CreatePostAsync(CreatePostDto postDto)
        {
            var entity = mapper.Map<Posts>(postDto);
            context.Posts.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(UpdatePostDto updatePostDto)
        {
            var entity = await context.Posts.Where(x => x.Id == updatePostDto.Id).FirstOrDefaultAsync() ?? throw new Exception("找不到對應的文章");
            mapper.Map(updatePostDto, entity);
            await context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var entity = await context.Posts.Where(x => x.Id == id).FirstOrDefaultAsync() ?? throw new Exception("找不到對應的文章");
            context.Posts.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePostsViewAsync(int id)
        {
            var entity = await context.Posts.Where(x => x.Id == id).FirstOrDefaultAsync() ?? throw new Exception("找不到對應的文章");
            entity.View += 1;
            await context.SaveChangesAsync();
        }
    }
}

using blog.Dtos;
using blog.Entities;
using blog.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository
{
    public class PostRepository(BlogContext context)
    {
        public IQueryable<Posts> GetPost(PostRequestDto requestDto)
        {
            var query = context.Posts.Include(x => x.PostsTagsMapping).ThenInclude(x => x.PostsTag).Include(x => x.User).OrderByDescending(x => x.CreateDate).AsQueryable();
            if (requestDto.TagIds.Count != 0)
                query = query.Where(x => x.PostsTagsMapping.Any(y => requestDto.TagIds.Contains(y.Id)));
            if (!string.IsNullOrEmpty(requestDto.Title))
                query = query.Where(x => x.Title.Contains(requestDto.Title));
            return query;
        }

        public IQueryable<Posts> GetPostDetail()
        {
            return context.Posts.Include(x => x.PostsTagsMapping).ThenInclude(x => x.PostsTag).Include(x => x.User).Include(x => x.PostsChangeRecords).AsQueryable();
        }

        public IQueryable<Posts> GetPostTag()
        {
            return context.Posts.Include(x => x.PostsTagsMapping).ThenInclude(x => x.PostsTag).AsQueryable();
        }

        public IQueryable<Posts> GetPostNoIncludeAny()
        {
            return context.Posts.AsQueryable();
        }

        public IQueryable<PostsTagMapping> GetTags()
        {
            return context.PostsTagsMapping.AsQueryable();
        }

    }
}

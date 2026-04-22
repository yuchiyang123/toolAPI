using System.Net.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.AI;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class PostService(IMapper mapper, BlogContext context, OllamaHelper ollamaHelper)
    {
        public async Task<PageResponseDto<PostDto>> GetPostAsync(PostRequestDto requestDto)
        {
            return await context.Posts.Include(x => x.PostsTags).Include(x => x.User).OrderByDescending(x => x.CreateDate).Page(requestDto.PageIndex, requestDto.PageSize)
                .ProjectTo<PostDto>(mapper.ConfigurationProvider).ToPageResponseDto(requestDto.PageIndex, requestDto.PageSize);
        }

        public async Task<PostDetailDto> GetPostDetailAsync(int id)
        {
            return await context.Posts.Include(x => x.PostsTags).Include(x => x.User).Include(x => x.PostsChangeRecords)
                .ProjectTo<PostDetailDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("找不到對應的文章");
        }

        public async Task CreatePostAsync(CreatePostDto postDto)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var entity = mapper.Map<Posts>(postDto);
                context.Posts.Add(entity);
                await context.SaveChangesAsync();
                var entityTag = new List<PostsTag>();
                if (postDto.Tags != null && postDto.Tags.Count != 0)
                {
                    foreach (var tag in postDto.Tags)
                    {
                        entityTag.Add(new PostsTag
                        {
                            FK_PostsId = entity.Id,
                            Tag = tag,
                        });
                    }
                }
                context.PostsTags.AddRange(entityTag);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdatePostAsync(UpdatePostDto updatePostDto)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var entity = await context.Posts.Include(x => x.PostsTags).Where(x => x.Id == updatePostDto.Id).FirstOrDefaultAsync() ?? throw new Exception("找不到對應的文章");
                var changeRecord = await GetChangeRecords(entity.Title, updatePostDto.Title, entity.Content, updatePostDto.Content, [.. entity.PostsTags.Select(x => x.Tag)], updatePostDto?.Tags);
                var changeRecordEntity = new PostsChangeRecord
                {
                    ChangeRecord = changeRecord,
                    FK_PostsId = entity.Id,
                    CreateDate = DateOnly.FromDateTime(DateTime.Now),
                    CreateUserId = updatePostDto.CreateUserId,
                };
                context.PostsChangeRecords.Add(changeRecordEntity);

                if (entity.PostsTags != null)
                {
                    context.PostsTags.RemoveRange(entity.PostsTags);
                    if (updatePostDto.Tags != null && updatePostDto.Tags.Count != 0)
                    {
                        var tags = new List<PostsTag>();
                        foreach (var tag in updatePostDto.Tags)
                        {
                            tags.Add(new PostsTag
                            {
                                FK_PostsId = updatePostDto.Id,
                                Tag = tag,
                            });
                        }

                        context.PostsTags.AddRange(tags);
                        await context.SaveChangesAsync();
                    }
                }

                mapper.Map(updatePostDto, entity);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
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

        public async Task<string> GetPostAISummary(int id)
        {
            var content = await context.Posts.Where(x => x.Id == id).Select(x => x.Content).FirstOrDefaultAsync() ?? throw new Exception("找不到對應文章");

            var dto = new AiDtoRequest
            {
                Prompt = $"用繁體中文輸出詳細的摘要，只輸出摘要：\n{content}"
            };

            return await ollamaHelper.GetOllamaResponse(dto);
        }

        public async Task<List<string>> GetTags()
        {
            return await context.PostsTags.Select(x => x.Tag).Distinct().ToListAsync();
        }

        private async Task<string> GetChangeRecords(string oldTitle, string newTitle, string oldContent, string newContent, List<string>? oldTags, List<string>? newTags)
        {
            var dto = new AiDtoRequest
            {
                Prompt = $"這是舊文章標題：{oldTitle}，這是修改過後的文章標題：{newTitle}，這是舊文章內容：{oldContent}，這是修改過後的文章標籤：{newContent}，這是舊文章標籤：{oldTags}，這是修改過後的文章內容：{newTags}，請比較後回傳文章的異動說明，請勿添加任何的表情符號，明確表示修改了什麼以及新增異動了什麼"
            };

            return await ollamaHelper.GetOllamaResponse(dto);
        }
    }
}

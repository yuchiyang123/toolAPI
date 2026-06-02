using System.Linq.Dynamic.Core;
using System.Net.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.AI;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Blog;
using blog.Repository;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class PostService(IMapper mapper, BlogContext context, PostRepository repository, BlogCacheService cacheService , OllamaHelper ollamaHelper)
    {
        public async Task<PageResponseDto<PostDto>> GetPostAsync(PostRequestDto requestDto)
        {
            return await repository.GetPost(requestDto).ProjectTo<PostDto>(mapper.ConfigurationProvider).ToPageResponseDto(requestDto.PageIndex, requestDto.PageSize);
        }

        public async Task<PostDetailDto> GetPostDetailAsync(int id)
        {
            return await repository.GetPostDetail().ProjectTo<PostDetailDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception("找不到對應的文章");
        }

        public async Task CreatePostAsync(CreatePostDto postDto)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var entity = mapper.Map<Posts>(postDto);
                context.Posts.Add(entity);
                await context.SaveChangesAsync();
                if (postDto.Tags != null && postDto.Tags.Count > 0)
                {
                    var tag = ConvertPostsTags(postDto.Tags);
                    context.PostsTags.AddRange(tag);
                    await context.SaveChangesAsync();

                    var tagsIds = tag.Select(x => x.Id).ToList();
                    var tagsMapping = ConvertPostTagMapping(entity.Id, tagsIds);
                    context.PostsTagsMapping.AddRange(tagsMapping);
                    await context.SaveChangesAsync();
                }
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
                var entity = await repository.GetPostTag().FirstOrDefaultAsync(x => x.Id == updatePostDto.Id) 
                    ?? throw new Exception("找不到對應的文章");
                var changeRecord = await GetChangeRecords(entity.Title, updatePostDto.Title, entity.Content, updatePostDto.Content,
                    string.Join(",", entity.PostsTagsMapping.Select(x => x.PostsTag.Tag) ?? []), string.Join(",", updatePostDto.Tags ?? []));
                var changeRecordEntity = new PostsChangeRecord
                {
                    ChangeRecord = changeRecord,
                    FK_PostsId = entity.Id,
                    CreateDate = DateOnly.FromDateTime(DateTime.Now),
                    CreateUserId = updatePostDto.CreateUserId,
                };
                context.PostsChangeRecords.Add(changeRecordEntity);

                if (entity.PostsTagsMapping != null)
                {
                    context.PostsTags.RemoveRange(entity.PostsTagsMapping.Select(x => x.PostsTag));
                    context.PostsTagsMapping.RemoveRange(entity.PostsTagsMapping);

                    if (updatePostDto.Tags != null && updatePostDto.Tags.Count > 0)
                    {
                        var tags = ConvertPostsTags(updatePostDto.Tags);
                        context.PostsTags.AddRange(tags);
                        await context.SaveChangesAsync();

                        var tagsIds = tags.Select(x => x.Id).ToList();
                        var tagsMapping = ConvertPostTagMapping(updatePostDto.Id, tagsIds);

                        context.PostsTagsMapping.AddRange(tagsMapping);
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
            var entity = await repository.GetPostNoIncludeAny().FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception("找不到對應的文章");
            context.Posts.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePostsViewAsync(int id)
        {
            var entity = await repository.GetPostNoIncludeAny().FirstOrDefaultAsync() 
                ?? throw new Exception("找不到對應的文章");
            entity.View += 1;
            await context.SaveChangesAsync();
        }

        public async Task<string> GetPostAISummary(int id)
        {
            var content = await repository.GetPostNoIncludeAny().Where(x => x.Id == id).Select(x => x.Content).FirstOrDefaultAsync() 
                ?? throw new Exception("找不到對應文章");

            var dto = new AiDtoRequest
            {
                Prompt = $"用繁體中文輸出詳細的摘要，只輸出摘要：\n{content}"
            };

            return await ollamaHelper.GetOllamaResponse(dto);
        }

        public async Task<List<string>> GetTags()
        {
            return await repository.GetTags().Select(x => x.PostsTag.Tag).Distinct().ToListAsync();
        }

        private static List<PostsTag> ConvertPostsTags(List<string> tags)
        {
            var tagsEntity = new List<PostsTag>();
            foreach (var tag in tags)
            {
                tagsEntity.Add(new PostsTag
                {
                    Tag = tag
                });
            }
            return tagsEntity;
        }

        private static List<PostsTagMapping> ConvertPostTagMapping(int postId, List<int> tagsIds)
        {
            var postsTagMapping = new List<PostsTagMapping>();
            foreach (var tag in tagsIds)
            {
                postsTagMapping.Add(new PostsTagMapping
                {
                    FK_PostsId = postId,
                    FK_TagId = tag
                });
            }
            return postsTagMapping;
        }

        private async Task<string> GetChangeRecords(string oldTitle, string newTitle, string oldContent, string newContent, string? oldTags, string? newTags)
        {
            var dto = new AiDtoRequest
            {
                Prompt = $"這是舊文章標題：{oldTitle}，這是修改過後的文章標題：{newTitle}，這是舊文章內容：{oldContent}，這是修改過後的文章內容：{newContent}，這是舊文章標籤：{oldTags}，這是修改過後的文章標籤：{newTags}，請比較後回傳文章的異動說明，請勿添加任何的表情符號，明確表示修改了什麼以及新增異動了什麼"
            };

            return await ollamaHelper.GetOllamaResponse(dto);
        }
    }
}

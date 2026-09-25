using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.AI;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Blog;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services
{
    public class PostService(
        IMapper mapper,
        BlogContext context,
        PostRepository repository,
        OllamaHelper ollamaHelper,
        IDistributedCache cache,
        ILogger<PostService> logger,
        Redis.BlogCacheService blogCacheService
    )
    {
        public async Task<PageResponseDto<PostDto>> GetPostAsync(
            PostRequestDto requestDto,
            CancellationToken ct = default
        )
        {
            var filterSHA = PageHelper.ComputeFilterHash(requestDto);
            var page = await repository
                .GetPost(requestDto)
                .ProjectTo<PostDto>(mapper.ConfigurationProvider)
                .ToPageResponseDtoWithCache(
                    requestDto.PageIndex,
                    requestDto.PageSize,
                    PageEnums.PostList,
                    filterSHA,
                    cache,
                    ct: ct
                );

            if (page.Items.Count > 0)
            {
                var viewCounts = await blogCacheService.GetViewCountsAsync(
                    page.Items.Select(x => x.Id)
                );
                foreach (var item in page.Items)
                {
                    if (viewCounts.TryGetValue(item.Id, out var v))
                        item.View = v.ToString();
                }
            }

            return page;
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
                    var tagsIds = await UpsertPostsTagsAsync(postDto.Tags);
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
            var entity = await repository.GetPostTag().FirstAsync(x => x.Id == updatePostDto.Id);

            // 先保留舊值，AI 變更紀錄在 transaction 之外產生，避免 LLM 慢/掛掉阻塞更新
            var oldTitle = entity.Title;
            var oldContent = entity.Content;
            var oldTags = string.Join(
                ",",
                entity.PostsTagsMapping?.Select(x => x.PostsTag.Tag) ?? []
            );
            var newTags = string.Join(",", updatePostDto.Tags ?? []);

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (entity.PostsTagsMapping != null)
                    {
                        // 只移除 mapping，PostsTag 本身保留給其他文章共用
                        context.PostsTagsMapping.RemoveRange(entity.PostsTagsMapping);

                        if (updatePostDto.Tags != null && updatePostDto.Tags.Count > 0)
                        {
                            var tagsIds = await UpsertPostsTagsAsync(updatePostDto.Tags);
                            var tagsMapping = ConvertPostTagMapping(updatePostDto.Id, tagsIds);
                            context.PostsTagsMapping.AddRange(tagsMapping);
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

            // 變更紀錄：失敗只記 log，不影響已完成的更新
            try
            {
                var changeRecord = await GetChangeRecords(
                    oldTitle,
                    updatePostDto.Title,
                    oldContent,
                    updatePostDto.Content,
                    oldTags,
                    newTags
                );
                context.PostsChangeRecords.Add(
                    new PostsChangeRecord
                    {
                        ChangeRecord = changeRecord,
                        FK_PostsId = entity.Id,
                        CreateDate = DateOnly.FromDateTime(DateTime.Now),
                        CreateUserId = updatePostDto.CreateUserId,
                    }
                );
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "寫入文章變更紀錄失敗 PostId={PostId}", entity.Id);
            }
        }

        public async Task DeletePostAsync(int id)
        {
            var entity = await repository.GetPostNoIncludeAny().FirstAsync(x => x.Id == id);
            context.Posts.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePostsViewAsync(int id)
        {
            var entity =
                await repository.GetPostNoIncludeAny().FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("找不到對應的文章");
            entity.View += 1;
            await context.SaveChangesAsync();
        }

        public async Task<string> GetPostAISummary(int id)
        {
            var content =
                await repository
                    .GetPostNoIncludeAny()
                    .Where(x => x.Id == id)
                    .Select(x => x.Content)
                    .FirstOrDefaultAsync()
                ?? throw new Exception("找不到對應文章");

            var dto = new AiDtoRequest
            {
                Prompt = $"用繁體中文輸出詳細的摘要，只輸出摘要：\n{content}",
            };

            return await ollamaHelper.GetOllamaResponse(dto)
                ?? throw new Exception("AI 摘要產生失敗");
        }

        public async Task<List<string>> GetTags()
        {
            return await repository.GetTags().Select(x => x.PostsTag.Tag).Distinct().ToListAsync();
        }

        public async Task<bool> ValidUpdatePostUser(int id, string? userId)
        {
            var postEntity = await context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (postEntity is null || userId is null)
                return false;
            if (postEntity.CreateUserId.ToString() != userId)
                return false;
            return true;
        }

        /// <summary>
        /// 依標籤名稱取得既有 PostsTag，不存在的才新增，回傳全部 Id
        /// </summary>
        private async Task<List<int>> UpsertPostsTagsAsync(List<string> tags)
        {
            var names = tags.Select(t => t.Trim())
                .Where(t => t.Length > 0)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            if (names.Count == 0)
                return [];

            var existing = await context.PostsTags.Where(t => names.Contains(t.Tag)).ToListAsync();
            var existingNames = existing
                .Select(t => t.Tag)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var toAdd = names
                .Where(n => !existingNames.Contains(n))
                .Select(n => new PostsTag { Tag = n, CreateDate = DateTime.Now })
                .ToList();
            if (toAdd.Count > 0)
            {
                context.PostsTags.AddRange(toAdd);
                await context.SaveChangesAsync();
            }

            return [.. existing.Select(t => t.Id), .. toAdd.Select(t => t.Id)];
        }

        private static List<PostsTagMapping> ConvertPostTagMapping(int postId, List<int> tagsIds)
        {
            var postsTagMapping = new List<PostsTagMapping>();
            foreach (var tag in tagsIds)
            {
                postsTagMapping.Add(new PostsTagMapping { FK_PostsId = postId, FK_TagId = tag });
            }
            return postsTagMapping;
        }

        private async Task<string> GetChangeRecords(
            string oldTitle,
            string newTitle,
            string oldContent,
            string newContent,
            string? oldTags,
            string? newTags
        )
        {
            var dto = new AiDtoRequest
            {
                Prompt =
                    $"這是舊文章標題：{oldTitle}，這是修改過後的文章標題：{newTitle}，這是舊文章內容：{oldContent}，這是修改過後的文章內容：{newContent}，這是舊文章標籤：{oldTags}，這是修改過後的文章標籤：{newTags}，請比較後回傳文章的異動說明，請勿添加任何的表情符號，明確表示修改了什麼以及新增異動了什麼",
            };

            return await ollamaHelper.GetOllamaResponse(dto) ?? "（AI 變更紀錄產生失敗）";
        }
    }
}

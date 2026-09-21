using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Recipes;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services
{
    public class RecipeService(
        BlogContext context,
        IMapper mapper,
        IDistributedCache cache,
        FileHelper fileHelper,
        ILogger<RecipeService> logger,
        RecipeRepository repository
    )
    {
        public async Task<PageResponseDto<RecipeResponse>> GetRecipe(
            RecipeQueryDto queryDto,
            CancellationToken ct = default
        )
        {
            var filterSHA = PageHelper.ComputeFilterHash(queryDto);
            return await context
                .Recipe.Include(x => x.RecipeFileMappings)
                    .ThenInclude(x => x.Files)
                .ProjectTo<RecipeResponse>(mapper.ConfigurationProvider)
                .ToPageResponseDtoWithCache(
                    queryDto.PageIndex,
                    queryDto.PageSize,
                    PageEnums.RecipeList,
                    filterSHA,
                    cache,
                    ct: ct
                );
        }

        public async Task<RecipeDetailResponse> GetRecipeDetail(int id)
        {
            return await context
                    .Recipe.ProjectTo<RecipeDetailResponse>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("找不到對應的文章");
        }

        public async Task CreateRecipe(RecipeRequest requestDto)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var recipe = new Recipe
                {
                    RecipeName = requestDto.RecipeName,
                    Amount = requestDto.TotalAmount,
                    CookingTime = requestDto.CookingTime,
                    Complexity = requestDto.Complexity,
                    Description = requestDto.Description,
                    RecipeTagMappings =
                        requestDto
                            .Tags?.Select(x => new RecipeTagMapping
                            {
                                RecipeTag = new RecipeTag { Tag = x.Tag },
                            })
                            .ToList()
                        ?? [],
                    RecipeDetailMappings = new RecipeDetailMapping
                    {
                        RecipeDetail = new RecipeDetail { Content = requestDto.Content },
                    },
                    RecipeIngredientsMappings =
                        requestDto
                            .Ingredients?.Select(x => new RecipeIngredientsMapping
                            {
                                RecipeIngredients = new RecipeIngredients
                                {
                                    IngredientsGroupName = x.IngredientsGroupName,
                                    RecipeIngredientsDetailMappings =
                                    [
                                        .. x.IngredientsDetails.Select(
                                            y => new RecipeIngredientsDetailMapping
                                            {
                                                RecipeIngredientsDetail =
                                                    new RecipeIngredientsDetail
                                                    {
                                                        IngredientsName = y.IngredientsName,
                                                        Amount = y.Amount,
                                                    },
                                            }
                                        ),
                                    ],
                                },
                            })
                            .ToList()
                        ?? [],
                    RecipeStepMappings =
                        requestDto
                            .Steps.Select(x => new RecipeStepMapping
                            {
                                RecipeStep = new RecipeStep
                                {
                                    Step = x.Step,
                                    Description = x.Description,
                                },
                            })
                            .ToList()
                        ?? [],
                };

                if (requestDto.MailImage != null)
                {
                    int fileId = await fileHelper.SaveFileAsync(requestDto.MailImage);
                    recipe.RecipeFileMappings = new RecipeFileMapping { FileId = fileId };
                }

                context.Recipe.Add(recipe);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("儲存錯誤，錯誤訊息：{ex}", ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateRecipe(int id, RecipeRequest requestDto)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var exist =
                    await repository.GetRecipes().FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new KeyNotFoundException("找不到對應的食譜");

                // 子集合改用 diff：既有 row 原地更新、缺的新增、多的刪除。
                // 原本 Clear() 後整批重建，每次更新都換掉所有子表 id，
                // 而且舊的 RecipeTag / RecipeStep / RecipeIngredients 會變成孤兒留在 DB。
                SyncTags(exist, requestDto.Tags ?? []);
                SyncSteps(exist, requestDto.Steps ?? []);
                SyncIngredients(exist, requestDto.Ingredients ?? []);

                if (requestDto.Content != null)
                    exist.RecipeDetailMappings.RecipeDetail.Content = requestDto.Content;

                int? deleteFileid = null;
                if (requestDto.MailImage != null)
                {
                    if (exist.RecipeFileMappings != null)
                    {
                        deleteFileid = exist.RecipeFileMappings.FileId;
                        context.RecipeFileMappings.Remove(exist.RecipeFileMappings);
                    }
                    int fileId = await fileHelper.SaveFileAsync(requestDto.MailImage);
                    exist.RecipeFileMappings = new RecipeFileMapping { FileId = fileId };
                }

                exist.RecipeName = requestDto.RecipeName;
                exist.Amount = requestDto.TotalAmount;
                exist.CookingTime = requestDto.CookingTime;
                exist.Complexity = requestDto.Complexity;
                exist.Description = requestDto.Description;
                exist.UpdateDate = DateTime.Now;

                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                if (deleteFileid.HasValue)
                    await fileHelper.DeleteFileAsync(deleteFileid.Value);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// 標籤依名稱 diff：同名保留、缺的新增、多的連同 RecipeTag 一起刪除。
        /// </summary>
        private void SyncTags(Recipe exist, List<Tags> incoming)
        {
            var wanted = incoming
                .Select(x => x.Tag.Trim())
                .Where(x => x.Length > 0)
                .ToHashSet(StringComparer.Ordinal);

            foreach (var mapping in exist.RecipeTagMappings.ToList())
            {
                if (wanted.Remove(mapping.RecipeTag.Tag))
                    continue;
                exist.RecipeTagMappings.Remove(mapping);
                context.RecipeTags.Remove(mapping.RecipeTag);
            }

            foreach (var tag in wanted)
            {
                exist.RecipeTagMappings.Add(
                    new RecipeTagMapping { RecipeTag = new RecipeTag { Tag = tag } }
                );
            }
        }

        /// <summary>
        /// 步驟依順序 index 對齊：既有 row 原地更新、多的新增、少的刪除。
        /// </summary>
        private void SyncSteps(Recipe exist, List<Steps> incoming)
        {
            var current = exist.RecipeStepMappings.OrderBy(x => x.RecipeStep.Step).ToList();

            for (int i = 0; i < incoming.Count; i++)
            {
                if (i < current.Count)
                {
                    current[i].RecipeStep.Step = incoming[i].Step;
                    current[i].RecipeStep.Description = incoming[i].Description;
                    continue;
                }
                exist.RecipeStepMappings.Add(
                    new RecipeStepMapping
                    {
                        RecipeStep = new RecipeStep
                        {
                            Step = incoming[i].Step,
                            Description = incoming[i].Description,
                        },
                    }
                );
            }

            foreach (var extra in current.Skip(incoming.Count))
            {
                exist.RecipeStepMappings.Remove(extra);
                context.RecipeSteps.Remove(extra.RecipeStep);
            }
        }

        /// <summary>
        /// 食材群組依順序 index 對齊，群組內的明細同樣依 index 對齊。
        /// </summary>
        private void SyncIngredients(Recipe exist, List<Ingredients> incoming)
        {
            var current = exist.RecipeIngredientsMappings.ToList();

            for (int i = 0; i < incoming.Count; i++)
            {
                if (i < current.Count)
                {
                    var group = current[i].RecipeIngredients;
                    group.IngredientsGroupName = incoming[i].IngredientsGroupName;
                    SyncIngredientDetails(group, incoming[i].IngredientsDetails ?? []);
                    continue;
                }
                exist.RecipeIngredientsMappings.Add(
                    new RecipeIngredientsMapping
                    {
                        RecipeIngredients = new RecipeIngredients
                        {
                            IngredientsGroupName = incoming[i].IngredientsGroupName,
                            RecipeIngredientsDetailMappings =
                            [
                                .. (incoming[i].IngredientsDetails ?? []).Select(
                                    x => new RecipeIngredientsDetailMapping
                                    {
                                        RecipeIngredientsDetail = new RecipeIngredientsDetail
                                        {
                                            IngredientsName = x.IngredientsName,
                                            Amount = x.Amount,
                                        },
                                    }
                                ),
                            ],
                        },
                    }
                );
            }

            foreach (var extra in current.Skip(incoming.Count))
            {
                foreach (var detail in extra.RecipeIngredients.RecipeIngredientsDetailMappings)
                    context.RecipeIngredientsDetails.Remove(detail.RecipeIngredientsDetail);
                exist.RecipeIngredientsMappings.Remove(extra);
                context.RecipeIngredients.Remove(extra.RecipeIngredients);
            }
        }

        private void SyncIngredientDetails(
            RecipeIngredients group,
            List<IngredientsDetail> incoming
        )
        {
            var current = group.RecipeIngredientsDetailMappings.ToList();

            for (int i = 0; i < incoming.Count; i++)
            {
                if (i < current.Count)
                {
                    current[i].RecipeIngredientsDetail.IngredientsName = incoming[
                        i
                    ].IngredientsName;
                    current[i].RecipeIngredientsDetail.Amount = incoming[i].Amount;
                    continue;
                }
                group.RecipeIngredientsDetailMappings.Add(
                    new RecipeIngredientsDetailMapping
                    {
                        RecipeIngredientsDetail = new RecipeIngredientsDetail
                        {
                            IngredientsName = incoming[i].IngredientsName,
                            Amount = incoming[i].Amount,
                        },
                    }
                );
            }

            foreach (var extra in current.Skip(incoming.Count))
            {
                group.RecipeIngredientsDetailMappings.Remove(extra);
                context.RecipeIngredientsDetails.Remove(extra.RecipeIngredientsDetail);
            }
        }

        public async Task DeleteRecipe(int id)
        {
            var entity =
                await context.Recipe.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("找不到對應的文章");
            context.Recipe.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Recipes;
using blog.Repository;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class RecipeService(BlogContext context, IMapper mapper, FileHelper fileHelper, ILogger<RecipeService> logger, RecipeRepository repository)
    {
        public async Task<PageResponseDto<RecipeResponse>> GetRecipe(RecipeQueryDto queryDto)
        {
            return await context.Recipe.Include(x => x.RecipeFileMappings).ThenInclude(x => x.Files)
                .ProjectTo<RecipeResponse>(mapper.ConfigurationProvider).ToPageResponseDto(queryDto.PageIndex, queryDto.PageSize);
        }

        public async Task<RecipeDetailResponse> GetRecipeDetail(int id)
        {
            return await context.Recipe.ProjectTo<RecipeDetailResponse>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("找不到對應的文章");
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
                    RecipeTagMappings = requestDto.Tags?.Select(x => new RecipeTagMapping
                    {
                        RecipeTag = new RecipeTag
                        {
                            Tag = x.Tag,
                        }
                    }).ToList() ?? [],
                    RecipeDetailMappings = new RecipeDetailMapping
                    {
                        RecipeDetail = new RecipeDetail
                        {
                            Content = requestDto.Content,
                        }
                    },
                    RecipeIngredientsMappings = requestDto.Ingredients?.Select(x => new RecipeIngredientsMapping
                    {
                        RecipeIngredients = new RecipeIngredients
                        {
                            IngredientsGroupName = x.IngredientsGroupName,
                            RecipeIngredientsDetailMappings = [.. x.IngredientsDetails.Select(y => new RecipeIngredientsDetailMapping
                            {
                                RecipeIngredientsDetail = new RecipeIngredientsDetail
                                {
                                    IngredientsName = y.IngredientsName,
                                    Amount = y.Amount,
                                }
                            })]
                        }
                    }).ToList() ?? [],
                    RecipeStepMappings = requestDto.Steps.Select(x => new RecipeStepMapping
                    {
                        RecipeStep = new RecipeStep
                        {
                            Step = x.Step,
                            Description = x.Description,
                        }
                    }).ToList() ?? [],
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
                var exist = await repository.GetRecipes().FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("找不到對應的食譜");

                exist.RecipeTagMappings.Clear();
                if (requestDto.Tags != null && requestDto.Tags.Count != 0)
                {
                    foreach (var tag in requestDto.Tags)
                    {
                        exist.RecipeTagMappings.Add(new RecipeTagMapping
                        {
                            RecipeTag = new RecipeTag
                            {
                                Tag = tag.Tag
                            }
                        });
                    }
                }

                exist.RecipeStepMappings.Clear();
                if (requestDto.Steps != null && requestDto.Steps.Count != 0)
                {
                    foreach (var step in requestDto.Steps)
                    {
                        exist.RecipeStepMappings.Add(new RecipeStepMapping
                        {
                            RecipeStep = new RecipeStep
                            {
                                Step = step.Step,
                                Description = step.Description,
                            }
                        });
                    }
                }

                if(requestDto.Content != null)
                    exist.RecipeDetailMappings.RecipeDetail.Content = requestDto.Content;

                exist.RecipeIngredientsMappings.Clear();
                if (requestDto.Ingredients != null && requestDto.Ingredients.Count != 0)
                {
                    foreach (var ingredients in requestDto.Ingredients)
                    {
                        exist.RecipeIngredientsMappings.Add(new RecipeIngredientsMapping
                        {
                            RecipeIngredients = new RecipeIngredients
                            {
                                IngredientsGroupName = ingredients.IngredientsGroupName,
                                RecipeIngredientsDetailMappings = [.. ingredients.IngredientsDetails.Select(x => new RecipeIngredientsDetailMapping
                                {
                                    RecipeIngredientsDetail = new RecipeIngredientsDetail
                                    {
                                        IngredientsName = x.IngredientsName,
                                        Amount = x.Amount,
                                    }
                                })],
                            }
                        });
                    }
                }

                int? deleteFileid = null;
                if (exist.RecipeFileMappings != null)
                {
                   context.RecipeFileMappings.Remove(exist.RecipeFileMappings);
                    deleteFileid = exist.RecipeFileMappings.FileId;
                }

                if (requestDto.MailImage != null)
                {
                    int fileId = await fileHelper.SaveFileAsync(requestDto.MailImage);
                    exist.RecipeFileMappings = new RecipeFileMapping
                    {
                        FileId = fileId,
                    };
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

        public async Task DeleteRecipe(int id)
        {
            var entity = await context.Recipe.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("找不到對應的文章");
            context.Recipe.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

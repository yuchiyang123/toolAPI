using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Recipes;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

                context.RecipeTags.RemoveRange(exist.RecipeTagMappings.Select(x => x.RecipeTag));
                if (requestDto.Tags != null && requestDto.Tags.Count != 0)
                {
                    foreach (var tag in requestDto.Tags)
                    {
                        var entityTag = new RecipeTag
                        {
                            Tag = tag.Tag
                        };
                        context.RecipeTags.Add(entityTag);
                        await context.SaveChangesAsync();

                        var tagMapping = new RecipeTagMapping
                        {
                            RecipeId = id,
                            RecipeTagId = entityTag.Id
                        };

                        context.RecipeTagMappings.Add(tagMapping);
                        await context.SaveChangesAsync();
                    }
                }

                context.RecipeSteps.RemoveRange(exist.RecipeStepMappings.Select(x => x.RecipeStep));
                if (requestDto.Steps != null && requestDto.Steps.Count != 0)
                {
                    foreach (var step in requestDto.Steps)
                    {
                        var entitySteps = new RecipeStep
                        {
                            Step = step.Step,
                            Description = step.Description,
                        };

                        context.RecipeSteps.Add(entitySteps);
                        await context.SaveChangesAsync();

                        var stepMapping = new RecipeStepMapping
                        {
                            RecipeId = id,
                            RecipeStepId = entitySteps.Id
                        };

                        context.RecipeStepMappings.Add(stepMapping);
                        await context.SaveChangesAsync();
                    }
                }

                context.RecipeDetails.Remove(exist.RecipeDetailMappings.RecipeDetail);
                if (requestDto.Content != null)
                {
                    var entityDetail = new RecipeDetail
                    {
                        Content = requestDto.Content,
                    };

                    context.RecipeDetails.Add(entityDetail);
                    await context.SaveChangesAsync();

                    var detailMapping = new RecipeDetailMapping
                    {
                        RecipeId = id,
                        RecipeDetailId = entityDetail.Id
                    };

                    context.RecipeDetailsMapping.Add(detailMapping);
                    await context.SaveChangesAsync();
                }

                context.RecipeIngredients.RemoveRange(exist.RecipeIngredientsMappings.Select(x => x.RecipeIngredients));
                if (requestDto.Ingredients != null && requestDto.Ingredients.Count != 0)
                {
                    foreach (var ingredients in requestDto.Ingredients)
                    {
                        var entityIngredients = new RecipeIngredients
                        {
                            IngredientsGroupName = ingredients.IngredientsGroupName
                        };
                        context.RecipeIngredients.Add(entityIngredients);
                        await context.SaveChangesAsync();

                        var entityIngredientsMapping = new RecipeIngredientsMapping
                        {
                            RecipeId = id,
                            RecipeIngredientsId = entityIngredients.Id
                        };
                        context.RecipeIngredientsMappings.Add(entityIngredientsMapping);

                        foreach (var ingredientsDetails in ingredients.IngredientsDetails)
                        {
                            var entityIngredientsDetails = new RecipeIngredientsDetail
                            {
                                IngredientsName = ingredientsDetails.IngredientsName,
                                Amount = ingredientsDetails.Amount,
                            };
                            context.RecipeIngredientsDetails.Add(entityIngredientsDetails);
                            await context.SaveChangesAsync();

                            var entityIngredientsDetailsMapping = new RecipeIngredientsDetailMapping
                            {
                                RecipeIngredientId = entityIngredients.Id,
                                RecipeIngredientDetailId = entityIngredientsDetails.Id
                            };
                            context.RecipeIngredientsDetailMappings.Add(entityIngredientsDetailsMapping);
                        }

                        await context.SaveChangesAsync();
                    }
                }

                if(exist.RecipeFileMappings != null)
                    await fileHelper.DeleteFileAsync(exist.RecipeFileMappings.FileId);
                if (requestDto.MailImage != null)
                {
                    int fileId = await fileHelper.SaveFileAsync(requestDto.MailImage);
                    var fileMapping = new RecipeFileMapping
                    {
                        RecipeId = id,
                        FileId = fileId,
                    };

                    context.RecipeFileMappings.Add(fileMapping);
                }

                exist.RecipeName = requestDto.RecipeName;
                exist.Amount = requestDto.TotalAmount;
                exist.CookingTime = requestDto.CookingTime;
                exist.Complexity = requestDto.Complexity;
                exist.Description = requestDto.Description;
                exist.UpdateDate = DateTime.Now;

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
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

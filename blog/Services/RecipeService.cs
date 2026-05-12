using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace blog.Services
{
    public class RecipeService(BlogContext context, IMapper mapper, FileHelper fileHelper, ILogger<RecipeService> logger)
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
                logger.LogError("儲存錯誤，錯誤訊息：{0}", ex.Message);
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

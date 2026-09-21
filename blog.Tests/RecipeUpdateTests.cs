using blog.Common.Helper;
using blog.Dtos;
using blog.Entities;
using blog.Entities.Recipes;
using blog.Repository;
using blog.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace blog.Tests;

/// <summary>
/// B31：UpdateRecipe 改為 diff 更新後，既有子表 row 的 id 必須保留、
/// 多出來的 row 要連同葉節點一起刪除、少的要新增。
/// </summary>
public class RecipeUpdateTests
{
    private static BlogContext CreateContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<BlogContext>()
            .UseInMemoryDatabase(dbName)
            .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;
        return new BlogContext(options);
    }

    private static RecipeService CreateService(BlogContext context)
    {
        var mockConfig = new Mock<IConfiguration>();
        var fileHelper = new Mock<FileHelper>(context, mockConfig.Object);
        IDistributedCache cache = new MemoryDistributedCache(
            Microsoft.Extensions.Options.Options.Create(new MemoryDistributedCacheOptions())
        );
        return new RecipeService(
            context,
            new Mock<AutoMapper.IMapper>().Object,
            cache,
            fileHelper.Object,
            new Mock<ILogger<RecipeService>>().Object,
            new RecipeRepository(context)
        );
    }

    private static async Task<Recipe> SeedRecipe(BlogContext context)
    {
        var recipe = new Recipe
        {
            RecipeName = "old",
            Amount = 1,
            CookingTime = 10,
            Complexity = 1,
            RecipeDetailMappings = new RecipeDetailMapping
            {
                RecipeDetail = new RecipeDetail { Content = "old content" },
            },
            RecipeTagMappings =
            [
                new() { RecipeTag = new RecipeTag { Tag = "keep" } },
                new() { RecipeTag = new RecipeTag { Tag = "drop" } },
            ],
            RecipeStepMappings =
            [
                new()
                {
                    RecipeStep = new RecipeStep { Step = 1, Description = "s1" },
                },
                new()
                {
                    RecipeStep = new RecipeStep { Step = 2, Description = "s2" },
                },
                new()
                {
                    RecipeStep = new RecipeStep { Step = 3, Description = "s3" },
                },
            ],
            RecipeIngredientsMappings =
            [
                new()
                {
                    RecipeIngredients = new RecipeIngredients
                    {
                        IngredientsGroupName = "g1",
                        RecipeIngredientsDetailMappings =
                        [
                            new()
                            {
                                RecipeIngredientsDetail = new RecipeIngredientsDetail
                                {
                                    IngredientsName = "salt",
                                    Amount = "1 tsp",
                                },
                            },
                        ],
                    },
                },
            ],
        };
        context.Recipe.Add(recipe);
        await context.SaveChangesAsync();
        return recipe;
    }

    private static RecipeRequest BuildRequest() =>
        new()
        {
            RecipeName = "new",
            CookingTime = 20,
            Complexity = 3,
            TotalAmount = 4,
            Description = "desc",
            Content = "new content",
            Tags = [new Tags { Tag = "keep" }, new Tags { Tag = "added" }],
            Steps =
            [
                new Steps { Step = 1, Description = "s1 edited" },
                new Steps { Step = 2, Description = "s2" },
            ],
            Ingredients =
            [
                new Ingredients
                {
                    IngredientsGroupName = "g1 renamed",
                    IngredientsDetails =
                    [
                        new IngredientsDetail { IngredientsName = "salt", Amount = "2 tsp" },
                        new IngredientsDetail { IngredientsName = "pepper", Amount = "1 tsp" },
                    ],
                },
            ],
        };

    [Fact]
    public async Task UpdateRecipe_PreservesExistingIds_AndDiffsChildren()
    {
        var db = Guid.NewGuid().ToString();
        using var context = CreateContext(db);
        var seeded = await SeedRecipe(context);
        var keepTagId = seeded.RecipeTagMappings.First(x => x.RecipeTag.Tag == "keep").RecipeTag.Id;
        var step1Id = seeded.RecipeStepMappings.First(x => x.RecipeStep.Step == 1).RecipeStep.Id;
        var groupId = seeded.RecipeIngredientsMappings.First().RecipeIngredients.Id;
        var saltId = seeded
            .RecipeIngredientsMappings.First()
            .RecipeIngredients.RecipeIngredientsDetailMappings.First()
            .RecipeIngredientsDetail.Id;

        var service = CreateService(context);
        await service.UpdateRecipe(seeded.Id, BuildRequest());

        using var verify = CreateContext(db);
        var recipe = await new RecipeRepository(verify).GetRecipes().SingleAsync();

        Assert.Equal("new", recipe.RecipeName);
        Assert.Equal("new content", recipe.RecipeDetailMappings.RecipeDetail.Content);

        // tags: keep 保留同一個 id、drop 刪掉、added 新增；RecipeTag 表無孤兒
        var tags = recipe.RecipeTagMappings.Select(x => x.RecipeTag).ToList();
        Assert.Equal(["added", "keep"], tags.Select(x => x.Tag).OrderBy(x => x));
        Assert.Contains(tags, x => x.Id == keepTagId);
        Assert.Equal(2, await verify.RecipeTags.CountAsync());

        // steps: 第 1 步原地更新（id 不變）、第 3 步刪除
        var steps = recipe
            .RecipeStepMappings.Select(x => x.RecipeStep)
            .OrderBy(x => x.Step)
            .ToList();
        Assert.Equal(2, steps.Count);
        Assert.Equal(step1Id, steps[0].Id);
        Assert.Equal("s1 edited", steps[0].Description);
        Assert.Equal(2, await verify.RecipeSteps.CountAsync());

        // ingredients: 群組原地更新、明細 salt 原地更新、pepper 新增
        var group = recipe.RecipeIngredientsMappings.Single().RecipeIngredients;
        Assert.Equal(groupId, group.Id);
        Assert.Equal("g1 renamed", group.IngredientsGroupName);
        var details = group
            .RecipeIngredientsDetailMappings.Select(x => x.RecipeIngredientsDetail)
            .ToList();
        Assert.Equal(2, details.Count);
        Assert.Contains(details, x => x.Id == saltId && x.Amount == "2 tsp");
        Assert.Contains(details, x => x.IngredientsName == "pepper");
    }

    [Fact]
    public async Task UpdateRecipe_RemovingAllChildren_DeletesLeafRows()
    {
        var db = Guid.NewGuid().ToString();
        using var context = CreateContext(db);
        var seeded = await SeedRecipe(context);
        var request = new RecipeRequest
        {
            RecipeName = "bare",
            CookingTime = 1,
            TotalAmount = 1,
            Description = "",
            Content = "x",
            Tags = [],
            Steps = [],
            Ingredients = [],
        };

        await CreateService(context).UpdateRecipe(seeded.Id, request);

        using var verify = CreateContext(db);
        Assert.Equal(0, await verify.RecipeTags.CountAsync());
        Assert.Equal(0, await verify.RecipeSteps.CountAsync());
        Assert.Equal(0, await verify.RecipeIngredients.CountAsync());
        Assert.Equal(0, await verify.RecipeIngredientsDetails.CountAsync());
    }

    [Fact]
    public async Task UpdateRecipe_NotFound_ThrowsKeyNotFound()
    {
        var db = Guid.NewGuid().ToString();
        using var context = CreateContext(db);
        await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            CreateService(context).UpdateRecipe(999, BuildRequest())
        );
    }
}

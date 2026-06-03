using blog.Common.Helper;
using blog.Entities;
using blog.Entities.Recipes;
using blog.Repository;
using blog.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace blog.Tests;

public class RecipeServiceTests
{
    private BlogContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<BlogContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new BlogContext(options);
    }

    private RecipeService CreateService(BlogContext context)
    {
        var mockMapper = new Mock<AutoMapper.IMapper>();
        var mockConfig = new Mock<IConfiguration>();
        var mockLogger = new Mock<ILogger<RecipeService>>();
        var mockFileHelper = new Mock<FileHelper>(context, mockConfig.Object);
        var repository = new RecipeRepository(context);
        return new RecipeService(
            context,
            mockMapper.Object,
            mockFileHelper.Object,
            mockLogger.Object,
            repository
        );
    }

    [Fact]
    public async Task DeleteRecipe_NotFound_ThrowsException()
    {
        using var context = CreateInMemoryContext();
        var service = CreateService(context);

        await Assert.ThrowsAsync<Exception>(() => service.DeleteRecipe(999));
    }

    [Fact]
    public async Task DeleteRecipe_Found_RemovesEntity()
    {
        using var context = CreateInMemoryContext();
        context.Recipe.Add(new Recipe { Id = 1, RecipeName = "test", Amount = 1, CookingTime = 10, Complexity = 1 });
        await context.SaveChangesAsync();

        var service = CreateService(context);
        await service.DeleteRecipe(1);

        var result = await context.Recipe.FirstOrDefaultAsync(x => x.Id == 1);
        Assert.Null(result);
    }
}
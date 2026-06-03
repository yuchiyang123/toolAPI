using blog.Common.Helper;
using blog.Entities;
using blog.Entities.Blog;
using blog.Entities.User;
using blog.Repository;
using blog.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace blog.Tests;

public class PostServiceTests
{
    private BlogContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<BlogContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new BlogContext(options);
    }

    private PostService CreateService(BlogContext context)
    {
        var mockMapper = new Mock<AutoMapper.IMapper>();
        var mockConfig = new Mock<IConfiguration>();
        var mockHttp = new Mock<HttpClient>();
        var ollamaHelper = new OllamaHelper(mockConfig.Object, mockHttp.Object);
        var repository = new PostRepository(context);
        return new PostService(mockMapper.Object, context, repository, ollamaHelper);
    }

    [Fact]
    public async Task ValidUpdatePostUser_PostNotFound_ReturnsFalse()
    {
        using var context = CreateInMemoryContext();
        var service = CreateService(context);

        var result = await service.ValidUpdatePostUser(999, "1");

        Assert.False(result);
    }

    [Fact]
    public async Task ValidUpdatePostUser_UserIdIsNull_ReturnsFalse()
    {
        using var context = CreateInMemoryContext();
        var post = new Posts { Id = 1, Title = "t", Content = "c", CreateUserId = 1 };
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        var service = CreateService(context);
        var result = await service.ValidUpdatePostUser(1, null);

        Assert.False(result);
    }

    [Fact]
    public async Task ValidUpdatePostUser_WrongUser_ReturnsFalse()
    {
        using var context = CreateInMemoryContext();
        var post = new Posts { Id = 1, Title = "t", Content = "c", CreateUserId = 1 };
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        var service = CreateService(context);
        var result = await service.ValidUpdatePostUser(1, "999");

        Assert.False(result);
    }

    [Fact]
    public async Task ValidUpdatePostUser_CorrectUser_ReturnsTrue()
    {
        using var context = CreateInMemoryContext();
        var post = new Posts { Id = 1, Title = "t", Content = "c", CreateUserId = 1 };
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        var service = CreateService(context);
        var result = await service.ValidUpdatePostUser(1, "1");

        Assert.True(result);
    }
}
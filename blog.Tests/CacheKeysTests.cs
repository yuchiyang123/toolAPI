using blog.Common.Helper.Key;

namespace blog.Tests;

public class CacheKeysTests
{
    [Fact]
    public void Post_ReturnsCorrectKey()
    {
        var result = CacheKeys.Post(1);
        Assert.Equal("Post:1", result);
    }

    [Theory]
    [InlineData(1, "Post:1")]
    [InlineData(99, "Post:99")]
    [InlineData(0, "Post:0")]
    public void Post_MultipleIds_ReturnsCorrectKey(int id, string expected)
    {
        Assert.Equal(expected, CacheKeys.Post(id));
    }

    [Fact]
    public void LockKey_ReturnsCorrectKey()
    {
        var result = CacheKeys.LockKey("Post:1");
        Assert.Equal("lock:Post:1", result);
    }

    [Fact]
    public void PostSummary_ReturnsCorrectKey()
    {
        var result = CacheKeys.PostSummary(1);
        Assert.Equal("PostSummary:1", result);
    }

    [Fact]
    public void Recipe_ReturnsCorrectKey()
    {
        var result = CacheKeys.Recipe(1);
        Assert.Equal("Recipe:1", result);
    }
}
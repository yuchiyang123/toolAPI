using System.Net;
using System.Net.Http.Json;
using blog.Dtos;
using blog.Dtos.Page;
using Microsoft.EntityFrameworkCore;

namespace blog.Tests.Integration;

public class PostTests : IntegrationTestBase
{
    [Fact]
    public async Task List_ReturnsPagedSeedPost()
    {
        var res = await Client.GetAsync("/api/Post?pageIndex=1&pageSize=10");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);

        var page = await ReadJson<PageResponseDto<PostDto>>(res);
        Assert.Equal(1, page.PageIndex);
        Assert.Equal(10, page.PageSize);
        Assert.Equal(1, page.TotalSize);
        Assert.Equal(1, page.PageTotal);
        Assert.False(page.HasNextPage);
        var item = Assert.Single(page.Items);
        Assert.Equal("seed post", item.Title);
        Assert.Equal(SeedUserName, item.CreateUserName);
        Assert.Contains("seed", item.Tags ?? []);
    }

    [Theory]
    [InlineData("pageIndex=1&pageSize=1000")]
    [InlineData("pageIndex=0&pageSize=10")]
    [InlineData("pageIndex=1&pageSize=0")]
    public async Task List_OutOfRangePaging_Returns400(string query)
    {
        var res = await Client.GetAsync($"/api/Post?{query}");
        Assert.Equal(HttpStatusCode.BadRequest, res.StatusCode);
    }

    [Fact]
    public async Task Detail_Existing_Returns200()
    {
        var res = await Client.GetAsync($"/api/Post/{SeedPostId}");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var dto = await ReadJson<PostDetailDto>(res);
        Assert.Equal(SeedPostId, dto.Id);
        Assert.Equal("seed post", dto.Title);
    }

    [Fact]
    public async Task Detail_Missing_Returns404()
    {
        var res = await Client.GetAsync("/api/Post/999999");
        Assert.Equal(HttpStatusCode.NotFound, res.StatusCode);
    }

    [Fact]
    public async Task Create_WithoutToken_Returns401()
    {
        var res = await Client.PostAsJsonAsync(
            "/api/Post",
            new
            {
                title = "x",
                content = "y",
                createUserId = SeedUserId,
            }
        );
        Assert.Equal(HttpStatusCode.Unauthorized, res.StatusCode);
    }

    [Fact]
    public async Task Create_Update_View_Delete_RoundTrip()
    {
        // create
        var create = await AuthClient.PostAsJsonAsync(
            "/api/Post",
            new
            {
                title = "new post",
                content = "<p>body</p>",
                createUserId = SeedUserId,
                tags = new[] { "seed", "fresh" },
            }
        );
        Assert.Equal(HttpStatusCode.OK, create.StatusCode);

        var id = RunInScope(ctx =>
            ctx.Posts.Where(p => p.Title == "new post").Select(p => p.Id).Single()
        );

        // 標籤 upsert：既有的 "seed" 不重複建立
        var seedTagCount = RunInScope(ctx => ctx.PostsTags.Count(t => t.Tag == "seed"));
        Assert.Equal(1, seedTagCount);

        // list now has 2
        var list = await ReadJson<PageResponseDto<PostDto>>(
            await Client.GetAsync("/api/Post?pageIndex=1&pageSize=10")
        );
        Assert.Equal(2, list.TotalSize);

        // update
        var update = await AuthClient.PutAsJsonAsync(
            "/api/Post",
            new
            {
                id,
                title = "updated title",
                content = "<p>changed</p>",
                createUserId = SeedUserId,
                tags = new[] { "fresh" },
            }
        );
        Assert.Equal(HttpStatusCode.OK, update.StatusCode);
        var detail = await ReadJson<PostDetailDto>(await Client.GetAsync($"/api/Post/{id}"));
        Assert.Equal("updated title", detail.Title);
        Assert.Equal(["fresh"], detail.Tags);

        // view counter
        var view = await Client.PatchAsync($"/api/Post/view/{id}", null);
        Assert.Equal(HttpStatusCode.OK, view.StatusCode);

        // delete by another user → 403
        using (var other = Factory.CreateClient())
        {
            RunInScope(ctx =>
            {
                ctx.Users.Add(
                    new blog.Entities.User.Users
                    {
                        Id = 2,
                        UserName = "other",
                        PasswordHash = "x",
                        CreateDate = DateTime.UtcNow,
                        LogInDate = DateTime.UtcNow,
                    }
                );
                return ctx.SaveChanges();
            });
            other.DefaultRequestHeaders.Authorization = new("Bearer", TokenFor(2));
            var forbidden = await other.DeleteAsync($"/api/Post/{id}");
            Assert.Equal(HttpStatusCode.Forbidden, forbidden.StatusCode);
        }

        // delete by owner
        var del = await AuthClient.DeleteAsync($"/api/Post/{id}");
        Assert.Equal(HttpStatusCode.OK, del.StatusCode);
        Assert.False(RunInScope(ctx => ctx.Posts.Any(p => p.Id == id)));
    }

    [Fact]
    public async Task Update_Missing_Returns403()
    {
        var res = await AuthClient.PutAsJsonAsync(
            "/api/Post",
            new
            {
                id = 999999,
                title = "x",
                content = "y",
                createUserId = SeedUserId,
            }
        );
        Assert.Equal(HttpStatusCode.Forbidden, res.StatusCode);
    }

    [Fact]
    public async Task Tags_ReturnsDistinctTags()
    {
        var res = await Client.GetAsync("/api/Post/tags");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var tags = await ReadJson<List<string>>(res);
        Assert.Equal(["seed"], tags);
    }

    [Fact]
    public async Task Summary_UsesOllamaStub()
    {
        var res = await Client.GetAsync($"/api/Post/{SeedPostId}/summary");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        Assert.Contains("摘要", await res.Content.ReadAsStringAsync());
    }
}

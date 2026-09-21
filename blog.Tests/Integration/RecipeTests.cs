using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using blog.Dtos;
using blog.Dtos.Page;

namespace blog.Tests.Integration;

public class RecipeTests : IntegrationTestBase
{
    // 1x1 PNG
    private static readonly byte[] Png = Convert.FromBase64String(
        "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg=="
    );

    private static MultipartFormDataContent Form(
        string name,
        byte[]? image = null,
        string imageName = "pic.png",
        string imageType = "image/png"
    )
    {
        var form = new MultipartFormDataContent
        {
            { new StringContent(name), "RecipeName" },
            { new StringContent("3"), "TotalAmount" },
            { new StringContent("25"), "CookingTime" },
            { new StringContent("2"), "Complexity" },
            { new StringContent("tasty"), "Description" },
            { new StringContent("<p>how to</p>"), "Content" },
            {
                new StringContent(
                    JsonSerializer.Serialize(
                        new[]
                        {
                            new
                            {
                                ingredientsGroupName = "main",
                                ingredientsDetails = new[]
                                {
                                    new { ingredientsName = "egg", amount = "2" },
                                },
                            },
                        }
                    )
                ),
                "Ingredients"
            },
            {
                new StringContent(
                    JsonSerializer.Serialize(
                        new[]
                        {
                            new { step = 1, description = "crack" },
                            new { step = 2, description = "fry" },
                        }
                    )
                ),
                "Steps"
            },
            { new StringContent(JsonSerializer.Serialize(new[] { new { tag = "egg" } })), "Tags" },
        };
        if (image != null)
        {
            var file = new ByteArrayContent(image);
            file.Headers.ContentType = new MediaTypeHeaderValue(imageType);
            form.Add(file, "MailImage", imageName);
        }
        return form;
    }

    [Fact]
    public async Task List_ReturnsSeedRecipe()
    {
        var res = await Client.GetAsync("/api/Recipe?pageIndex=1&pageSize=10");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var page = await ReadJson<PageResponseDto<RecipeResponse>>(res);
        Assert.Equal(1, page.TotalSize);
        Assert.Equal("seed recipe", page.Items[0].RecipeName);
    }

    [Fact]
    public async Task Detail_ReturnsContentStepsIngredients()
    {
        var res = await Client.GetAsync($"/api/Recipe/{SeedRecipeId}");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var dto = await ReadJson<RecipeDetailResponse>(res);
        Assert.Equal("content", dto.Content);
        Assert.Single(dto.Steps);
        Assert.Equal(2, dto.TotalAmount);
    }

    [Fact]
    public async Task Create_WithoutToken_Returns401()
    {
        var res = await Client.PostAsync("/api/Recipe", Form("nope"));
        Assert.Equal(HttpStatusCode.Unauthorized, res.StatusCode);
    }

    [Fact]
    public async Task Create_WithPng_Update_Delete_RoundTrip()
    {
        var create = await AuthClient.PostAsync("/api/Recipe", Form("omelette", Png));
        Assert.Equal(HttpStatusCode.OK, create.StatusCode);

        var id = RunInScope(ctx =>
            ctx.Recipe.Where(r => r.RecipeName == "omelette").Select(r => r.Id).Single()
        );
        var detail = await ReadJson<RecipeDetailResponse>(
            await Client.GetAsync($"/api/Recipe/{id}")
        );
        Assert.Equal(2, detail.Steps.Count);
        Assert.Single(detail.Ingredients);
        Assert.NotNull(detail.MainImageUrl);
        Assert.EndsWith(".png", detail.MainImageUrl);

        // 檔案真的落地
        var fileCount = RunInScope(ctx => ctx.Files.Count());
        Assert.Equal(1, fileCount);

        // update
        var update = await AuthClient.PutAsync($"/api/Recipe/{id}", Form("omelette v2"));
        Assert.Equal(HttpStatusCode.OK, update.StatusCode);
        var updated = await ReadJson<RecipeDetailResponse>(
            await Client.GetAsync($"/api/Recipe/{id}")
        );
        Assert.Equal("omelette v2", updated.RecipeName);

        // delete
        var del = await AuthClient.DeleteAsync($"/api/Recipe/{id}");
        Assert.Equal(HttpStatusCode.OK, del.StatusCode);
        Assert.False(RunInScope(ctx => ctx.Recipe.Any(r => r.Id == id)));
    }

    [Fact]
    public async Task Create_HtmlUpload_Returns400()
    {
        var res = await AuthClient.PostAsync(
            "/api/Recipe",
            Form("evil", "<script>alert(1)</script>"u8.ToArray(), "evil.html", "text/html")
        );
        Assert.Equal(HttpStatusCode.BadRequest, res.StatusCode);
        Assert.False(RunInScope(ctx => ctx.Recipe.Any(r => r.RecipeName == "evil")));
    }

    [Fact]
    public async Task Create_OversizedImage_Returns400()
    {
        var big = new byte[5 * 1024 * 1024 + 1];
        var res = await AuthClient.PostAsync("/api/Recipe", Form("huge", big));
        Assert.Equal(HttpStatusCode.BadRequest, res.StatusCode);
    }

    [Fact]
    public async Task Update_Missing_Returns404()
    {
        var res = await AuthClient.PutAsync("/api/Recipe/999999", Form("x"));
        Assert.Equal(HttpStatusCode.NotFound, res.StatusCode);
    }
}

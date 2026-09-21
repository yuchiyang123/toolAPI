using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace blog.Tests.Integration;

public class LoginTests : IntegrationTestBase
{
    [Fact]
    public async Task Login_CorrectPassword_ReturnsJwt()
    {
        var res = await Client.PostAsJsonAsync(
            "/api/Login",
            new { userName = SeedUserName, password = SeedPassword }
        );

        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var token = await res.Content.ReadAsStringAsync();
        Assert.Equal(3, token.Trim('"').Split('.').Length); // header.payload.signature
    }

    [Fact]
    public async Task Login_WrongPassword_IsNotSuccess()
    {
        var res = await Client.PostAsJsonAsync(
            "/api/Login",
            new { userName = SeedUserName, password = "nope" }
        );
        Assert.False(res.IsSuccessStatusCode);
    }

    [Fact]
    public async Task Login_UnknownUser_IsNotSuccess()
    {
        var res = await Client.PostAsJsonAsync(
            "/api/Login",
            new { userName = "ghost", password = SeedPassword }
        );
        Assert.False(res.IsSuccessStatusCode);
    }

    [Fact]
    public async Task ValidToken_WithToken_Returns200True()
    {
        var res = await AuthClient.GetAsync("/api/Login/valid/token");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        Assert.Equal("true", await res.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task ValidToken_WithoutToken_Returns401()
    {
        var res = await Client.GetAsync("/api/Login/valid/token");
        Assert.Equal(HttpStatusCode.Unauthorized, res.StatusCode);
    }

    [Fact]
    public async Task ValidToken_TokenForMissingUser_Returns401()
    {
        using var client = Factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            TokenFor(9999)
        );
        var res = await client.GetAsync("/api/Login/valid/token");
        Assert.Equal(HttpStatusCode.Unauthorized, res.StatusCode);
    }

    [Fact]
    public async Task CreateUser_ThenLoginWithIt_Works()
    {
        var create = await AuthClient.PostAsJsonAsync(
            "/api/Login/create",
            new { userName = "newbie", password = "Secret123!" }
        );
        Assert.Equal(HttpStatusCode.OK, create.StatusCode);

        var dup = await AuthClient.PostAsJsonAsync(
            "/api/Login/create",
            new { userName = "newbie", password = "Secret123!" }
        );
        Assert.Equal(HttpStatusCode.BadRequest, dup.StatusCode);

        var login = await Client.PostAsJsonAsync(
            "/api/Login",
            new { userName = "newbie", password = "Secret123!" }
        );
        Assert.Equal(HttpStatusCode.OK, login.StatusCode);
    }
}

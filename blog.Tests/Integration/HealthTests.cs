using System.Net;

namespace blog.Tests.Integration;

public class HealthTests : IntegrationTestBase
{
    [Fact]
    public async Task Healthz_Returns200()
    {
        var res = await Client.GetAsync("/healthz");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
    }

    [Fact]
    public async Task UnknownPost_Returns404ProblemDetails()
    {
        var res = await Client.GetAsync("/api/Judge/999999");
        Assert.Equal(HttpStatusCode.NotFound, res.StatusCode);
        Assert.Contains("application/problem+json", res.Content.Headers.ContentType?.MediaType);
    }
}

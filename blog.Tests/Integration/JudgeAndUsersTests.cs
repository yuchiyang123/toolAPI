using System.Net;
using System.Net.Http.Json;
using blog.Dtos;
using blog.Dtos.Judge;
using blog.Dtos.Page;
using Moq;
using RabbitMQ.Client;

namespace blog.Tests.Integration;

public class JudgeTests : IntegrationTestBase
{
    [Fact]
    public async Task List_ReturnsSeedProblemWithTags()
    {
        var res = await Client.GetAsync("/api/Judge?pageIndex=1&pageSize=10");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var page = await ReadJson<PageResponseDto<ProblemsList>>(res);
        var p = Assert.Single(page.Items);
        Assert.Equal("seed problem", p.Name);
        Assert.Contains("math", p.Tags ?? []);
    }

    [Fact]
    public async Task Detail_ReturnsStartCodeAndTestCases()
    {
        var res = await Client.GetAsync($"/api/Judge/{SeedProblemId}");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var dto = await ReadJson<ProblemDetail>(res);
        Assert.Equal("add two numbers", dto.Description);
        var start = Assert.Single(dto.StartCodes);
        Assert.Contains("def add(a,b):", start.StartCode);
        var tc = Assert.Single(dto.TestCases!);
        Assert.Equal("1,2", tc.Input);
        Assert.Equal("3", tc.Output);
    }

    [Fact]
    public async Task Detail_Missing_Returns404()
    {
        var res = await Client.GetAsync("/api/Judge/999999");
        Assert.Equal(HttpStatusCode.NotFound, res.StatusCode);
    }

    [Fact]
    public async Task Submit_PublishesToJudgeQueue_Returns202()
    {
        var res = await Client.PostAsJsonAsync(
            "/api/Judge/id",
            new
            {
                id = SeedProblemId,
                language = "python",
                code = "def add(a,b): return a+b",
                connectId = "conn-1",
            }
        );
        Assert.Equal(HttpStatusCode.Accepted, res.StatusCode);
        Factory.Channel.Verify(
            c =>
                c.BasicPublishAsync(
                    "",
                    "judge.judge",
                    false,
                    It.IsAny<BasicProperties>(),
                    It.IsAny<ReadOnlyMemory<byte>>(),
                    It.IsAny<CancellationToken>()
                ),
            Times.Once
        );
    }

    [Fact]
    public async Task SubmitTest_PublishesToTestQueue_Returns202()
    {
        var res = await Client.PostAsJsonAsync(
            "/api/Judge/id/test",
            new
            {
                id = SeedProblemId,
                language = "python",
                code = "def add(a,b): return a+b",
                connectId = "conn-1",
                testCases = new[]
                {
                    new
                    {
                        id = 1,
                        input = """{"a":5,"b":6}""",
                        output = "11",
                    },
                },
            }
        );
        Assert.Equal(HttpStatusCode.Accepted, res.StatusCode);
        Factory.Channel.Verify(
            c =>
                c.BasicPublishAsync(
                    "",
                    "judgeTest.judge",
                    false,
                    It.IsAny<BasicProperties>(),
                    It.IsAny<ReadOnlyMemory<byte>>(),
                    It.IsAny<CancellationToken>()
                ),
            Times.Once
        );
    }

    [Fact]
    public async Task Submit_InvalidLanguage_Returns400()
    {
        var res = await Client.PostAsJsonAsync(
            "/api/Judge/id",
            new
            {
                id = SeedProblemId,
                language = "cobol",
                code = "x",
                connectId = "c",
            }
        );
        Assert.Equal(HttpStatusCode.BadRequest, res.StatusCode);
    }
}

public class UsersTests : IntegrationTestBase
{
    [Fact]
    public async Task Dropdown_DoesNotLeakPasswordHash()
    {
        var res = await Client.GetAsync("/api/Users/dropdown");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var body = await res.Content.ReadAsStringAsync();
        Assert.DoesNotContain("passwordHash", body, StringComparison.OrdinalIgnoreCase);
        var items = await ReadJson<List<DropDownListDto>>(res);
        Assert.Contains(items, i => i.Label == SeedUserName && i.Id == SeedUserId.ToString());
    }
}

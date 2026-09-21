using System.Net;
using System.Net.Http.Json;
using blog.Dtos;
using blog.Dtos.Flow;
using blog.Dtos.Page;

namespace blog.Tests.Integration;

public class FlowTests : IntegrationTestBase
{
    [Fact]
    public async Task List_ReturnsSeedFlowWithVersions()
    {
        var res = await Client.GetAsync("/api/Flow/list?pageIndex=1&pageSize=10");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var page = await ReadJson<PageResponseDto<FlowList>>(res);
        var flow = Assert.Single(page.Items);
        Assert.Equal("seed flow", flow.FlowName);
        Assert.Equal(SeedUserName, flow.CreateUserData.Name);
        Assert.Single(flow.FlowVersionList);
    }

    [Fact]
    public async Task List_FilterByName_NoMatch_ReturnsEmpty()
    {
        var page = await ReadJson<PageResponseDto<FlowList>>(
            await Client.GetAsync("/api/Flow/list?pageIndex=1&pageSize=10&flowName=zzz")
        );
        Assert.Empty(page.Items);
    }

    [Fact]
    public async Task Dropdown_ReturnsSeedFlow()
    {
        var res = await Client.GetAsync("/api/Flow/list/dropdown");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var items = await ReadJson<List<DropDownListDto>>(res);
        Assert.Contains(items, i => i.Label == "seed flow");
    }

    [Fact]
    public async Task Detail_Missing_Returns404()
    {
        var res = await Client.GetAsync("/api/Flow/999999");
        Assert.Equal(HttpStatusCode.NotFound, res.StatusCode);
    }

    [Fact]
    public async Task Create_WithoutToken_Returns401()
    {
        var res = await Client.PostAsJsonAsync("/api/Flow", new { flowName = "x" });
        Assert.Equal(HttpStatusCode.Unauthorized, res.StatusCode);
    }

    [Fact]
    public async Task Create_AddDetail_Get_Delete_RoundTrip()
    {
        var create = await AuthClient.PostAsJsonAsync(
            "/api/Flow",
            new { flowName = "approval", description = "leave approval" }
        );
        Assert.Equal(HttpStatusCode.OK, create.StatusCode);
        var flowId = RunInScope(ctx =>
            ctx.Flows.Where(f => f.Name == "approval").Select(f => f.Id).Single()
        );

        var start = Guid.NewGuid();
        var end = Guid.NewGuid();
        var detail = await AuthClient.PostAsJsonAsync(
            "/api/Flow/detail",
            new
            {
                flowId,
                flowVersion = "v1",
                nodes = new object[]
                {
                    new
                    {
                        id = start,
                        stageName = "start",
                        type = 1,
                        positionX = 0,
                        positionY = 0,
                        rules = Array.Empty<object>(),
                    },
                    new
                    {
                        id = end,
                        stageName = "end",
                        type = 3,
                        positionX = 200,
                        positionY = 0,
                        rules = new object[]
                        {
                            new
                            {
                                sort = 1,
                                condition = new
                                {
                                    @operator = "and",
                                    leaves = new[]
                                    {
                                        new
                                        {
                                            field = "days",
                                            op = ">",
                                            value = "3",
                                        },
                                    },
                                },
                                action = new
                                {
                                    type = 1,
                                    targetUser = SeedUserId,
                                    message = "notify",
                                },
                            },
                        },
                    },
                },
                edges = new[]
                {
                    new
                    {
                        sourceNodeId = start,
                        targetNodeId = end,
                        condition = (object?)null,
                    },
                },
            }
        );
        Assert.Equal(HttpStatusCode.OK, detail.StatusCode);

        var versionId = RunInScope(ctx =>
            ctx.FlowVersions.Where(v => v.FlowId == flowId && v.IsActive).Select(v => v.Id).Single()
        );
        var get = await Client.GetAsync($"/api/Flow/{versionId}");
        Assert.Equal(HttpStatusCode.OK, get.StatusCode);
        var dto = await ReadJson<FlowDetailResponseDto>(get);
        Assert.Equal(2, dto.Nodes.Count);
        Assert.Single(dto.Edges);
        Assert.Equal("v1", dto.FlowVersion);

        // second version deactivates the first
        var v2 = await AuthClient.PostAsJsonAsync(
            "/api/Flow/detail",
            new
            {
                flowId,
                flowVersion = "v2",
                nodes = Array.Empty<object>(),
                edges = Array.Empty<object>(),
            }
        );
        Assert.Equal(HttpStatusCode.OK, v2.StatusCode);
        Assert.Equal(
            1,
            RunInScope(ctx => ctx.FlowVersions.Count(v => v.FlowId == flowId && v.IsActive))
        );

        var delVersion = await AuthClient.DeleteAsync($"/api/Flow/detail/{versionId}");
        Assert.Equal(HttpStatusCode.OK, delVersion.StatusCode);
        Assert.False(RunInScope(ctx => ctx.FlowVersions.Any(v => v.Id == versionId)));

        var del = await AuthClient.DeleteAsync($"/api/Flow/{flowId}");
        Assert.Equal(HttpStatusCode.OK, del.StatusCode);
        Assert.False(RunInScope(ctx => ctx.Flows.Any(f => f.Id == flowId)));
    }

    [Fact]
    public async Task AddDetail_UnknownFlow_Returns404()
    {
        var res = await AuthClient.PostAsJsonAsync(
            "/api/Flow/detail",
            new
            {
                flowId = 999999,
                flowVersion = "v1",
                nodes = Array.Empty<object>(),
                edges = Array.Empty<object>(),
            }
        );
        Assert.Equal(HttpStatusCode.NotFound, res.StatusCode);
    }
}

using System.Net;
using System.Net.Http.Json;
using blog.Dtos._8bit;
using blog.Dtos.Page;

namespace blog.Tests.Integration;

public class BitTests : IntegrationTestBase
{
    [Fact]
    public async Task List_ReturnsSeedSequencer()
    {
        var res = await Client.GetAsync("/api/Bit/list?pageIndex=1&pageSize=10");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var page = await ReadJson<PageResponseDto<SequencerListRequestDto>>(res);
        var item = Assert.Single(page.Items);
        Assert.Equal("seed seq", item.Name);
        Assert.Equal(120, item.Bpm);
    }

    [Fact]
    public async Task List_SecondPage_IsEmptyNotDuplicated()
    {
        // B14(b)：以前重複分頁導致第 2 頁永遠空、第 1 頁也可能錯；現在 total 應一致
        var page2 = await ReadJson<PageResponseDto<SequencerListRequestDto>>(
            await Client.GetAsync("/api/Bit/list?pageIndex=2&pageSize=10")
        );
        Assert.Empty(page2.Items);
        Assert.Equal(1, page2.TotalSize);
    }

    [Fact]
    public async Task Detail_ReturnsTracksAndSteps()
    {
        var res = await Client.GetAsync($"/api/Bit/{SeedSequencerId}");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        var dto = await ReadJson<SequencerResponseDto>(res);
        var track = Assert.Single(dto.Tracks);
        var step = Assert.Single(track.Steps);
        Assert.True(step.IsOn);
        Assert.Equal(440m, step.Hz);
    }

    [Fact]
    public async Task Detail_Missing_Returns404()
    {
        var res = await Client.GetAsync("/api/Bit/999999");
        Assert.Equal(HttpStatusCode.NotFound, res.StatusCode);
    }

    [Fact]
    public async Task Create_WithoutToken_Returns401()
    {
        var res = await Client.PostAsJsonAsync(
            "/api/Bit",
            new
            {
                name = "x",
                bpm = 90,
                tracks = Array.Empty<object>(),
            }
        );
        Assert.Equal(HttpStatusCode.Unauthorized, res.StatusCode);
    }

    [Fact]
    public async Task Create_Then_Delete_RoundTrip()
    {
        var create = await AuthClient.PostAsJsonAsync(
            "/api/Bit",
            new
            {
                name = "tune",
                bpm = 140,
                tracks = new[]
                {
                    new
                    {
                        seq = 0,
                        steps = new object[]
                        {
                            new
                            {
                                seq = 0,
                                isOn = true,
                                hz = 261.63m,
                            },
                            new
                            {
                                seq = 1,
                                isOn = false,
                                hz = (decimal?)null,
                            },
                        },
                    },
                },
            }
        );
        Assert.Equal(HttpStatusCode.OK, create.StatusCode);

        var id = RunInScope(ctx =>
            ctx.Sequencers.Where(s => s.Name == "tune").Select(s => s.Id).Single()
        );
        var dto = await ReadJson<SequencerResponseDto>(await Client.GetAsync($"/api/Bit/{id}"));
        Assert.Equal(140, dto.Bpm);
        Assert.Equal(2, dto.Tracks[0].Steps.Count);
        Assert.Equal(SeedUserName, dto.CreateUser?.Name);

        var del = await AuthClient.DeleteAsync($"/api/Bit/{id}");
        Assert.Equal(HttpStatusCode.OK, del.StatusCode);
        Assert.False(RunInScope(ctx => ctx.Sequencers.Any(s => s.Id == id)));
    }
}

using blog.Common.Enum;
using blog.Common.Helper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace blog.Tests;

/// <summary>
/// 迴歸測試：GetListVersionAsync 與 BumpListVersionAsync 曾經分別走
/// IDistributedCache（Hash 表示）與 IConnectionMultiplexer 的裸 INCR（String 表示），
/// 在真正的 Redis 上會因為同一把 key 兩種型別互踩而丟 WRONGTYPE，
/// 造成所有分頁列表 API 500（2026-09-22 發生在正式站）。
/// 兩者現在都只透過 IDistributedCache 操作，這裡鎖住這個不變量。
/// </summary>
public class PageHelperVersionTests
{
    private static IDistributedCache CreateCache() =>
        new MemoryDistributedCache(
            Microsoft.Extensions.Options.Options.Create(new MemoryDistributedCacheOptions())
        );

    [Fact]
    public async Task GetListVersionAsync_NoPriorBump_ReturnsZero()
    {
        var cache = CreateCache();

        var version = await cache.GetListVersionAsync(PageEnums.PostList);

        Assert.Equal(0, version);
    }

    [Fact]
    public async Task BumpListVersionAsync_ThenGet_ReflectsEachBump()
    {
        var cache = CreateCache();

        await cache.BumpListVersionAsync(PageEnums.PostList);
        await cache.BumpListVersionAsync(PageEnums.PostList);
        await cache.BumpListVersionAsync(PageEnums.PostList);

        var version = await cache.GetListVersionAsync(PageEnums.PostList);

        Assert.Equal(3, version);
    }

    [Fact]
    public async Task BumpListVersionAsync_DifferentServices_DoNotShareVersion()
    {
        var cache = CreateCache();

        await cache.BumpListVersionAsync(PageEnums.PostList);
        await cache.BumpListVersionAsync(PageEnums.RecipeList);
        await cache.BumpListVersionAsync(PageEnums.RecipeList);

        Assert.Equal(1, await cache.GetListVersionAsync(PageEnums.PostList));
        Assert.Equal(2, await cache.GetListVersionAsync(PageEnums.RecipeList));
    }
}

using System.Net;
using System.Net.Http.Json;
using blog.Common.Helper;
using blog.Entities;
using blog.Messaging.Consumers;
using Docker.DotNet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Moq;
using RabbitMQ.Client;
using StackExchange.Redis;

namespace blog.Tests.Integration;

/// <summary>
/// 整個 API 跑在記憶體內：Sqlite in-memory 取代 SQL Server，
/// MemoryDistributedCache 取代 Redis cache，Redis / RabbitMQ / Docker / Ollama 全部 mock。
/// </summary>
public class ApiFactory : WebApplicationFactory<Program>
{
    private readonly SqliteConnection _connection = new("DataSource=:memory:");
    private readonly string _tempDir = Path.Combine(
        Path.GetTempPath(),
        "toolapi-tests",
        Guid.NewGuid().ToString("N")
    );

    public Mock<IChannel> Channel { get; } = new();
    public Mock<IConnection> RabbitConnection { get; } = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        _connection.Open();
        Directory.CreateDirectory(_tempDir);

        builder.UseEnvironment("Testing");
        // UseSetting 會進 host configuration，在 Program.cs 讀 builder.Configuration 之前就已生效；
        // ConfigureAppConfiguration 對 minimal hosting 太晚，JwtBearer 會拿到 appsettings 的 key。
        var settings = new Dictionary<string, string?>
        {
            ["Jwt:Key"] = "integration-test-signing-key-at-least-32-chars!!",
            ["Jwt:Issuer"] = "test",
            ["Jwt:Audience"] = "test",
            ["Jwt:ExpireMinutes"] = "60",
            ["ConnectionStrings:Redis"] = "localhost:1,abortConnect=false",
            ["ConnectionStrings:DefaultConnection"] = "Server=unused",
            ["RabbitMQ:HostName"] = "unused",
            ["RabbitMQ:UserName"] = "unused",
            ["RabbitMQ:Password"] = "unused",
            ["File:BasePath"] = Path.Combine(_tempDir, "files"),
            ["JudgeOptions:SandBoxPath"] = Path.Combine(_tempDir, "judge"),
            ["JudgeOptions:DockerEndpoint"] = "unix:///nonexistent",
            ["Ollama:Url"] = "http://ollama.test/api/generate",
            ["PathBase"] = "",
        };
        foreach (var (k, v) in settings)
            builder.UseSetting(k, v);

        builder.ConfigureServices(services =>
        {
            // ----- DB: Sqlite in-memory -----
            // EF 9 的 AddDbContext 會另外註冊 IDbContextOptionsConfiguration<T>（帶 UseSqlServer），
            // 不移除的話 Sqlite 與 SqlServer provider 會同時存在而炸掉
            foreach (
                var d in services
                    .Where(d =>
                        d.ServiceType == typeof(DbContextOptions<BlogContext>)
                        || d.ServiceType == typeof(DbContextOptions)
                        || d.ServiceType == typeof(BlogContext)
                        || (
                            d.ServiceType.IsGenericType
                            && d.ServiceType.Name.StartsWith("IDbContextOptionsConfiguration")
                        )
                    )
                    .ToList()
            )
                services.Remove(d);
            services.AddDbContext<BlogContext>(o =>
                o.UseSqlite(_connection).ReplaceService<IModelCustomizer, SqliteModelCustomizer>()
            );

            // ----- Cache -----
            services.RemoveAll<IDistributedCache>();
            services.AddDistributedMemoryCache();

            // ----- Redis -----
            var db = new Mock<IDatabase>();
            var counters = new Dictionary<string, long>();
            // StackExchange.Redis 的 StringSetAsync 有兩個「4 個位置參數」看起來很像但其實不同
            // 的多載：一個沒有 CommandFlags（CacheHelper.AcquireLock 用的是這個），一個有。
            // C# 選多載時優先選「參數個數剛好對上、不用補預設值」的那個，所以呼叫端沒帶
            // CommandFlags 時，實際打中的是沒有 CommandFlags 的那個多載——兩個都要 mock，
            // 只 mock 五參數那個的話，AcquireLock 永遠打不中 setup，Moq 用寬鬆模式回傳
            // default(bool)=false，鎖永遠搶不到，SaveCacheAsync 永遠重試到底、從來沒真的
            // 寫進快取過（這裡曾經真的踩過：偵錯了老半天才發現是這個多載沒接到）。
            db.Setup(d =>
                    d.StringSetAsync(
                        It.IsAny<RedisKey>(),
                        It.IsAny<RedisValue>(),
                        It.IsAny<TimeSpan?>(),
                        It.IsAny<When>()
                    )
                )
                .ReturnsAsync(true);
            db.Setup(d =>
                    d.StringSetAsync(
                        It.IsAny<RedisKey>(),
                        It.IsAny<RedisValue>(),
                        It.IsAny<TimeSpan?>(),
                        It.IsAny<When>(),
                        It.IsAny<CommandFlags>()
                    )
                )
                .ReturnsAsync(true);
            db.Setup(d =>
                    d.StringSetAsync(
                        It.IsAny<RedisKey>(),
                        It.IsAny<RedisValue>(),
                        It.IsAny<TimeSpan?>(),
                        It.IsAny<bool>(),
                        It.IsAny<When>(),
                        It.IsAny<CommandFlags>()
                    )
                )
                .ReturnsAsync(true);
            db.Setup(d => d.KeyDeleteAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
                .ReturnsAsync(true);
            db.Setup(d =>
                    d.StringIncrementAsync(
                        It.IsAny<RedisKey>(),
                        It.IsAny<long>(),
                        It.IsAny<CommandFlags>()
                    )
                )
                .ReturnsAsync(
                    (RedisKey k, long by, CommandFlags _) =>
                    {
                        var key = k.ToString();
                        counters[key] = counters.GetValueOrDefault(key) + by;
                        return counters[key];
                    }
                );
            // 跟 StringIncrementAsync 共用同一個 counters 字典 ——
            // 只有 INCR 過的 key（瀏覽數）才會反映在這裡；其餘 key（頁面快取內容、
            // Post 快取本身等）本來就是走 IDistributedCache 的 AddDistributedMemoryCache，
            // 不經過這個 IDatabase mock，所以維持回 Null 沒問題。
            db.Setup(d => d.StringGetAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
                .ReturnsAsync(
                    (RedisKey k, CommandFlags _) =>
                        counters.TryGetValue(k.ToString(), out var v)
                            ? (RedisValue)v
                            : RedisValue.Null
                );
            // 批次版本（BlogCacheService.GetViewCountsAsync 用來一次讀多篇文章的瀏覽數）：
            // 跟上面單筆版本共用同一個 counters 字典，語意要一致。
            db.Setup(d => d.StringGetAsync(It.IsAny<RedisKey[]>(), It.IsAny<CommandFlags>()))
                .ReturnsAsync(
                    (RedisKey[] keys, CommandFlags _) =>
                        keys.Select(k =>
                                counters.TryGetValue(k.ToString(), out var v)
                                    ? (RedisValue)v
                                    : RedisValue.Null
                            )
                            .ToArray()
                );
            db.Setup(d => d.KeyExistsAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
                .ReturnsAsync(false);
            db.Setup(d =>
                    d.KeyExpireAsync(
                        It.IsAny<RedisKey>(),
                        It.IsAny<TimeSpan?>(),
                        It.IsAny<CommandFlags>()
                    )
                )
                .ReturnsAsync(true);
            var mux = new Mock<IConnectionMultiplexer>();
            mux.Setup(m => m.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(db.Object);
            services.RemoveAll<IConnectionMultiplexer>();
            services.AddSingleton(mux.Object);

            // ----- RabbitMQ -----
            Channel
                .Setup(c =>
                    c.BasicPublishAsync(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<bool>(),
                        It.IsAny<BasicProperties>(),
                        It.IsAny<ReadOnlyMemory<byte>>(),
                        It.IsAny<CancellationToken>()
                    )
                )
                .Returns(ValueTask.CompletedTask);
            RabbitConnection
                .Setup(c =>
                    c.CreateChannelAsync(
                        It.IsAny<CreateChannelOptions>(),
                        It.IsAny<CancellationToken>()
                    )
                )
                .ReturnsAsync(Channel.Object);
            services.RemoveAll<IConnection>();
            services.AddSingleton(RabbitConnection.Object);
            foreach (
                var hosted in services
                    .Where(d =>
                        d.ServiceType == typeof(IHostedService)
                        && (
                            d.ImplementationType == typeof(JudgeConsumer)
                            || d.ImplementationType == typeof(JudgeTestConsumer)
                        )
                    )
                    .ToList()
            )
                services.Remove(hosted);

            // ----- Docker -----
            services.RemoveAll<IDockerClient>();
            services.AddSingleton(Mock.Of<IDockerClient>());

            // ----- Ollama：固定回一段摘要 -----
            services
                .AddHttpClient<OllamaHelper>()
                .ConfigurePrimaryHttpMessageHandler(() => new FakeOllamaHandler());
        });
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = base.CreateHost(builder);
        using var scope = host.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<BlogContext>();
        ctx.Database.EnsureCreated();
        return host;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        _connection.Dispose();
        try
        {
            Directory.Delete(_tempDir, true);
        }
        catch (IOException) { }
    }

    /// <summary>SQL Server 的 GETDATE() 在 Sqlite 不存在，換成 CURRENT_TIMESTAMP。</summary>
    private sealed class SqliteModelCustomizer(ModelCustomizerDependencies deps)
        : ModelCustomizer(deps)
    {
        public override void Customize(ModelBuilder modelBuilder, DbContext context)
        {
            base.Customize(modelBuilder, context);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in entity.GetProperties())
                {
                    if (
                        string.Equals(
                            prop.GetDefaultValueSql(),
                            "GETDATE()",
                            StringComparison.OrdinalIgnoreCase
                        )
                    )
                        prop.SetDefaultValueSql("CURRENT_TIMESTAMP");
                }
            }
        }
    }

    private sealed class FakeOllamaHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        ) =>
            Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = JsonContent.Create(new { response = "摘要" }),
                }
            );
    }
}

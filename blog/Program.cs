using System.Text;
using AutoMapper;
using blog.Common.Helper;
using blog.Entities;
using blog.Hubs;
using blog.Messaging;
using blog.Messaging.Consumers;
using blog.Middleware;
using blog.Options;
using blog.Repository;
using blog.Seed;
using blog.Services;
using blog.Services.Redis;
using Docker.DotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// ----- 設定 -----
// 機敏值（DB / JWT / RabbitMQ 密碼）請在 appsettings.Development.json、user-secrets 或環境變數覆蓋，
// 環境變數命名採 .NET 慣例：Jwt__Key、ConnectionStrings__DefaultConnection、JudgeOptions__DockerEndpoint、File__BasePath。
var jwtConfig = builder.Configuration.GetSection("Jwt");
var rabbitConfig = builder.Configuration.GetSection("RabbitMQ");
var key = Encoding.UTF8.GetBytes(jwtConfig["Key"]!);

builder
    .Services.AddOptions<JudgeOptions>()
    .Bind(builder.Configuration.GetSection("JudgeOptions"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

// 靜態檔案根目錄：Linux 容器預設 /app/files（compose volume），Windows 預設 C:\PushAPI\files
var filesBasePath =
    builder.Configuration["File:BasePath"]
    ?? (OperatingSystem.IsWindows() ? @"C:\PushAPI\files" : "/app/files");
Directory.CreateDirectory(filesBasePath);

// ----- 認證 -----
builder
    .Services.AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters =
            new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfig["Issuer"],
                ValidAudience = jwtConfig["Audience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
            };
    });
builder.Services.AddAuthorization();

// ----- 外部連線（lazy，第一次被要求時才連，啟動不因 MQ/Redis 不在而失敗） -----
builder.Services.AddSingleton<IConnection>(_ =>
{
    var factory = new ConnectionFactory
    {
        HostName = rabbitConfig["HostName"]!,
        UserName = rabbitConfig["UserName"]!,
        Password = rabbitConfig["Password"]!,
        AutomaticRecoveryEnabled = true,
    };
    return factory.CreateConnectionAsync().GetAwaiter().GetResult();
});

var redisConnectionString = builder.Configuration.GetConnectionString("Redis")!;
builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
{
    var redisOptions = ConfigurationOptions.Parse(redisConnectionString);
    redisOptions.AbortOnConnectFail = false;
    return ConnectionMultiplexer.Connect(redisOptions);
});
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = redisConnectionString;
    option.InstanceName = "Blog";
});

builder.Services.AddSingleton<IDockerClient>(sp =>
{
    var opts = sp.GetRequiredService<IOptions<JudgeOptions>>().Value;
    return new DockerClientConfiguration(new Uri(opts.DockerEndpoint)).CreateClient();
});

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHealthChecks();

// ----- MVC / API -----
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

// ----- 應用服務 -----
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddHttpClient<OllamaHelper>(client => client.Timeout = TimeSpan.FromSeconds(60));
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<RecipeService>();
builder.Services.AddScoped<FileHelper>();
builder.Services.AddScoped<RecipeRepository>();
builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<BlogCacheService>();
builder.Services.AddScoped<RecipeCacheService>();
builder.Services.AddScoped<CacheHelper>();
builder.Services.AddScoped<FlowService>();
builder.Services.AddScoped<FlowRepository>();
builder.Services.AddScoped<JwtInfoHelper>();
builder.Services.AddScoped<FlowCacheService>();
builder.Services.AddScoped<BitRepository>();
builder.Services.AddScoped<BitService>();
builder.Services.AddScoped<JudgeService>();
builder.Services.AddScoped<JudgeCacheService>();
builder.Services.AddScoped<JudgeRepository>();
builder.Services.AddScoped<JudgeHelper>();
builder.Services.AddScoped<BitCacheService>();

builder
    .Services.AddSignalR()
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.PropertyNamingPolicy = System
            .Text
            .Json
            .JsonNamingPolicy
            .CamelCase;
    });

#region RabbitMQ + SignalR
builder.Services.AddSingleton<PendingReplyStore>();
builder.Services.AddSingleton<Publisher>();
builder.Services.AddHostedService<JudgeConsumer>();
builder.Services.AddHostedService<JudgeTestConsumer>();
#endregion

builder.Services.AddAutoMapper(
    (IMapperConfigurationExpression cfg) => { },
    AppDomain.CurrentDomain.GetAssemblies()
);

// CORS：來源收斂待接 SSO 後再處理，先維持現狀
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
    options.AddPolicy(
        "SignalR",
        policy =>
            policy
                .WithOrigins("http://localhost:3000", "https://matthewyu.uk")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
    );
});

// ----- Logging：Development 才開 Debug 與檔案 log，正式環境走 stdout 給容器平台收 -----
builder.Host.UseSerilog(
    (ctx, config) =>
    {
        var isDev = ctx.HostingEnvironment.IsDevelopment();
        config
            .MinimumLevel.Is(
                isDev
                    ? Serilog.Events.LogEventLevel.Debug
                    : Serilog.Events.LogEventLevel.Information
            )
            .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
            .WriteTo.Console();
        if (isDev)
        {
            config
                .MinimumLevel.Override(
                    "Microsoft.AspNetCore.SignalR",
                    Serilog.Events.LogEventLevel.Debug
                )
                .MinimumLevel.Override(
                    "Microsoft.AspNetCore.Http.Connections",
                    Serilog.Events.LogEventLevel.Debug
                )
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
        }
    }
);

var app = builder.Build();

// ----- Pipeline -----
// 正式站掛在反向代理的子路徑下（https://api.matthewyu.uk/toolAPI/...）。
// 由環境變數 PathBase=/toolAPI 指定；本機開發留空即為根路徑。
var pathBase = app.Configuration["PathBase"];
if (!string.IsNullOrWhiteSpace(pathBase))
{
    app.UsePathBase(pathBase);
}

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(filesBasePath),
        RequestPath = "/files",
    }
);

app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/healthz");
app.MapControllers();
app.MapHub<MqHub>("/mqhub").RequireCors("SignalR");

// 題庫 seed 只在 Development 或明確帶 --seed 時執行（SeedJudge 很大，正式環境不要每次啟動都跑）
if (app.Environment.IsDevelopment() || args.Contains("--seed"))
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<BlogContext>();
    await SeedJudge.SeedJudgeAsync(context);
}

//app.UseMiddleware<InternalSecretMiddleware>();

await app.RunAsync();

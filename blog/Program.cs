using System.Text;
using AutoMapper;
using blog.Common.Helper;
using blog.Entities;
using blog.Hubs;
using blog.Messaging;
using blog.Messaging.Consumers;
using blog.Options;
using blog.Repository;
using blog.Seed;
using blog.Services;
using blog.Services.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using RabbitMQ.Client;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtConfig = builder.Configuration.GetSection("Jwt");
var rabbitConfig = builder.Configuration.GetSection("rabbitMQ");
var key = Encoding.UTF8.GetBytes(jwtConfig["Key"]!);

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

var factory = new ConnectionFactory
{
    HostName = rabbitConfig["HostName"]!,
    UserName = rabbitConfig["UserName"]!,
    Password = rabbitConfig["Password"]!,
};

var connection = await factory.CreateConnectionAsync();
builder.Services.AddSingleton(connection);

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.Configure<JudgeOptions>(builder.Configuration.GetSection("JudgeOptions"));

builder.Logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Debug);
builder.Logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Debug);

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<ToolService>();
builder.Services.AddHttpClient<OllamaHelper>();
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
builder.Services.AddScoped<_8BitRepository>();
builder.Services.AddScoped<_8BitService>();
builder.Services.AddScoped<JudgeService>();
builder.Services.AddScoped<JudgaCacheService>();
builder.Services.AddScoped<JudgeRepository>();
builder.Services.AddScoped<JuageHelper>();
builder.Services.AddScoped<_8bitrCacheService>();

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

#region RabbitMQ¡BSignalR
builder.Services.AddSingleton<PendingReplyStore>();
builder.Services.AddSingleton<Publisher>();
builder.Services.AddHostedService<JudgeConsumer>();
builder.Services.AddHostedService<JudgeTestConsumer>();
#endregion

builder.Services.AddAutoMapper(
    (IMapperConfigurationExpression cfg) => { },
    AppDomain.CurrentDomain.GetAssemblies()
);
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

builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetConnectionString("Redis");
    option.InstanceName = "Blog";
});

builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!)
);

builder.Host.UseSerilog(
    (ctx, config) =>
    {
        config
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
    }
);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider("C:\\PushAPI\\files"),
        RequestPath = "/files",
    }
);

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapHub<MqHub>("/mqhub").RequireCors("SignalR");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BlogContext>();
    await SeedJudge.SeedJudgeAsync(context);
}

//app.UseMiddleware<InternalSecretMiddleware>();

await app.RunAsync();

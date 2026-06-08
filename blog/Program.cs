using System.Text;
using AutoMapper;
using blog.Common.Helper;
using blog.Entities;
using blog.Middleware;
using blog.Repository;
using blog.Services;
using blog.Services.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtConfig = builder.Configuration.GetSection("Jwt");
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

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
});

builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetConnectionString("Redis");
    option.InstanceName = "Blog";
});

// ��singleton �O�]�� redis tcp�s�u �p�G�s�W�@�ӹ�� �N�|�ݭn���s�@�� �o�O��ͳ]�p�����D
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!)
);

builder.Host.UseSerilog(
    (ctx, config) =>
    {
        config.WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
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

//app.UseMiddleware<InternalSecretMiddleware>();

app.Run();

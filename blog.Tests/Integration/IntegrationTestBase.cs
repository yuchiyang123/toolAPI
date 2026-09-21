using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using blog.Common.Enum;
using blog.Entities;
using blog.Entities._8bit;
using blog.Entities.Blog;
using blog.Entities.Flows;
using blog.Entities.Judge;
using blog.Entities.Recipes;
using blog.Entities.User;
using blog.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace blog.Tests.Integration;

/// <summary>
/// 每個測試類別一個 ApiFactory（= 一個乾淨的 Sqlite in-memory DB），
/// 建構時塞入最小 seed：使用者 1、一篇文章、一份食譜、一個流程、一個 sequencer、一題 judge。
/// </summary>
public abstract class IntegrationTestBase : IDisposable
{
    protected const string SeedUserName = "tester";
    protected const string SeedPassword = "P@ssw0rd!";
    protected const int SeedUserId = 1;

    protected static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

    protected ApiFactory Factory { get; } = new();
    protected HttpClient Client { get; }
    protected HttpClient AuthClient { get; }

    protected int SeedPostId { get; private set; }
    protected int SeedRecipeId { get; private set; }
    protected int SeedFlowId { get; private set; }
    protected int SeedSequencerId { get; private set; }
    protected int SeedProblemId { get; private set; }

    protected IntegrationTestBase()
    {
        Client = Factory.CreateClient();
        Seed();
        AuthClient = Factory.CreateClient();
        AuthClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            TokenFor(SeedUserId)
        );
    }

    protected string TokenFor(int userId)
    {
        using var scope = Factory.Services.CreateScope();
        return scope
            .ServiceProvider.GetRequiredService<JwtService>()
            .GenerateToken(userId.ToString());
    }

    protected T RunInScope<T>(Func<BlogContext, T> fn)
    {
        using var scope = Factory.Services.CreateScope();
        return fn(scope.ServiceProvider.GetRequiredService<BlogContext>());
    }

    protected static async Task<T> ReadJson<T>(HttpResponseMessage res)
    {
        var text = await res.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(text, Json)
            ?? throw new InvalidOperationException($"empty body: {text}");
    }

    private void Seed()
    {
        using var scope = Factory.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<BlogContext>();
        var now = DateTime.UtcNow;

        var user = new Users
        {
            Id = SeedUserId,
            UserName = SeedUserName,
            LogInDate = now,
            CreateDate = now,
        };
        user.PasswordHash = new PasswordHasher<Users>().HashPassword(user, SeedPassword);
        ctx.Users.Add(user);

        var post = new Posts
        {
            Title = "seed post",
            Content = "<p>hello</p>",
            CreateUserId = SeedUserId,
            CreateDate = now,
            PostsTagsMapping = [new PostsTagMapping { PostsTag = new PostsTag { Tag = "seed" } }],
        };
        ctx.Posts.Add(post);

        var recipe = new Recipe
        {
            RecipeName = "seed recipe",
            Amount = 2,
            CookingTime = 10,
            Complexity = 1,
            Description = "desc",
            CreateDate = now,
            UpdateDate = now,
            RecipeDetailMappings = new RecipeDetailMapping
            {
                RecipeDetail = new RecipeDetail { Content = "content" },
            },
            RecipeStepMappings =
            [
                new RecipeStepMapping
                {
                    RecipeStep = new RecipeStep { Step = 1, Description = "step 1" },
                },
            ],
            RecipeTagMappings =
            [
                new RecipeTagMapping { RecipeTag = new RecipeTag { Tag = "tag" } },
            ],
        };
        ctx.Recipe.Add(recipe);

        var flow = new Flow
        {
            Name = "seed flow",
            Description = "d",
            CreateDate = now,
            UpdateDate = now,
            CreateUser = SeedUserId,
            UpdateUser = SeedUserId,
            FlowVersion =
            [
                new FlowVersion
                {
                    Version = "v1",
                    IsActive = true,
                    CreateDate = now,
                    UpdateDate = now,
                    CreateUser = SeedUserId,
                    UpdateUser = SeedUserId,
                },
            ],
        };
        ctx.Flows.Add(flow);

        var seq = new Sequencer
        {
            Name = "seed seq",
            Bpm = 120,
            CreateDate = now,
            UpdateDate = now,
            CreateUser = SeedUserId,
            UpdateUser = SeedUserId,
            Tracks =
            [
                new Track
                {
                    TrackSeq = 0,
                    Step =
                    [
                        new Step
                        {
                            StepSeq = 0,
                            IsOn = true,
                            Hz = 440,
                        },
                    ],
                },
            ],
        };
        ctx.Sequencers.Add(seq);

        var problem = new Problem
        {
            ProblemName = "seed problem",
            Description = "add two numbers",
            Difficulty = ProblemDifficultyEnums.Easy,
            CreateDate = now,
            UpdateDate = now,
            ProblemTags = [new ProblemTags { Name = "math" }],
            ProblemSignatures =
            [
                new ProblemSignature
                {
                    Language = JudgeLanguageEnum.python,
                    FunctionName = "add",
                    ProblemParameters =
                    [
                        new ProblemParameters { ParameterName = "a", Type = "int" },
                        new ProblemParameters { ParameterName = "b", Type = "int" },
                    ],
                    ProblemReturnTypes =
                    [
                        new ProblemReturnType { ReturnName = "r", ReturnType = "int" },
                    ],
                },
            ],
            Functions =
            [
                new Function
                {
                    Language = JudgeLanguageEnum.python,
                    Input = """{"a":1,"b":2}""",
                    Expected = "3",
                },
            ],
        };
        ctx.Problems.Add(problem);

        ctx.SaveChanges();

        SeedPostId = post.Id;
        SeedRecipeId = recipe.Id;
        SeedFlowId = flow.Id;
        SeedSequencerId = seq.Id;
        SeedProblemId = problem.Id;
    }

    public void Dispose()
    {
        Client.Dispose();
        AuthClient.Dispose();
        Factory.Dispose();
        GC.SuppressFinalize(this);
    }
}

using blog.Services;
using blog.Dtos.Judge;

namespace blog.Tests;

public class JudgeServiceTests
{
    private readonly JudgeService _service = new();

    [Fact]
    public async Task Python_HelloWorld_ReturnsStdout()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = "python",
            Code = "print('hello world')"
        });

        Assert.Equal("hello world\n", result.Stdout);
        Assert.Equal("", result.Stderr);
    }

    [Fact]
    public async Task Python_DivisionByZero_ReturnsStderr()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = "python",
            Code = "print(1/0)"
        });

        Assert.Equal("", result.Stdout);
        Assert.Contains("ZeroDivisionError", result.Stderr);
    }

    [Fact]
    public async Task Python_InfiniteLoop_ReturnsTimeLimitExceeded()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = "python",
            Code = "while True: pass"
        });

        Assert.Equal("", result.Stdout);
        Assert.Equal("Time Limit Exceeded", result.Stderr);
    }

    [Fact]
    public async Task Python_ForkBomb_IsContained()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = "python",
            Code = "import os\nwhile True:\n    os.fork()"
        });

        Assert.Equal("", result.Stdout);
        Assert.NotEqual("Time Limit Exceeded", result.Stderr);
    }

    [Fact]
    public async Task CSharp_HelloWorld_ReturnsStdout()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = "csharp",
            Code = "Console.WriteLine(\"Hello from C#\");"
        });

        Assert.Contains("Hello from C#", result.Stdout);
        Assert.Equal("", result.Stderr);
    }

    [Fact]
    public async Task CSharp_DivisionByZero_ReturnsStderr()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = "csharp",
            Code = "int a = 10;\nint b = 0;\nConsole.WriteLine(a / b);"
        });

        Assert.Equal("", result.Stdout);
        Assert.Contains("DivideByZeroException", result.Stderr);
    }

    [Fact]
    public async Task CSharp_InfiniteLoop_ReturnsTimeLimitExceeded()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = "csharp",
            Code = "while(true) {}"
        });

        Assert.Equal("", result.Stdout);
        Assert.Equal("Time Limit Exceeded", result.Stderr);
    }

    [Fact]
    public async Task CSharp_NetworkAccess_IsBlocked()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = "csharp",
            Code = "using System.Net.Http;\nvar client = new HttpClient();\nvar res = await client.GetStringAsync(\"https://google.com\");\nConsole.WriteLine(res);"
        });

        Assert.Equal("", result.Stdout);
        Assert.NotEmpty(result.Stderr);
    }

    [Theory]
    [InlineData("python", "print('hello')", "hello\n")]
    [InlineData("python", "print(1+1)", "2\n")]
    public async Task Python_BasicExpressions_ReturnCorrectOutput(string language, string code, string expected)
    {
        var result = await _service.RunAsync(new JudgeDto { Language = language, Code = code });
        Assert.Equal(expected, result.Stdout);
    }

    [Fact]
    public async Task UnsupportedLanguage_ThrowsArgumentException()
    {
        await Assert.ThrowsAsync<ArgumentException>(() =>
            _service.RunAsync(new JudgeDto
            {
                Language = "ruby",
                Code = "puts 'hello'"
            }));
    }
}
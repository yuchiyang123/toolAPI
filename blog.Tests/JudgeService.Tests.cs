using blog.Services;
using blog.Dtos.Judge;
using blog.Common.Enum;

namespace blog.Tests;

public class JudgeServiceTests
{
    private readonly JudgeService _service = new();

    [SkippableFact]
    public async Task Python_HelloWorld_ReturnsStdout()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = JudgeLanguageEnum.python,
            Code = "print('hello world')"
        });

        Assert.Equal("hello world\n", result.Stdout);
        Assert.Equal("", result.Stderr);
    }

    [SkippableFact]
    public async Task Python_DivisionByZero_ReturnsStderr()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = JudgeLanguageEnum.python,
            Code = "print(1/0)"
        });

        Assert.Equal("", result.Stdout);
        Assert.Contains("ZeroDivisionError", result.Stderr);
    }

    [SkippableFact]
    public async Task Python_InfiniteLoop_ReturnsTimeLimitExceeded()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = JudgeLanguageEnum.python,
            Code = "while True: pass"
        });

        Assert.Equal("", result.Stdout);
        Assert.Equal("Time Limit Exceeded", result.Stderr);
    }

    [SkippableFact]
    public async Task Python_ForkBomb_IsContained()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = JudgeLanguageEnum.python,
            Code = "import os\nwhile True:\n    os.fork()"
        });

        Assert.Equal("", result.Stdout);
        Assert.NotEqual("Time Limit Exceeded", result.Stderr);
    }

    [SkippableFact]
    public async Task CSharp_HelloWorld_ReturnsStdout()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = JudgeLanguageEnum.csharp,
            Code = "Console.WriteLine(\"Hello from C#\");"
        });

        Assert.Contains("Hello from C#", result.Stdout);
        Assert.Equal("", result.Stderr);
    }

    [SkippableFact]
    public async Task CSharp_DivisionByZero_ReturnsStderr()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = JudgeLanguageEnum.csharp,
            Code = "int a = 10;\nint b = 0;\nConsole.WriteLine(a / b);"
        });

        Assert.Equal("", result.Stdout);
        Assert.Contains("DivideByZeroException", result.Stderr);
    }

    [SkippableFact]
    public async Task CSharp_InfiniteLoop_ReturnsTimeLimitExceeded()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = JudgeLanguageEnum.csharp,
            Code = "while(true) {}"
        });

        Assert.Equal("", result.Stdout);
        Assert.Equal("Time Limit Exceeded", result.Stderr);
    }

    [SkippableFact]
    public async Task CSharp_NetworkAccess_IsBlocked()
    {
        var result = await _service.RunAsync(new JudgeDto
        {
            Language = JudgeLanguageEnum.csharp,
            Code = "using System.Net.Http;\nvar client = new HttpClient();\nvar res = await client.GetStringAsync(\"https://google.com\");\nConsole.WriteLine(res);"
        });

        Assert.Equal("", result.Stdout);
        Assert.NotEmpty(result.Stderr);
    }

    [SkippableFact]
    [InlineData(JudgeLanguageEnum.python, "print('hello')", "hello\n")]
    [InlineData(JudgeLanguageEnum.python, "print(1+1)", "2\n")]
    public async Task Python_BasicExpressions_ReturnCorrectOutput(JudgeLanguageEnum language, string code, string expected)
    {
        var result = await _service.RunAsync(new JudgeDto { Language = language, Code = code });
        Assert.Equal(expected, result.Stdout);
    }   
}
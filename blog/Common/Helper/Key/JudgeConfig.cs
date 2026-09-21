using blog.Common.Enum;

namespace blog.Common.Helper.Key
{
    public static class JudgeConfig
    {
        public static readonly HashSet<string> LocalImages = ["judge-csharp:latest"];

        /// <summary>
        /// 每種語言的映像檔、程式檔名，以及依 timeout 秒數產生執行指令的函式
        /// </summary>
        public static readonly Dictionary<
            JudgeLanguageEnum,
            (string image, string fileName, Func<int, string> buildCmd)
        > Config = new()
        {
            [JudgeLanguageEnum.python] = (
                "python:3.12-alpine",
                "main.py",
                timeout => $"timeout {timeout} python /code/main.py"
            ),
            [JudgeLanguageEnum.csharp] = (
                "judge-csharp:latest",
                "main.cs",
                timeout =>
                    $"timeout {timeout} sh -c 'cp /template/template.csproj /code/ && cp /code/main.cs /code/Program.cs && rm /code/main.cs && cd /code && dotnet restore --source /root/.nuget/packages -v q 2>/dev/null && dotnet run --no-restore -v q'"
            ),
        };
    }
}

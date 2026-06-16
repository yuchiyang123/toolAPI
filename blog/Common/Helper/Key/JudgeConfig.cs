using blog.Common.Enum;

namespace blog.Common.Helper.Key
{
    public static class JudgeConfig
    {
        public static readonly HashSet<string> LocalImages = ["judge-csharp:latest"];

        public static readonly Dictionary<
            JudgeLanguageEnum,
            (string image, string fileName, string cmd)
        > Config = new()
        {
            [JudgeLanguageEnum.python] = (
                "python:3.12-alpine",
                "main.py",
                "timeout 15 python /code/main.py"
            ),
            [JudgeLanguageEnum.csharp] = (
                "judge-csharp:latest",
                "main.cs",
                "timeout 15 sh -c 'cp /template/template.csproj /code/ && cp /code/main.cs /code/Program.cs && rm /code/main.cs && cd /code && dotnet restore --source /root/.nuget/packages -v q 2>/dev/null && dotnet run --no-restore -v q'"
            ),
        };
    }
}

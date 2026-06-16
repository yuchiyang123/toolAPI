using System.Text.Json.Serialization;
using blog.Common.Enum;

namespace blog.Dtos.Judge
{
    public class JudgeDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required JudgeLanguageEnum Language { get; set; }
        public required string Code { get; set; }
    }

    public class JudgeResult
    {
        public string? Stdout { get; set; }
        public string? Stderr { get; set; }
    }
}

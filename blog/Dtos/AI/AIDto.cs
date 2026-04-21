using System.Text.Json.Serialization;

namespace blog.Dtos.AI
{
    public class AIDto
    {
        public required string Model { get; set; }
        public required string Prompt { get; set; }
        public bool Stream { get; set; } = false;
    }

    public class OllamaResponse
    {
        [JsonPropertyName("response")]
        public string Response { get; set; }
    }

    public class AiDtoRequest
    {
        public string? Modeal { get; set; }
        public required string Prompt { get; set; }
    }
}

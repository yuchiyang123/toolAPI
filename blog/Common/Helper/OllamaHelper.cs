using blog.Dtos.AI;
using System.Net.Http;

namespace blog.Common.Helper
{
    public class OllamaHelper(IConfiguration configuration, HttpClient httpClient)
    {
        private readonly string ollamaUrl = configuration["Ollama:Url"]!;

        public async Task<string> GetOllamaResponse(AiDtoRequest aiDtoRequest)
        {
            var payload = new AIDto
            {
                Model = aiDtoRequest.Modeal ?? "gemma4:e4b",
                Prompt = aiDtoRequest.Prompt,
                Stream = false,
            };

            var response = await httpClient.PostAsJsonAsync(ollamaUrl, payload);
            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();

            return result?.Response ?? throw new Exception("Ai回傳為空");
        }

        public AiDtoRequest GetAiDtoRequest(string content)
        {
            return new AiDtoRequest
            {
                Prompt = $"用繁體中文輸出詳細的摘要，只輸出摘要：\n{content}"
            };
        }
    }
}

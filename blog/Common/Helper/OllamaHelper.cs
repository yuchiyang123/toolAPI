using blog.Dtos.AI;

namespace blog.Common.Helper
{
    public class OllamaHelper
    {
        private readonly string ollamaUrl;
        private readonly HttpClient httpClient;
        private readonly ILogger<OllamaHelper> logger;

        public OllamaHelper(
            IConfiguration configuration,
            HttpClient httpClient,
            ILogger<OllamaHelper> logger
        )
        {
            ollamaUrl = configuration["Ollama:Url"]!;
            this.httpClient = httpClient;
            this.logger = logger;
            // 避免 LLM 沒回應時卡住整個 request（HttpClient 預設 100 秒）
            this.httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        /// <summary>
        /// 呼叫 Ollama 取得回應；任何失敗（逾時、連線失敗、空回應）都回傳 null 而不丟例外
        /// </summary>
        public async Task<string?> GetOllamaResponse(
            AiDtoRequest aiDtoRequest,
            CancellationToken ct = default
        )
        {
            var payload = new AIDto
            {
                Model = aiDtoRequest.Modeal ?? "gemma4:e4b",
                Prompt = aiDtoRequest.Prompt,
                Stream = false,
            };

            try
            {
                var response = await httpClient.PostAsJsonAsync(ollamaUrl, payload, ct);
                if (!response.IsSuccessStatusCode)
                {
                    logger.LogWarning(
                        "Ollama returned {StatusCode} from {Url}",
                        response.StatusCode,
                        ollamaUrl
                    );
                    return null;
                }
                var result = await response.Content.ReadFromJsonAsync<OllamaResponse>(ct);
                if (string.IsNullOrWhiteSpace(result?.Response))
                {
                    logger.LogWarning("Ollama returned empty response from {Url}", ollamaUrl);
                    return null;
                }
                return result.Response;
            }
            catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
            {
                logger.LogWarning(ex, "Ollama request failed: {Url}", ollamaUrl);
                return null;
            }
        }

        public AiDtoRequest GetAiDtoRequest(string content)
        {
            return new AiDtoRequest
            {
                Prompt = $"用繁體中文輸出詳細的摘要，只輸出摘要：\n{content}",
            };
        }
    }
}

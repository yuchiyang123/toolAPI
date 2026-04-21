using Azure;
using System.Net.Http;
using blog.Dtos.AI;
using blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace blog.Services
{
    public class AiService(BlogContext context, HttpClient httpClient)
    {
        public async Task<string> GetPostAISummary(int id)
        {
            var content = await context.Posts.Where(x => x.Id == id).Select(x => x.Content).FirstOrDefaultAsync() ?? throw new Exception("找不到對應文章");

            var payload = new AIDto
            {
                Model = "gemma4:e4b",
                Prompt = $"用繁體中文輸出詳細的摘要，只輸出摘要：\n{content}",
                Stream = false,
            };

            var response = await httpClient.PostAsJsonAsync("http://localhost:11434/api/generate", payload);
            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();

            return result?.Response ?? throw new Exception("Ai回傳為空");
        }
    }
}

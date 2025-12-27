using OpenAI.Chat;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using AiAgent.Agent.OpenApi.Models;

namespace AiAgent.Agent.OpenApi
{
    public class OpenApiAgent
    {
        private readonly HttpClient _http;

        public OpenApiAgent(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetReplyAsync(string input)
        {
            // Placeholder: call to an OpenAPI endpoint that returns { "reply": "..." }
            var req = new { prompt = input };
            var res = await _http.PostAsJsonAsync("/api/reply", req);
            res.EnsureSuccessStatusCode();
            var obj = await res.Content.ReadFromJsonAsync<ReplyResponse>();
            return obj?.Reply ?? string.Empty;
        }

        private class ReplyResponse { public string? Reply { get; set; } }
    }
    public sealed class OpenAiClient(HttpClient http)
    {
        private const string Endpoint = "https://api.openai.com/v1/chat/completions";

        public async Task<string> SendAsync(string message)
        {
            var request = new
            {
                model = "gpt-4.1-mini",
                messages = new[]
                {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = message }
            }
            };

            var response = await http.PostAsJsonAsync(Endpoint, request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString()!;
        }
    }
}

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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
}

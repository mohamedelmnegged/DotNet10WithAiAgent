using static AiAgent.Agent.OpenApi.OpenApiAgent;

namespace AiAgent.Agent.OpenApi.Services
{
    public sealed class ChatService(OpenAiClient client)
    {
        public async Task<Models.ChatMessage> AskAsync(string input)
        {
            var response = await client.SendAsync(input);

            return new Models.ChatMessage
            {
                Role = "assistant",
                Content = response,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}

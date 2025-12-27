namespace AiAgent.Agent.OpenApi.Models
{
    public sealed class ChatMessage
    {
        public string Role { get; init; } = default!;
        public string Content { get; init; } = default!;
        public DateTime Timestamp { get; init; }
    }

}

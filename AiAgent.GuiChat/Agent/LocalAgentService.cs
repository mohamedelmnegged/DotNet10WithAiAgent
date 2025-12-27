using System.Threading.Tasks;

namespace AiAgent.GuiChat.Agent
{
    internal class LocalAgentService : IAgentService
    {
        public Task<string> GetReplyAsync(string input)
        {
            // Simple local reply: echo with timestamp. Replace with .NET 10 Agent integration.
            var reply = $"[LocalAgent] {input} (echoed at {System.DateTime.Now:T})";
            return Task.FromResult(reply);
        }
    }
}

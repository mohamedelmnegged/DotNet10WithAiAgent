using System.Threading.Tasks;

namespace AiAgent.GuiChat.Agent
{
    public interface IAgentService
    {
        Task<string> GetReplyAsync(string input);
    }
}

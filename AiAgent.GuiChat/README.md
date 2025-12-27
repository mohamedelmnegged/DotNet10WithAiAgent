AiAgent.GuiChat

This is a simple WinForms demo that provides a GUI chat window and a local agent service.

Planned: integrate with .NET 10 'Agent' APIs. For now, use `LocalAgentService` implementing `IAgentService`.

How to run:
- Open the solution in Visual Studio 2022/2023 with .NET 10 SDK installed.
- Set `AiAgent.GuiChat` as startup project and run.

Next steps to integrate real .NET 10 Agent:
- Add Microsoft.AI.Agent SDK reference (when available).
- Implement an `AgentService` that uses `Agent` builder and provides `GetReplyAsync`.

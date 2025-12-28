var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AiAgent_BlazorUI_Server>("aiagent-blazorui-server");

builder.AddProject<Projects.AiAgent_Agent_OpenApi>("aiagent-agent-openapi");

builder.AddProject<Projects.AiAgent_GuiChat>("aiagent-guichat");

builder.Build().Run();

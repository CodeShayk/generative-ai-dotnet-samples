using A2A;
using A2A.AspNetCore;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IChatClient>(_ =>
    new OllamaApiClient(
        new Uri(Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434"),
        Environment.GetEnvironmentVariable("OLLAMA_MODEL") ?? "phi4-mini"));

builder.Services.AddSingleton<AIAgent>(sp =>
    new ChatClientAgent(
        sp.GetRequiredService<IChatClient>(),
        instructions: "You are an A2A research specialist. Answer concisely with cited claims.",
        name: "ResearchSpecialist"));

var agentCard = new AgentCard
{
    Name = "ResearchSpecialist",
    Description = "An A2A research specialist that answers concisely with cited claims.",
    Version = "1.0.0",
    DefaultInputModes = ["text"],
    DefaultOutputModes = ["text"],
};

builder.Services.AddA2AAgent<AIAgentHandler>(agentCard);

var app = builder.Build();

app.MapA2A("/a2a");
app.MapWellKnownAgentCard(agentCard, "/a2a");

app.Run();


internal sealed class AIAgentHandler(AIAgent agent) : IAgentHandler
{
    public async Task ExecuteAsync(RequestContext context, AgentEventQueue eventQueue, CancellationToken cancellationToken)
    {
        var input = string.Concat(context.Message.Parts.Select(p => p.Text ?? string.Empty));
        AgentSession session = await agent.CreateSessionAsync(cancellationToken);
        AgentResponse response = await agent.RunAsync(input, session, cancellationToken: cancellationToken);

        var responder = new MessageResponder(eventQueue, context.ContextId);
        await responder.ReplyAsync(response.ToString(), cancellationToken: cancellationToken);
    }

    public Task CancelAsync(RequestContext context, AgentEventQueue eventQueue, CancellationToken cancellationToken)
        => Task.CompletedTask;
}

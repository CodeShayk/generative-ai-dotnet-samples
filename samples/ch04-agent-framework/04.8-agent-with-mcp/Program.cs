using System.ComponentModel;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;
using OpenAI;

if (args.Length < 1)
{
    Console.Error.WriteLine("Usage: dotnet run -- <mcp-server-command> [server-args...]");
    Console.Error.WriteLine("Example: dotnet run -- dnx Microsoft.Azure.Mcp --yes");
    return 1;
}

var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
    ?? throw new InvalidOperationException("Set OPENAI_API_KEY.");

var transport = new StdioClientTransport(new StdioClientTransportOptions
{
    Command = args[0],
    Arguments = args.Skip(1).ToArray(),
});

// Wait for the server/discover probe's answer so a slow-starting server does not see
// the initialize fallback as well. See 05.4-mcp-client for the full explanation.
await using var mcp = await McpClient.CreateAsync(
    transport,
    new McpClientOptions { DiscoverProbeTimeout = Timeout.InfiniteTimeSpan });
IList<McpClientTool> mcpTools = await mcp.ListToolsAsync();

// Mix one local C# tool with all the MCP-sourced tools (McpClientTool : AIFunction : AITool).
List<AITool> tools =
[
    AIFunctionFactory.Create(GetCurrentLocalTime),
    .. mcpTools.Cast<AITool>(),
];

IChatClient chat = new OpenAIClient(apiKey).GetChatClient("gpt-4o-mini").AsIChatClient();

ChatClientAgent agent = new(chat, new ChatClientAgentOptions
{
    Name = "MixedToolsAgent",
    ChatOptions = new ChatOptions
    {
        Instructions = "You can use both local helper tools and MCP-sourced tools.",
        Tools = tools,
    },
});

Console.WriteLine($"Loaded {mcpTools.Count} MCP tool(s) + 1 local tool.");
Console.WriteLine("Ask the agent something. Blank line exits.\n");

AgentSession session = await agent.CreateSessionAsync();
while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) break;
    AgentResponse response = await agent.RunAsync(input, session);
    Console.WriteLine($"[{agent.Name}] {response}\n");
}

return 0;


[Description("Get the current local time on this machine.")]
static string GetCurrentLocalTime() => DateTime.Now.ToString("u");

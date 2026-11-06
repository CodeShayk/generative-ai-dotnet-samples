using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Client;

namespace Ch05.McpAgentFactory;

public sealed class McpServerOptions
{
    public required string Transport { get; init; }
    public string? Command { get; init; }
    public IList<string>? Args { get; init; }
    public string? Url { get; init; }
    public IDictionary<string, string?>? EnvironmentVariables { get; init; }
}

public sealed class AgentDefinitionOptions
{
    public required string Name { get; init; }
    public required string Instructions { get; init; }
    public IList<McpServerOptions> McpServers { get; init; } = new List<McpServerOptions>();
}

public sealed class McpAgentFactory(
    IChatClient chat,
    ILogger<McpAgentFactory> logger) : IAsyncDisposable
{
    private readonly List<McpClient> _clients = new();

    public async Task<AIAgent> CreateAsync(AgentDefinitionOptions opts, CancellationToken ct = default)
    {
        var tools = new List<AITool>();

        foreach (var server in opts.McpServers)
        {
            try
            {
                IClientTransport transport = BuildTransport(server);
                // Wait for the server/discover probe's answer so a slow-starting server does
                // not see the initialize fallback as well. See 05.4-mcp-client for the details.
                McpClient client = await McpClient.CreateAsync(
                    transport,
                    new McpClientOptions { DiscoverProbeTimeout = Timeout.InfiniteTimeSpan },
                    cancellationToken: ct);
                _clients.Add(client);

                IList<McpClientTool> serverTools = await client.ListToolsAsync(cancellationToken: ct);
                var prefix = SanitizeName(server.Command ?? server.Url ?? "mcp");
                foreach (var t in serverTools)
                {
                    tools.Add(t.WithName($"{prefix}_{t.Name}"));
                }

                logger.LogInformation(
                    "Connected to MCP server '{Server}'. Tools loaded: {Count}.",
                    server.Url ?? server.Command, serverTools.Count);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to connect to MCP server '{Server}'.",
                    server.Url ?? server.Command);
                throw;
            }
        }

        return new ChatClientAgent(chat, new ChatClientAgentOptions
        {
            Name = opts.Name,
            ChatOptions = new ChatOptions
            {
                Instructions = opts.Instructions,
                Tools = tools,
            },
        });
    }

    private static IClientTransport BuildTransport(McpServerOptions opts) =>
        opts.Transport.ToLowerInvariant() switch
        {
            "stdio" => new StdioClientTransport(new StdioClientTransportOptions
            {
                Command = opts.Command!,
                Arguments = opts.Args?.ToArray() ?? [],
                EnvironmentVariables = opts.EnvironmentVariables
            }),
            // "http" and "sse" both map to the streamable HTTP transport in MCP 1.x.
            // SSE-only servers can still be reached, since streamable HTTP negotiates
            // down to SSE when the server does not support upgrade.
            "http" or "sse" => new HttpClientTransport(new HttpClientTransportOptions
            {
                Endpoint = new Uri(opts.Url!)
            }),
            _ => throw new InvalidOperationException($"Unknown transport: {opts.Transport}")
        };

    private static string SanitizeName(string raw) =>
        new string(raw.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();

    public async ValueTask DisposeAsync()
    {
        foreach (var c in _clients)
        {
            await c.DisposeAsync();
        }
    }
}

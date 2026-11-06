using Ch05.CachedMcpToolProvider;
using ModelContextProtocol.Client;

if (args.Length < 1)
{
    Console.Error.WriteLine("Usage: dotnet run -- <mcp-server-command> [server-args...]");
    Console.Error.WriteLine("Example: dotnet run -- dotnet run --project ../05.2.10-inventory-server");
    return 1;
}

var transport = new StdioClientTransport(new StdioClientTransportOptions
{
    Command = args[0],
    Arguments = args.Skip(1).ToArray(),
});

// Wait for the server/discover probe's answer so a slow-starting server does not see
// the initialize fallback as well. See 05.4-mcp-client for the full explanation.
await using var client = await McpClient.CreateAsync(
    transport,
    new McpClientOptions { DiscoverProbeTimeout = Timeout.InfiniteTimeSpan });
await using var provider = new CachedMcpToolProvider(client);

Console.WriteLine("First call -- fetches and caches:");
var firstCall = await provider.GetToolsAsync();
PrintTools(firstCall);

Console.WriteLine("\nSecond call -- served from cache:");
var secondCall = await provider.GetToolsAsync();
PrintTools(secondCall);

Console.WriteLine("\n(If the server emits a tools/list_changed notification, the cache is invalidated.)");

return 0;


static void PrintTools(IList<McpClientTool> tools)
{
    foreach (var tool in tools)
    {
        Console.WriteLine($"  - {tool.Name,-30} {tool.Description}");
    }
}

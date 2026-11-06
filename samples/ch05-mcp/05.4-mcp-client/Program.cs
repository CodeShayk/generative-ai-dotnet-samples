using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;

if (args.Length < 1)
{
    Console.Error.WriteLine("Usage: dotnet run -- <stdio | http> [endpoint-or-command...]");
    Console.Error.WriteLine();
    Console.Error.WriteLine("  stdio examples:");
    Console.Error.WriteLine("    dotnet run -- stdio dnx Microsoft.Azure.Mcp --yes");
    Console.Error.WriteLine("    dotnet run -- stdio dotnet run --project ../05.2.10-inventory-server");
    Console.Error.WriteLine();
    Console.Error.WriteLine("  http example:");
    Console.Error.WriteLine("    dotnet run -- http http://localhost:5183/mcp");
    return 1;
}

IClientTransport transport = args[0].ToLowerInvariant() switch
{
    "stdio" => new StdioClientTransport(new StdioClientTransportOptions
    {
        Command = args[1],
        Arguments = args.Skip(2).ToArray(),
    }),
    "http" => new HttpClientTransport(new HttpClientTransportOptions
    {
        Endpoint = new Uri(args[1]),
    }),
    _ => throw new InvalidOperationException("First arg must be 'stdio' or 'http'.")
};

// By default an MCP 2.x client gives up on its server/discover probe after 5 seconds
// and sends initialize on the same connection. A server still starting up (dotnet run,
// dnx) can then read both requests and reject initialize, so wait for the probe's answer.
// Older servers still work: they answer that the method is unknown, and the client falls back.
// Tracked upstream as modelcontextprotocol/csharp-sdk#1954; the fix is not in 2.3.1.
await using var client = await McpClient.CreateAsync(
    transport,
    new McpClientOptions { DiscoverProbeTimeout = Timeout.InfiniteTimeSpan });

Console.WriteLine($"Connected. Server: {client.ServerInfo?.Name ?? "(unknown)"}");
Console.WriteLine();

Console.WriteLine("Tools:");
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"  - {tool.Name,-30} {tool.Description}");
}

Console.WriteLine();
Console.WriteLine("Type a tool name and JSON arguments to invoke it (blank line to quit).");
Console.WriteLine("Example:  Echo {\"message\":\"hi\"}");

while (true)
{
    Console.Write("\n> ");
    var line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line)) break;

    var split = line.IndexOf(' ');
    var name = split < 0 ? line : line[..split];
    var argsJson = split < 0 ? "{}" : line[(split + 1)..];

    try
    {
        var doc = System.Text.Json.JsonDocument.Parse(argsJson);
        var dict = new Dictionary<string, object?>();
        foreach (var prop in doc.RootElement.EnumerateObject())
        {
            dict[prop.Name] = prop.Value.ValueKind switch
            {
                System.Text.Json.JsonValueKind.String => prop.Value.GetString(),
                System.Text.Json.JsonValueKind.Number => prop.Value.GetDouble(),
                System.Text.Json.JsonValueKind.True => true,
                System.Text.Json.JsonValueKind.False => false,
                _ => prop.Value.ToString(),
            };
        }

        var result = await client.CallToolAsync(name, dict);
        foreach (var content in result.Content)
        {
            if (content is TextContentBlock tc) Console.WriteLine(tc.Text);
            else Console.WriteLine($"({content.GetType().Name})");
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"ERROR: {ex.Message}");
    }
}

return 0;

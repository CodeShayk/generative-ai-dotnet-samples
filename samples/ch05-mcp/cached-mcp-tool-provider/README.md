# Chapter 5 -- CachedMcpToolProvider (Critical-1 fix)

Companion code for **Generative AI in .NET**, Chapter 5 (~line 1384) and the Critical-1 fix from `review-action-plan.md`.

A small helper that caches the tool list returned by an `McpClient` and invalidates the cache when the server emits a `notifications/tools/list_changed` notification.

This sample exists primarily so readers can see the corrected class -- the original draft had a constructor chaining bug (`public CachedMcpToolProvider(McpClient client) : this(client)` -- recursive). The fixed version assigns the field directly from the parameter and subscribes to the change-notification stream.

## Run it

The demo requires a real MCP server to connect to. Pass the spawn command as arguments:

```bash
dotnet run --project samples/ch05-mcp/cached-mcp-tool-provider -- dnx Microsoft.Azure.Mcp --yes
```

Or use any other stdio-based MCP server. Expected output:

```
First call -- fetches from server.
  N tool(s):
    - tool_a
    - tool_b
    ...

Second call -- served from cache.
  N tool(s) (cached=True)
```

## Manuscript reference

- `Manuscript/Chapter-05.md`, section 5.4.2 (~line 1384).
- `Manuscript/review-01.md`, item C1.

## Prerequisites

- .NET 10 SDK
- An MCP server you can spawn over stdio (Azure MCP, the `05.3.2-sse-transport` sample's HTTP version, etc.)

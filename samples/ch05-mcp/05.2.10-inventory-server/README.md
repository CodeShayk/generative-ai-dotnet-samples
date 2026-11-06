# Chapter 5.2.10 -- Inventory MCP Server Walkthrough

Companion code for **Generative AI in .NET**, Chapter 5 section 5.2.10.

A complete MCP server with all three primitive types and a NuGet-publish-ready manifest:

| Concern | File |
|---|---|
| Tools (`search`, `get`, `stock`) | `Tools/InventoryTools.cs` |
| Resources (`inventory://categories`) | `Resources/CategoryResources.cs` |
| Prompts (`Describe`) | `Prompts/ProductDescriptionPrompts.cs` |
| Data (in-memory store) | `Data/InventoryDb.cs` |
| Host bootstrap | `Program.cs` |
| MCP package manifest | `.mcp/server.json` |

The csproj sets `<PackageType>McpServer</PackageType>` and packs `.mcp/server.json` -- so `dotnet pack` produces a NuGet package discoverable under the `packagetype=mcpserver` filter.

## Run it

Stdio (the default for IDE/agent integration):

```bash
dotnet run --project samples/ch05-mcp/05.2.10-inventory-server
```

Then connect any MCP client -- the `samples/ch05-mcp/cached-mcp-tool-provider/` and `samples/ch04-agent-framework/04.8-agent-with-mcp/` samples both work.

## Manuscript reference

- `Manuscript/Chapter-05.md`, sections 5.2.2 -- 5.2.10.
- Figure 5.3 ("Inventory MCP Server Anatomy").

## Prerequisites

- .NET 10 SDK.

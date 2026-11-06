# Chapter 5.4 -- MCP Client REPL

Companion code for **Generative AI in .NET**, Chapter 5 sections 5.4.1 -- 5.4.3.

An interactive MCP client. Connect over stdio or streamable HTTP, list the discovered tools, and invoke any tool with JSON arguments. Useful for exploring an unknown server or smoke-testing your own.

## Run it

```bash
# Stdio: spawn an MCP server as a child process.
dotnet run --project samples/ch05-mcp/05.4-mcp-client -- \
  stdio dotnet run --project samples/ch05-mcp/05.2.10-inventory-server

# HTTP: connect to a running streamable-HTTP server.
dotnet run --project samples/ch05-mcp/05.4-mcp-client -- http http://localhost:5183/mcp
```

Then at the `>` prompt:

```
> Search {"query":"earbuds"}
> Stock {"sku":"ECC-100"}
```

## Manuscript reference

- `Manuscript/Chapter-05.md`, sections 5.4.1 (creating an `McpClient`), 5.4.2 (discovering tools), 5.4.3 (invoking).

## Prerequisites

- .NET 10 SDK; an MCP server reachable over stdio or HTTP.

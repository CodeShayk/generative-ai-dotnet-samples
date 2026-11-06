# Chapter 5.3.1 -- Stdio Transport

Companion code for **Generative AI in .NET**, Chapter 5 section 5.3.1 ("Stdio Transport: Simplest Path for Local and CLI Scenarios").

A minimal MCP server that runs as a child process, communicating with the host over stdin/stdout. The sample also demonstrates the rule for stdio servers: **never log to stdout** -- it's reserved for JSON-RPC. All logs go to stderr.

## Run it

You don't run a stdio server directly -- you spawn it from an MCP host. From any MCP client sample (e.g. `cached-mcp-tool-provider`) point the spawn command at this server's binary:

```bash
dotnet build samples/ch05-mcp/05.3.1-stdio-transport
# Then use the produced executable as the spawn command in an MCP client config.
```

## Manuscript reference

- `Manuscript/Chapter-05.md`, section 5.3.1.
- Figure 5.4 ("MCP Transport Options"), left column.

## Prerequisites

- .NET 10 SDK.

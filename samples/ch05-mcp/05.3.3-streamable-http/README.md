# Chapter 5.3.3 -- Streamable HTTP Transport

Companion code for **Generative AI in .NET**, Chapter 5 section 5.3.3 ("Streamable HTTP: The Modern HTTP Transport").

The recommended HTTP transport for new MCP servers. A single `/mcp` endpoint accepts `POST` with `Accept: application/json, text/event-stream` -- the server decides per request whether to return a single JSON response or stream events.

## Run it

```bash
dotnet run --project samples/ch05-mcp/05.3.3-streamable-http
```

The server listens on `http://localhost:5183`. Pair with `StreamableHttpClientTransport` from any MCP client sample.

## Manuscript reference

- `Manuscript/Chapter-05.md`, section 5.3.3.
- Figure 5.4 ("MCP Transport Options"), right column.

## Prerequisites

- .NET 10 SDK.

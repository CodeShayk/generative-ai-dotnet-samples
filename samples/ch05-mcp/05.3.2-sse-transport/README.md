# Chapter 5.3.2 -- SSE Transport for MCP Servers

Companion code for **Generative AI in .NET**, Chapter 5 section 5.3.2 ("Server-Sent Events: HTTP-Based Transport for Web Deployments").

A minimal ASP.NET Core MCP server configured with the SSE transport. Exposes one tool (`Echo`) so you can exercise the protocol against a known endpoint.

## Run it

```bash
dotnet run --project samples/ch05-mcp/05.3.2-sse-transport
```

The server listens on `http://localhost:5180`. The MCP endpoints are:

- `GET  /mcp/sse` -- long-lived event stream (open this first).
- `POST /mcp/messages` -- JSON-RPC requests.

## Test with the provided `.http` file

Open `sse.http` in Visual Studio, VS Code (with the REST Client extension), or JetBrains Rider and run the requests in order. Keep the `GET /mcp/sse` request open in one pane so you can see the responses arrive on the event stream.

## Manuscript reference

- `Manuscript/Chapter-05.md`, section 5.3.2.

## Note on transport choice

For new deployments, the manuscript recommends streamable HTTP over SSE -- this sample exists to demonstrate the legacy HTTP transport. See section 5.3.3 for the modern alternative.

## Prerequisites

- .NET 10 SDK
- `ModelContextProtocol` packages (resolved through the central `Directory.Packages.props`).

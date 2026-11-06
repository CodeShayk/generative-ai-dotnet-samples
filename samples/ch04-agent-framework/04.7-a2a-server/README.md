# Chapter 4.7 -- Exposing an Agent over A2A

Companion code for **Generative AI in .NET**, Chapter 4 section 4.7.3 ("Exposing Your Agents via A2A").

Hosts a `ChatClientAgent` behind `MapA2A("/a2a")` so any A2A-compatible client (Python, .NET, TypeScript) can call it over HTTP using the agent card protocol.

> **Preview package**: this sample depends on `Microsoft.Agents.AI.A2A`, currently published as a **preview** on NuGet. The pin in `Directory.Packages.props` is `1.3.0-preview.260423.1`. Bump it as new previews ship.

## Run it

```bash
ollama pull phi4-mini
dotnet run --project samples/ch04-agent-framework/04.7-a2a-server
```

The agent card is served at `http://localhost:5182/a2a/.well-known/agent-card.json`. Discover it from a remote agent or curl it directly:

```bash
curl http://localhost:5182/a2a/.well-known/agent-card.json
```

Pair this with `A2AAgent.ConnectAsync(...)` from a separate program -- see Chapter 4.7.2 for the consumer side.

## Manuscript reference

- `Manuscript/Chapter-04.md`, section 4.7.3.
- Figure 4.9 ("A2A Multi-Agent Architecture").

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

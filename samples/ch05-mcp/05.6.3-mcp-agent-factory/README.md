# Chapter 5.6.3 -- McpAgentFactory

Companion code for **Generative AI in .NET**, Chapter 5 section 5.6.3 ("Agents That Discover Their Tools at Startup via MCP").

A configuration-driven factory that connects an `AIAgent` to one or more MCP servers and exposes the union of their tools to the model. Tool names are namespaced with a server prefix (`flights_search`, `hotels_search`) so the model can disambiguate.

## What's in here

| File | Purpose |
|---|---|
| `McpAgentFactory.cs` | The factory (`McpAgentFactory`) plus its options types (`AgentDefinitionOptions`, `McpServerOptions`). |
| `Program.cs` | Hosts the factory in the generic host, builds the agent at startup, and runs an interactive console loop. |
| `appsettings.json` | Sample agent definition (`TravelPlanner`) wiring three MCP servers across stdio + HTTP transports. |

## Run it

```bash
# Set your OpenAI key (or edit appsettings.json -- but don't commit secrets).
export OPENAI_API_KEY=sk-...

dotnet run --project samples/ch05-mcp/05.6.3-mcp-agent-factory
```

The default `appsettings.json` references illustrative MCP servers (`Contoso.Flights.Mcp`, `Contoso.Hotels.Mcp`, `https://weather.example.com/mcp`) -- swap in your own servers, then ask the agent a question:

```
> Plan a 4-day trip to Reykjavik in June.
```

## Manuscript reference

- `Manuscript/Chapter-05.md`, sections 5.6.3 (factory) and 5.6.5 (Travel Planner walkthrough).

## Anti-pattern note

The book calls out that you should NOT do `services.AddSingleton<AIAgent>(async sp => await factory.CreateAsync(...))` -- the container ends up storing a `Task<AIAgent>` instead of an `AIAgent`. This sample follows the recommended approach: build the agent eagerly *after* `host.Build()` and use it directly, or publish it through your own registry.

## Prerequisites

- .NET 10 SDK
- An OpenAI API key (or any `IChatClient` provider you wire up).
- One or more reachable MCP servers (the sample's defaults are placeholders -- substitute real ones).

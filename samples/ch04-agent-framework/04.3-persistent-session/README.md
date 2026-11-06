# Chapter 4.3 -- Persistent Agent Sessions

Companion code for **Generative AI in .NET**, Chapter 4 section 4.3.3 ("Session Serialization and Restoration").

Demonstrates the serialize/deserialize round trip on `AgentThread`. The first run starts a fresh conversation; subsequent runs reload `thread.json` and continue where you left off.

## Run it

```bash
ollama pull phi4-mini

# First run -- create a thread.
dotnet run --project samples/ch04-agent-framework/04.3-persistent-session
> My favourite colour is teal.
> 

# Second run -- it remembers.
dotnet run --project samples/ch04-agent-framework/04.3-persistent-session
> What did I tell you about colours?
```

## Manuscript reference

- `Manuscript/Chapter-04.md`, sections 4.3.1 (`AgentThread`) and 4.3.3 (serialization).

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

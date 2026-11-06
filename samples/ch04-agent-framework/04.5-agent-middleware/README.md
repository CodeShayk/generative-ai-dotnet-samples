# Chapter 4.5 -- Agent Middleware

Companion code for **Generative AI in .NET**, Chapter 4 sections 4.5.1 -- 4.5.4 ("Agent Run Middleware" and "Building the Middleware Pipeline").

Wraps an agent in a small **agent run middleware** that logs the start and end of every `RunAsync` call. The same `Use(...)` builder pattern works for input filtering, rate limiting, output redaction, etc.

## Run it

```bash
ollama pull phi4-mini
dotnet run --project samples/ch04-agent-framework/04.5-agent-middleware
```

## Manuscript reference

- `Manuscript/Chapter-04.md`, sections 4.5.1 -- 4.5.4.
- Figure 4.6 ("The Three Middleware Layers").

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

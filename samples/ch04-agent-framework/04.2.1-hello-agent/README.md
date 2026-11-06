# Chapter 4.2.1 -- Hello, ChatClientAgent

Companion code for **Generative AI in .NET**, Chapter 4 section 4.2.1.

The smallest possible Microsoft Agent Framework program: build a `ChatClientAgent` over any `IChatClient`, give it a name + instructions, and run it. State lives in an `AgentThread` returned by `GetNewThread()` so each turn carries the previous context.

## Run it

```bash
ollama pull phi4-mini
dotnet run --project samples/ch04-agent-framework/04.2.1-hello-agent
```

## Manuscript reference

- `Manuscript/Chapter-04.md`, sections 4.1.3 (`AIAgent`), 4.2.1 (`ChatClientAgent`), 4.3.1 (`AgentThread`).
- Figure 4.1 ("What an Agent Is").

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

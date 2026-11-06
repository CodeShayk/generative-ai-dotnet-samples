# Chapter 2.1 -- Console Chat Loop with History

Companion code for **Generative AI in .NET**, Chapter 2 section 2.1.5.

A REPL that maintains conversation history, streams responses, and applies a sliding-window trim so the context window never explodes.

## Run it

```bash
ollama pull phi4-mini
dotnet run --project samples/ch02-extensions-ai/02.1-console-chat-loop
```

## Manuscript reference

- `Manuscript/Chapter-02.md`, sections 2.1.2 (context-window budget) and 2.1.5 (the chat loop).

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

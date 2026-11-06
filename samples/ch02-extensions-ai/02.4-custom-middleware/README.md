# Chapter 2.4 -- Custom Middleware: Token Budget Enforcement

Companion code for **Generative AI in .NET**, Chapter 2 section 2.4.5 ("Writing a Custom Middleware: Rate Limiting and Token Budget Enforcement").

A custom `DelegatingChatClient` that tracks total tokens consumed per UTC day and short-circuits the pipeline when the budget is exceeded. The sample sets a small budget (200 tokens) so you can see it trip after one or two completions.

## Run it

```bash
ollama pull phi4-mini
dotnet run --project samples/ch02-extensions-ai/02.4-custom-middleware
```

## Manuscript reference

- `Manuscript/Chapter-02.md`, section 2.4.5.

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

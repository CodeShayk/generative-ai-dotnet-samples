# Chapter 2.4 -- Composing the Middleware Pipeline

Companion code for **Generative AI in .NET**, Chapter 2 sections 2.4.1 -- 2.4.6.

Wraps an Ollama `IChatClient` with the standard middleware stack -- logging + distributed (in-memory) caching -- and demonstrates a cache hit on the second identical prompt.

## Run it

```bash
ollama pull phi4-mini
dotnet run --project samples/ch02-extensions-ai/02.4-middleware-pipeline
```

You should see the second request return in milliseconds and the third request go back to the model.

## Manuscript reference

- `Manuscript/Chapter-02.md`, sections 2.4.2 (caching), 2.4.4 (logging), 2.4.6 (DI composition).
- Figure 2.6 ("The Middleware Pipeline").

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

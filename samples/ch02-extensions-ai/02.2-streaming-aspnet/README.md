# Chapter 2.2 -- Streaming over SSE in a Minimal API

Companion code for **Generative AI in .NET**, Chapter 2 section 2.2.2.

A Minimal API that exposes `POST /api/chat/stream` returning Server-Sent Events. The bundled `GET /` page contains a tiny browser client that consumes the stream live.

## Run it

```bash
ollama pull phi4-mini
dotnet run --project samples/ch02-extensions-ai/02.2-streaming-aspnet
```

Open http://localhost:5181/, click **Send**, and watch the tokens stream in.

## Manuscript reference

- `Manuscript/Chapter-02.md`, section 2.2.1 (`GetStreamingResponseAsync` and `IAsyncEnumerable`) and 2.2.2 (SSE in ASP.NET Core).

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

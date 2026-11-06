# Chapter 1.3 -- Hello, IChatClient

Companion code for **Generative AI in .NET**, Chapter 1 sections 1.3.2 -- 1.3.3.

A console hello-world that calls `IChatClient` with a small recipe-assistant system prompt, then streams a follow-up turn. Provider is selectable at run time -- Ollama (default, offline), OpenAI direct, or GitHub Models.

## Run it

```bash
# Default: Ollama with phi4-mini on localhost:11434
dotnet run --project samples/ch01-foundations/01.3-hello-chat

# OpenAI direct
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch01-foundations/01.3-hello-chat -- openai

# GitHub Models
export GITHUB_TOKEN=ghp_...
dotnet run --project samples/ch01-foundations/01.3-hello-chat -- github
```

## What it shows

- Constructing `IChatClient` from three different providers behind a single interface.
- Building a `List<ChatMessage>` with system + user turns.
- Calling both `GetResponseAsync` (full response) and `GetStreamingResponseAsync` (token stream).
- Using `AddMessages` to grow the history correctly between turns.

## Manuscript reference

- `Manuscript/Chapter-01.md`, sections 1.3.2 (project setup) and 1.3.3 (the IChatClient contract).

## Prerequisites

- .NET 10 SDK.
- Optional: Ollama running locally with `phi4-mini` pulled (`ollama pull phi4-mini`).
- Optional: `OPENAI_API_KEY` or `GITHUB_TOKEN` for cloud providers.

# Chapter 2.3 -- Function Calling Walkthrough

Companion code for **Generative AI in .NET**, Chapter 2 section 2.3.6 ("A Weather + Calendar Assistant with Three Tools").

Wires three plain-old C# methods (`GetWeather`, `ListEvents`, `SendReminder`) into an `IChatClient` via `UseFunctionInvocation()` and lets the model choose which to call to satisfy a multi-part user request.

## Run it

```bash
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch02-extensions-ai/02.3-function-calling
```

## What it shows

- Building tools from local methods with `AIFunctionFactory.Create(...)`.
- Composing the function-invocation middleware with `ChatClientBuilder.UseFunctionInvocation()`.
- A single user prompt that triggers parallel tool calls -- weather, calendar, and reminder.

## Manuscript reference

- `Manuscript/Chapter-02.md`, sections 2.3.1 -- 2.3.6.
- Figure 2.4 ("The Function Calling Sequence") and 2.5 ("Multi-Tool Orchestration Flow").

## Prerequisites

- .NET 10 SDK and an OpenAI API key.

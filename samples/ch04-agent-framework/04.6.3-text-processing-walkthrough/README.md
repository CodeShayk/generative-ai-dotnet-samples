# Chapter 4.6.3 -- Text Processing Workflow Walkthrough

Companion code for **Generative AI in .NET**, Chapter 4 section 4.6.3 ("Building Your First Workflow").

A minimal `Microsoft.Agents.AI.Workflows` pipeline: input -> uppercase -> reverse -> output. Demonstrates `WorkflowBuilder`, `Executor.From<,>`, `SetStartExecutor`, `AddEdge`, `SetOutputExecutor`, plus the streaming event API via `RunStreamingAsync`.

## Run it

```bash
dotnet run --project samples/ch04-agent-framework/04.6.3-text-processing-walkthrough
```

Expected output:

```
Result: !TNEGA ,OLLEH

Streaming events:
  executor done: uppercase
  executor done: reverse
  output: OMED GNIMAERTS
```

## Manuscript reference

- `Manuscript/Chapter-04.md`, section 4.6.3
- The walkthrough uses `Microsoft.Agents.AI.Workflows`. No model provider, no API key required.

## Prerequisites

- .NET 10 SDK

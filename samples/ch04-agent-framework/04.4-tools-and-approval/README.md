# Chapter 4.4 -- Tools and Approval

Companion code for **Generative AI in .NET**, Chapter 4 sections 4.4.2 (function tools) and 4.4.3 (tool approval / human-in-the-loop).

A two-tool agent. `GetCustomer` is plain-old function-tool. `DeleteCustomerProtected` is annotated with `[RequiresApproval]` -- the marker attribute the manuscript uses to opt a tool into the approval round-trip.

The sample is intentionally illustrative: the agent invokes both tools so you can see the natural-language flow. In a production setup, the function-invocation middleware would inspect the attribute and emit a `FunctionApprovalRequest` instead of calling the protected delegate directly.

## Run it

```bash
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch04-agent-framework/04.4-tools-and-approval
```

## Manuscript reference

- `Manuscript/Chapter-04.md`, sections 4.4.2 -- 4.4.3.
- Figure 4.5 ("Tool Approval Flow").

## Prerequisites

- .NET 10 SDK and an OpenAI API key.

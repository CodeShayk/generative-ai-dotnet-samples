# Chapter 4.6.7 -- Multi-Agent Content Workflow

Companion code for **Generative AI in .NET**, Chapter 4 section 4.6.7 ("A Complete Multi-Agent Workflow").

Three agents -- Researcher, Writer, Editor -- composed as a `Microsoft.Agents.AI.Workflows` graph. Each agent does one job. The Editor returns a JSON quality verdict that feeds the next pipeline stage in the printed walkthrough (rewrite-on-low-quality, fact-check fan-out). This sample is the linear core; extend it by adding the conditional rewrite edge from the manuscript.

## Run it

```bash
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch04-agent-framework/04.6.7-content-workflow
```

## Manuscript reference

- `Manuscript/Chapter-04.md`, section 4.6.7.
- Figure 4.8 ("Multi-Agent Content Production Workflow").

## Prerequisites

- .NET 10 SDK and an OpenAI API key.

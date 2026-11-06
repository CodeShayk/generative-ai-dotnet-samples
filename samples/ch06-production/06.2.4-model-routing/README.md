# Chapter 6.2.4 -- Cost-Aware Model Routing

Companion code for **Generative AI in .NET**, Chapter 6 section 6.2.4 ("Routing Simple Tasks to Cheaper Models").

A two-step pipeline: **classify** the query with `gpt-4o-mini`, then **route** it -- simple queries are answered by the cheap model, complex queries are escalated to `gpt-4o`. The book's economic case is that ~70% of typical traffic is "simple" and can be served at one-tenth the cost.

## Run it

```bash
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch06-production/06.2.4-model-routing
```

## Manuscript reference

- `Manuscript/Chapter-06.md`, section 6.2.4.
- Figure 6.3 ("Cost-Aware Model Routing Decision Tree").

## Prerequisites

- .NET 10 SDK and an OpenAI API key.

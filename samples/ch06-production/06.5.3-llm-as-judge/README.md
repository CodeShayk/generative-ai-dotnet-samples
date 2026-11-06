# Chapter 6.5.3 -- Evaluation with LLM-as-Judge

Companion code for **Generative AI in .NET**, Chapter 6 section 6.5.3 ("Evaluation-Driven Testing: Scoring Quality with LLM-as-Judge").

A two-model evaluation pipeline. The **producer** model answers each question; the **judge** model scores the answer 1-5 on relevance, groundedness, and coherence using `GetResponseAsync<JudgeVerdict>(...)` so the verdict deserializes into a typed record.

This is the same pattern as the Chapter 3 RAG evaluator, applied to plain Q&A rather than retrieved context.

## Run it

```bash
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch06-production/06.5.3-llm-as-judge
```

## Manuscript reference

- `Manuscript/Chapter-06.md`, section 6.5.3.
- Figure 6.6 ("Testing Pyramid for AI Applications") -- this is Tier 3.

## Prerequisites

- .NET 10 SDK and an OpenAI API key.

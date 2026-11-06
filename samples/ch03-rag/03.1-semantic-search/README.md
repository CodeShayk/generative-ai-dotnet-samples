# Chapter 3.1 -- Semantic Search Hello World

Companion code for **Generative AI in .NET**, Chapter 3 sections 3.1.1 -- 3.1.5.

A six-row in-memory product catalog. Embeddings are generated once at startup (Ollama `nomic-embed-text`), then each query is embedded and ranked by cosine similarity. No vector store dependency -- intentionally minimal so the search math is visible.

## Run it

```bash
ollama pull nomic-embed-text
dotnet run --project samples/ch03-rag/03.1-semantic-search
```

Try: `wireless earbuds for running`, `cheap mouse`, `comfy mechanical keyboard`.

## Manuscript reference

- `Manuscript/Chapter-03.md`, sections 3.1.1 (text-to-vectors) and 3.1.5 (similarity search).
- Figure 3.1 ("From Text to Vectors") and 3.3 ("Semantic Search Query Flow").

## Prerequisites

- .NET 10 SDK, Ollama with `nomic-embed-text`.

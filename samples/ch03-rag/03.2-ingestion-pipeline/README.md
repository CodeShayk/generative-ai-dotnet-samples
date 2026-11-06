# Chapter 3.2 -- Document Ingestion Pipeline

Companion code for **Generative AI in .NET**, Chapter 3 section 3.2.2.

Walks two markdown documents through the canonical ingest stages: **load -> chunk (with overlap) -> embed -> upsert**, with a SHA-256 content hash on each chunk so re-runs can be made idempotent.

## Run it

```bash
ollama pull nomic-embed-text
dotnet run --project samples/ch03-rag/03.2-ingestion-pipeline
```

## Manuscript reference

- `Manuscript/Chapter-03.md`, section 3.2.2 (and Figure 3.5 -- "Document Ingestion Pipeline").

## Prerequisites

- .NET 10 SDK, Ollama with `nomic-embed-text`.

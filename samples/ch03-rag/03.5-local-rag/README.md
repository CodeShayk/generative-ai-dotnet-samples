# Chapter 3.5 -- Local-First RAG with Ollama

Companion code for **Generative AI in .NET**, Chapter 3 section 3.5.1 ("Ollama: Pull, Run, and Integrate Local Models") and Figure 3.13 ("Local-First RAG Architecture").

End-to-end RAG with **zero cloud calls and zero API keys**. Two Ollama models (chat + embeddings) on localhost, an in-memory vector store driven from a plain text file. Runs on a laptop on a plane.

## Run it

```bash
ollama pull phi4-mini
ollama pull nomic-embed-text
dotnet run --project samples/ch03-rag/03.5-local-rag
```

The first run creates a `knowledge.txt` with sample policies. Edit it -- and the index updates on the next run.

## Manuscript reference

- `Manuscript/Chapter-03.md`, section 3.5.1.
- Figure 3.13 ("Local-First RAG Architecture").

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini` and `nomic-embed-text`.

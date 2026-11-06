# Chapter 3.2 -- RAG Walkthrough (Retrieve, Augment, Generate)

Companion code for **Generative AI in .NET**, Chapter 3 sections 3.2.1 -- 3.2.6.

A complete RAG loop in ~50 lines. A tiny in-memory policy "knowledge base" is embedded once. For each user question we retrieve the top-3 chunks, augment a prompt with `[policy-id]` markers, and stream a grounded answer back.

## Run it

```bash
ollama pull nomic-embed-text
ollama pull phi4-mini
dotnet run --project samples/ch03-rag/03.2-rag-basic
```

Try: `How do I cancel my subscription?` or `What is your refund window?`

## Manuscript reference

- `Manuscript/Chapter-03.md`, sections 3.2.1 (the pattern), 3.2.5 (prompt augmentation), 3.2.6 (citation).
- Figure 3.4 ("The Three Phases of RAG").

## Prerequisites

- .NET 10 SDK, Ollama with `nomic-embed-text` and `phi4-mini`.

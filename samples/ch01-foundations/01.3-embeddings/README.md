# Chapter 1.3 -- Hello, IEmbeddingGenerator

Companion code for **Generative AI in .NET**, Chapter 1 section 1.3.4 ("IEmbeddingGenerator -- Turning Meaning into Vectors").

Embeds three sentences with a local Ollama model and prints the pairwise cosine similarities. The two cat-related sentences land close together; the financial sentence is far away.

## Run it

```bash
ollama pull nomic-embed-text
dotnet run --project samples/ch01-foundations/01.3-embeddings
```

Expected output (numbers vary by model and version):

```
Vector dimensions: 768

  cos(0,1) = 0.872   (The cat sat on the mat. <-> A feline rested on the rug.)
  cos(0,2) = 0.293   (The cat sat on the mat. <-> Quarterly revenue grew 12 ...)
  cos(1,2) = 0.288   (A feline rested on the rug. <-> Quarterly revenue grew ...)
```

## Manuscript reference

- `Manuscript/Chapter-01.md`, section 1.3.4.
- Figure 3.1 ("From Text to Vectors") visualizes this exact comparison.

## Prerequisites

- .NET 10 SDK.
- Ollama with the `nomic-embed-text` model pulled.

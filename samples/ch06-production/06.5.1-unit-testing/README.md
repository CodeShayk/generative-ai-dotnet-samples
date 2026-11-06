# Chapter 6.5.1 -- Unit Testing with a Stub IChatClient

Companion code for **Generative AI in .NET**, Chapter 6 section 6.5.1 ("Unit Testing with Mock IChatClient and IEmbeddingGenerator").

A self-contained xUnit project demonstrating the canonical pattern: a `StubChatClient` records every `messages` argument it receives and returns a queued reply. Tests assert that a service constructs the prompt correctly **without** any model round-trip. Fast, deterministic, free.

## Run it

```bash
dotnet test samples/ch06-production/06.5.1-unit-testing
```

## What it shows

- A reusable `StubChatClient` that's a fraction of the size of a mocking-framework setup.
- Two tests: one asserts prompt structure; the other asserts graceful handling of an empty response.

## Manuscript reference

- `Manuscript/Chapter-06.md`, section 6.5.1.
- Figure 6.6 ("Testing Pyramid for AI Applications").

## Prerequisites

- .NET 10 SDK.

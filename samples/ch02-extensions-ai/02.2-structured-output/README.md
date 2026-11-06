# Chapter 2.2 -- Structured Output to a C# Record

Companion code for **Generative AI in .NET**, Chapter 2 sections 2.2.3 and 2.2.4.

Demonstrates `IChatClient.GetResponseAsync<T>(...)` -- one call extracts a strongly-typed `FlightBooking` record from a free-text confirmation message. `Description` attributes drive the auto-generated JSON schema sent with the request.

## Run it

```bash
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch02-extensions-ai/02.2-structured-output
```

## Manuscript reference

- `Manuscript/Chapter-02.md`, sections 2.2.3 (JSON Schema response format) and 2.2.4 (deserialization to records).
- Figure 2.3 ("Structured Output Pipeline").

## Prerequisites

- .NET 10 SDK and an OpenAI API key (any provider that supports JSON mode works -- see the OpenAI / Azure OpenAI / Anthropic notes in the manuscript).

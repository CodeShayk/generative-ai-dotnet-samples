# Chapter 6.2.1 -- Resilience Pipeline

Companion code for **Generative AI in .NET**, Chapter 6 section 6.2.1.

Wires `AddStandardResilienceHandler` (retry + circuit breaker + per-attempt + total timeout + bulkhead) into an `HttpClient`, then drives it with a stub handler that returns 503 twice before succeeding. You see the retry pipeline absorb the transient failures.

## Run it

```bash
dotnet run --project samples/ch06-production/06.2.1-resilience
```

Expected output:

```
Sending request through the standard resilience pipeline...
Status: OK (after 3 HTTP attempt(s))
```

## Manuscript reference

- `Manuscript/Chapter-06.md`, section 6.2.1.
- Figure 6.2 ("Resilience Pipeline").

## Prerequisites

- .NET 10 SDK.

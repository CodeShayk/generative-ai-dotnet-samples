# Chapter 6.1 -- Observability with OpenTelemetry

Companion code for **Generative AI in .NET**, Chapter 6 sections 6.1.2 -- 6.1.3 ("Distributed Tracing with OpenTelemetry" and "Token Usage Tracking").

Wraps an `IChatClient` with `UseOpenTelemetry(...)` and configures an OTel pipeline that prints spans to the console and (optionally) exports OTLP to a collector. Each chat call shows up as a span with `gen_ai.*` attributes -- model, system, input/output token counts.

## Run it

```bash
ollama pull phi4-mini
dotnet run --project samples/ch06-production/06.1-observability
```

To send spans to a real collector (Jaeger / Application Insights / Grafana Tempo):

```bash
export OTEL_EXPORTER_OTLP_ENDPOINT=http://localhost:4317
dotnet run --project samples/ch06-production/06.1-observability
```

## Manuscript reference

- `Manuscript/Chapter-06.md`, sections 6.1.2 -- 6.1.4.
- Figure 6.1 ("AI Pipeline Observability Architecture").

## Prerequisites

- .NET 10 SDK, Ollama with `phi4-mini`.

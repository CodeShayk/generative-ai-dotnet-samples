# Chapter 3.3 -- Vision: Receipt Image to Structured Object

Companion code for **Generative AI in .NET**, Chapter 3 sections 3.3.1 -- 3.3.4 (and the expense-processor walkthrough in 3.3.5).

Sends a receipt image to a multimodal `IChatClient` and parses the response into a strongly-typed `Receipt` record (vendor, date, total, line items). The demo combines two patterns from Chapter 2 -- multimodal input (`DataContent`) and structured output (`GetResponseAsync<T>()`).

## Run it

```bash
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch03-rag/03.3-vision-extract -- /path/to/receipt.jpg
```

## Manuscript reference

- `Manuscript/Chapter-03.md`, sections 3.3.1 (multimodal chat) and 3.3.4 (structured extraction).
- Figure 3.10 ("Expense Report Processor").

## Prerequisites

- .NET 10 SDK and an OpenAI API key (or any vision-capable `IChatClient` provider).

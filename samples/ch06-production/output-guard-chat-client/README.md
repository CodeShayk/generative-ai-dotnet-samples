# Chapter 6 -- OutputGuardChatClient (Critical-3 fix)

Companion code for **Generative AI in .NET**, Chapter 6 (~line 816) and the Critical-3 fix from `review-action-plan.md`.

A `DelegatingChatClient` middleware that scans the model's response text for two common attacks before it reaches the UI:

- Markdown image links pointing to non-HTTP(S) URI schemes (`![alt](file:///...)`, `![alt](data:...)`).
- The `javascript:` URI scheme anywhere in the response.

The Critical-3 fix is the `if (response.Text is null) return response;` guard. Earlier drafts dereferenced `response.Text` directly, but the property is null when the assistant returns *only* tool calls or structured output -- the regex calls would NPE on those responses.

## Run it

```bash
dotnet run --project samples/ch06-production/output-guard-chat-client
```

Expected output:

```
RAW (unsafe):
  Click here for a great offer: [link](javascript:alert(1)) and enjoy this picture: ![cat](file:///etc/passwd)

GUARDED:
  Click here for a great offer: [link](blocked-scheme:alert(1)) and enjoy this picture: [blocked image]
```

The demo uses a scripted `StubChatClient` so it runs offline. In production you would chain `OutputGuardChatClient` into your real provider via `ChatClientBuilder.Use(...)`.

## Manuscript reference

- `Manuscript/Chapter-06.md`, section 6.3.2, "Layer 3 -- Output" (~line 816).
- `Manuscript/review-01.md`, item C4.

## Prerequisites

- .NET 10 SDK

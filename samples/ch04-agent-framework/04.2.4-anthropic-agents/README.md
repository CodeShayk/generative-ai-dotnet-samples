# Chapter 4.2.4 -- Anthropic / Claude as a ChatClientAgent

Companion code for **Generative AI in .NET**, Chapter 4 section 4.2.4 ("Anthropic Agents").

Uses an `AnthropicClient` and hands its chat surface to a standard `ChatClientAgent`. The same agent API works against OpenAI, Azure OpenAI, Ollama, etc.

> **Why the local `AnthropicChatClient.cs` shim?** `Anthropic.SDK` 5.10.0 was compiled against `Microsoft.Extensions.AI.Abstractions` 10.3.0, but the repo pins 10.5.0 (required by `Microsoft.Agents.AI` 1.3.0, which itself rejects 10.3 with `CS1705`). 10.5 reshaped `HostedMcpServerTool.AuthorizationToken`, so `new AnthropicClient(apiKey).Messages` (which routes through the SDK's bundled `ChatClientHelper`) throws `MissingMethodException` at runtime. The shim sidesteps the helper by calling `AnthropicClient.Messages.GetClaudeMessageAsync` directly and translating between Anthropic's wire types and `Microsoft.Extensions.AI` types itself. When `Anthropic.SDK` 5.11+ ships rebuilt against M.E.AI 10.5+, drop the shim and revert to `new AnthropicClient(apiKey).Messages`. See [`docs/verification-log.md`](../../../docs/verification-log.md) (entry `2026-05-02`) for the full chain of reasoning. The chapter prose describes the intended pattern; this folder ships a concrete adapter so the sample is runnable today.

## Run it

```bash
export ANTHROPIC_API_KEY=sk-ant-...
dotnet run --project samples/ch04-agent-framework/04.2.4-anthropic-agents
```

Override the model with `ANTHROPIC_MODEL` (defaults to `claude-haiku-4-5-20251001`).

## Manuscript reference

- `Manuscript/Chapter-04.md`, section 4.2.4.
- `Manuscript/Appendix-B-Model-Quick-Reference.md` for current Claude model IDs.

## Prerequisites

- .NET 10 SDK and an Anthropic API key.

## Verifying model IDs are still callable

A throwaway harness at [`tests/AnthropicVerification/`](../../../tests/AnthropicVerification/) hits the live API with each model ID listed in Appendix B. The harness has no `Microsoft.Agents.AI` dependency, so it can pin to M.E.AI 10.3.0 and run end-to-end -- use it during the pre-print verification passes to confirm Anthropic has not rotated the cited identifiers.

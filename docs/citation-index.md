# Citation Index

The map between book sections and their runnable companion code in this repository.

When the manuscript condenses a section and points at this repo, the citation should always reference a **tag** (e.g. `v1.0-first-print`) rather than `master`. `master` will drift.

## Chapter 1 -- Foundations

| Section | Title | Sample path |
|---|---|---|
| 1.3.2 -- 1.3.3 | Hello, IChatClient (provider-selectable) | [`samples/ch01-foundations/01.3-hello-chat/`](../samples/ch01-foundations/01.3-hello-chat/) |
| 1.3.4 | Hello, IEmbeddingGenerator | [`samples/ch01-foundations/01.3-embeddings/`](../samples/ch01-foundations/01.3-embeddings/) |
| 1.4.4 | Secrets and configuration | [`samples/ch01-foundations/01.4-secrets-and-config/`](../samples/ch01-foundations/01.4-secrets-and-config/) |

## Chapter 2 -- Extensions.AI Techniques

| Section | Title | Sample path |
|---|---|---|
| 2.1.5 | Console chat loop with sliding-window history | [`samples/ch02-extensions-ai/02.1-console-chat-loop/`](../samples/ch02-extensions-ai/02.1-console-chat-loop/) |
| 2.2.2 | Streaming over SSE in a Minimal API | [`samples/ch02-extensions-ai/02.2-streaming-aspnet/`](../samples/ch02-extensions-ai/02.2-streaming-aspnet/) |
| 2.2.3 -- 2.2.4 | Structured output to a typed record | [`samples/ch02-extensions-ai/02.2-structured-output/`](../samples/ch02-extensions-ai/02.2-structured-output/) |
| 2.3.6 | Function calling -- weather + calendar + reminders | [`samples/ch02-extensions-ai/02.3-function-calling/`](../samples/ch02-extensions-ai/02.3-function-calling/) |
| 2.4.6 | Composing the middleware pipeline (logging + cache) | [`samples/ch02-extensions-ai/02.4-middleware-pipeline/`](../samples/ch02-extensions-ai/02.4-middleware-pipeline/) |
| 2.4.5 | Custom middleware -- token-budget enforcement | [`samples/ch02-extensions-ai/02.4-custom-middleware/`](../samples/ch02-extensions-ai/02.4-custom-middleware/) |

## Chapter 3 -- RAG and Vision

| Section | Title | Sample path |
|---|---|---|
| 3.1.1 -- 3.1.5 | Semantic search over a product catalog | [`samples/ch03-rag/03.1-semantic-search/`](../samples/ch03-rag/03.1-semantic-search/) |
| 3.2.1 -- 3.2.6 | Basic RAG (retrieve / augment / generate) | [`samples/ch03-rag/03.2-rag-basic/`](../samples/ch03-rag/03.2-rag-basic/) |
| 3.2.2 | Document ingestion pipeline | [`samples/ch03-rag/03.2-ingestion-pipeline/`](../samples/ch03-rag/03.2-ingestion-pipeline/) |
| 3.2.7 | LLM-as-judge RAG evaluation | [`samples/ch03-rag/03.2.7-evaluation/`](../samples/ch03-rag/03.2.7-evaluation/) |
| 3.3.4 | Vision -- receipt image to typed record | [`samples/ch03-rag/03.3-vision-extract/`](../samples/ch03-rag/03.3-vision-extract/) |
| 3.5.1 | Local-first RAG (Ollama, no cloud) | [`samples/ch03-rag/03.5-local-rag/`](../samples/ch03-rag/03.5-local-rag/) |

## Chapter 4 -- Microsoft Agent Framework

| Section | Title | Sample path |
|---|---|---|
| 4.2.1 | Hello, ChatClientAgent | [`samples/ch04-agent-framework/04.2.1-hello-agent/`](../samples/ch04-agent-framework/04.2.1-hello-agent/) |
| 4.2.4 | Anthropic / Claude as an agent | [`samples/ch04-agent-framework/04.2.4-anthropic-agents/`](../samples/ch04-agent-framework/04.2.4-anthropic-agents/) |
| 4.3.3 | Persistent agent sessions (serialize / resume) | [`samples/ch04-agent-framework/04.3-persistent-session/`](../samples/ch04-agent-framework/04.3-persistent-session/) |
| 4.4.2 -- 4.4.3 | Tools + approval gate | [`samples/ch04-agent-framework/04.4-tools-and-approval/`](../samples/ch04-agent-framework/04.4-tools-and-approval/) |
| 4.5.1 -- 4.5.4 | Custom agent run middleware | [`samples/ch04-agent-framework/04.5-agent-middleware/`](../samples/ch04-agent-framework/04.5-agent-middleware/) |
| 4.6.3 | Text-processing workflow | [`samples/ch04-agent-framework/04.6.3-text-processing-walkthrough/`](../samples/ch04-agent-framework/04.6.3-text-processing-walkthrough/) |
| 4.6.6 | Checkpointing and human approval (added after the first print, so not at the `v1.0-first-print` tag) | [`samples/ch04-agent-framework/04.6.6-checkpointing-approval/`](../samples/ch04-agent-framework/04.6.6-checkpointing-approval/) |
| 4.6.7 | Multi-agent content workflow | [`samples/ch04-agent-framework/04.6.7-content-workflow/`](../samples/ch04-agent-framework/04.6.7-content-workflow/) |
| 4.7.3 | Expose an agent over A2A | [`samples/ch04-agent-framework/04.7-a2a-server/`](../samples/ch04-agent-framework/04.7-a2a-server/) |
| 4.8.3 | Agent with mixed local + MCP tools | [`samples/ch04-agent-framework/04.8-agent-with-mcp/`](../samples/ch04-agent-framework/04.8-agent-with-mcp/) |

## Chapter 5 -- Model Context Protocol

| Section | Title | Sample path |
|---|---|---|
| 5.2.10 | Inventory MCP server (full walkthrough) | [`samples/ch05-mcp/05.2.10-inventory-server/`](../samples/ch05-mcp/05.2.10-inventory-server/) |
| 5.3.1 | Stdio transport | [`samples/ch05-mcp/05.3.1-stdio-transport/`](../samples/ch05-mcp/05.3.1-stdio-transport/) |
| 5.3.2 | SSE transport | [`samples/ch05-mcp/05.3.2-sse-transport/`](../samples/ch05-mcp/05.3.2-sse-transport/) |
| 5.3.3 | Streamable HTTP transport | [`samples/ch05-mcp/05.3.3-streamable-http/`](../samples/ch05-mcp/05.3.3-streamable-http/) |
| 5.4.1 -- 5.4.3 | Interactive MCP client REPL | [`samples/ch05-mcp/05.4-mcp-client/`](../samples/ch05-mcp/05.4-mcp-client/) |
| 5.4.2 | `CachedMcpToolProvider` (Critical-1 fix) | [`samples/ch05-mcp/cached-mcp-tool-provider/`](../samples/ch05-mcp/cached-mcp-tool-provider/) |
| 5.6.3 | `McpAgentFactory` | [`samples/ch05-mcp/05.6.3-mcp-agent-factory/`](../samples/ch05-mcp/05.6.3-mcp-agent-factory/) |

## Chapter 6 -- Production Readiness

| Section | Title | Sample path |
|---|---|---|
| 6.1.2 -- 6.1.4 | OpenTelemetry tracing | [`samples/ch06-production/06.1-observability/`](../samples/ch06-production/06.1-observability/) |
| 6.2.1 | Standard resilience handler | [`samples/ch06-production/06.2.1-resilience/`](../samples/ch06-production/06.2.1-resilience/) |
| 6.2.4 | Cost-aware model routing | [`samples/ch06-production/06.2.4-model-routing/`](../samples/ch06-production/06.2.4-model-routing/) |
| 6.3.2 | `OutputGuardChatClient` (Critical-3 fix) | [`samples/ch06-production/output-guard-chat-client/`](../samples/ch06-production/output-guard-chat-client/) |
| 6.5.1 | xUnit tests with stub `IChatClient` | [`samples/ch06-production/06.5.1-unit-testing/`](../samples/ch06-production/06.5.1-unit-testing/) |
| 6.5.3 | LLM-as-judge evaluation harness | [`samples/ch06-production/06.5.3-llm-as-judge/`](../samples/ch06-production/06.5.3-llm-as-judge/) |

## Citation format for the manuscript

When a manuscript section is condensed in favor of pointing here, use this exact wording (substitute the tag and path):

> *Full implementation: <https://github.com/CodeShayk/generative-ai-dotnet-samples/tree/v1.0-first-print/samples/ch04-agent-framework/04.6.3-text-processing-walkthrough>*

## Pending (scaffolded but not populated)

- `samples/appendix-a-packages/` -- one-call quick-start bundles per scenario from Appendix A.10.

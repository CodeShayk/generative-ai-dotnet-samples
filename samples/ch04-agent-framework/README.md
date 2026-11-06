# Chapter 4 -- Agents Using the Microsoft Agent Framework

Companion samples for **Chapter 4** of *Generative AI in .NET*.

| Sample | Section | What it shows |
|---|---|---|
| [`04.2.1-hello-agent/`](04.2.1-hello-agent/) | 4.2.1 | Smallest possible `ChatClientAgent` over Ollama. |
| [`04.2.4-anthropic-agents/`](04.2.4-anthropic-agents/) | 4.2.4 | Same agent API, Claude under the hood. |
| [`04.3-persistent-session/`](04.3-persistent-session/) | 4.3.3 | `AgentSession` serialize/deserialize round trip. |
| [`04.4-tools-and-approval/`](04.4-tools-and-approval/) | 4.4.2 -- 4.4.3 | Function tools + a `[RequiresApproval]` marker for protected tools. |
| [`04.5-agent-middleware/`](04.5-agent-middleware/) | 4.5.1 -- 4.5.4 | A custom run-middleware that times each agent invocation. |
| [`04.6.3-text-processing-walkthrough/`](04.6.3-text-processing-walkthrough/) | 4.6.3 | Linear `Microsoft.Agents.AI.Workflows` pipeline. |
| [`04.6.6-checkpointing-approval/`](04.6.6-checkpointing-approval/) | 4.6.6 | Pause a workflow for human approval, checkpoint to disk, resume. Added after the first print. |
| [`04.6.7-content-workflow/`](04.6.7-content-workflow/) | 4.6.7 | Researcher -> Writer -> Editor multi-agent workflow. |
| [`04.7-a2a-server/`](04.7-a2a-server/) | 4.7.3 | `MapA2A` exposing a local agent over the A2A protocol (preview package). |
| [`04.8-agent-with-mcp/`](04.8-agent-with-mcp/) | 4.8.3 | Agent with mixed local + MCP-sourced tools. |

Every sample uses the central `Directory.Packages.props` for version pinning.

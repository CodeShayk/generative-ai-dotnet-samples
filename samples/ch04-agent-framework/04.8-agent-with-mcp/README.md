# Chapter 4.8 -- Agent with Function Tools + MCP Tools

Companion code for **Generative AI in .NET**, Chapter 4 section 4.8.3 ("An Agent with Both Function Tools and MCP Tools").

Boots an MCP client over stdio against any MCP server you specify on the command line, exposes the discovered tools to a `ChatClientAgent` *alongside* one local C# helper, and runs an interactive REPL. The agent doesn't know which tools are local and which crossed a process boundary.

## Run it

```bash
export OPENAI_API_KEY=sk-...
dotnet run --project samples/ch04-agent-framework/04.8-agent-with-mcp -- dnx Microsoft.Azure.Mcp --yes
```

Or point it at any other stdio MCP server.

## Manuscript reference

- `Manuscript/Chapter-04.md`, section 4.8.3.
- Figure 4.10 ("Agent with Mixed Tool Sources").

## Prerequisites

- .NET 10 SDK, an OpenAI API key, and an MCP server you can spawn over stdio.

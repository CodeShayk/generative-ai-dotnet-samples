# Errata and updates

For the first print of *Generative AI in .NET* and the code at the [`v1.0-first-print`](https://github.com/CodeShayk/generative-ai-dotnet-samples/tree/v1.0-first-print) tag.

**Last updated:** 2026-11-06

This page has two parts:

- [**Corrections**](#corrections) are mistakes in the book or its samples as printed.
- [**Updates since print**](#updates-since-print) cover places where the book was right when printed, but the platform has since moved on.

This page lists what has been confirmed so far. Not every printed snippet has been recompiled, so a snippet missing from this page isn't guaranteed to be correct. If you find a problem, please [open an issue](https://github.com/CodeShayk/generative-ai-dotnet-samples/issues).

## Corrections

The Chapter 4 corrections were compiled against `Microsoft.Agents.AI.Workflows` 1.3.0, the version the book prints, and 1.27.0, the version on `master` today. The replacement code works on both.

### Sections 4.6.2, 4.6.3 and 4.6.6: writing a custom executor

The printed `Executor<TIn, TOut>` subclasses do not compile. The method to override is `HandleAsync`, the context type is `IWorkflowContext`, and the base class needs an executor ID.

The prose in 4.6.2 that says to "override `ExecuteAsync`" should also read `HandleAsync`.

Replace `ProgressiveExecutor` in 4.6.3 with:

```csharp
public sealed class ProgressiveExecutor() : Executor<int, int>("progressive")
{
    public override async ValueTask<int> HandleAsync(
        int input,
        IWorkflowContext context,
        CancellationToken cancellationToken = default)
    {
        for (int i = 1; i <= input; i++)
        {
            await context.YieldOutputAsync(i, cancellationToken);
            await Task.Delay(100, cancellationToken);
        }
        return input;
    }
}
```

The returned value is also emitted as an output, so an input of `3` produces `1`, `2`, `3`, `3`.

`UppercaseExecutor` in 4.6.2 and `ApprovalExecutor` in 4.6.6 need the same changes. `ApprovalExecutor` also has the problems described under [Section 4.6.6](#section-466-checkpointing-and-human-approval).

### Section 4.6.3: streaming a workflow

`Workflow` has no `RunStreamingAsync` method, and `ExecutorCompletedEvent` has no `ExecutorName` property. Replace the printed "Streaming output" snippet with:

```csharp
await using var run = await InProcessExecution.RunStreamingAsync(workflow, "Hello");
await foreach (WorkflowEvent evt in run.WatchStreamAsync())
{
    if (evt is WorkflowOutputEvent output)
        Console.WriteLine($"Output: {output.Data}");
    else if (evt is ExecutorCompletedEvent completed)
        Console.WriteLine($"Executor {completed.ExecutorId} done.");
}
```

The sentence before it should say that you stream these events from `InProcessExecution.RunStreamingAsync`, not from `RunAsync`.

### Sections 4.6.2, 4.6.5 and 4.7.4: using an agent as an executor

`AIAgent` has no `.AsExecutor()` method, and `WorkflowBuilder` has no `AddExecutor` method. An `AIAgent` converts implicitly to an `ExecutorBinding`, so you can pass it directly to the workflow builder:

```csharp
ExecutorBinding writer = writerAgent;
Workflow workflow = new WorkflowBuilder(writer).WithOutputFrom(writer).Build();
```

To run several agents in sequence, you can also use `AgentWorkflowBuilder.BuildSequential`.

### Section 4.6.6: checkpointing and human approval

The concepts in this section are sound, but the code in it, including the worked approval example, does not compile, because the APIs in the left column of this table do not exist. The right column shows what to use instead.

| As printed | Use instead |
|---|---|
| `builder.WithCheckpointing(store)`, `IWorkflowCheckpointStore` | `CheckpointManager.CreateInMemory()`, or `CheckpointManager.CreateJson(...)` with your own store |
| `workflow.StartAsync(input)` | `InProcessExecution.RunAsync(workflow, input, checkpointManager)` |
| `workflow.ResumeAsync(runId)` | `InProcessExecution.ResumeAsync(workflow, checkpointInfo, checkpointManager)` |
| `context.WaitForExternalSignalAsync<T>(...)` | A `RequestPort` created with `RequestPort.Create<TRequest, TResponse>("id")` |
| `workflow.SignalAsync(...)`, `workflow.ResumeWithAsync(...)` | Handle `RequestInfoEvent`, then reply with `ExternalRequest.CreateResponse(...)` and `StreamingRun.SendResponseAsync(...)` |
| `context.EmitEventAsync(new WorkflowEvent(name, data))` (also in 4.6.2) | `context.AddEventAsync(...)` with your own `WorkflowEvent` subclass |
| `ICheckpointable`, `Checkpoint()`, `Restore()` | Override `OnCheckpointingAsync` and `OnCheckpointRestoredAsync` on the executor |

The replacement APIs compile on both versions, but no complete, tested checkpointing example has been published yet. Treat this table as a guide rather than a drop-in fix.

### Section 5.1.3: SDK stability

"Until the SDK reaches 1.0, expect occasional breaking changes between minor versions" was out of date at print, because the book itself uses `ModelContextProtocol` 1.2. The advice that still applies is to pin your versions and read the release notes before upgrading.

### Section 5.5.3: the `dnx` command

The book says `dnx` is part of the .NET 9 SDK as `dotnet x`. That is wrong in two ways:

- `dnx` ships with the [.NET 10 SDK](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/sdk), and `dotnet dnx` is not found on a .NET 9 SDK.
- There is no `dotnet x` command. The long form is `dotnet dnx`, or `dotnet tool exec`.

**This affects** every `dnx` example in Chapter 5, including 5.4.1, 5.6.3 and 5.7.2.

**To run them,** install a .NET 10 SDK alongside .NET 9. Inside a `v1.0-first-print` checkout, `global.json` selects the .NET 9 SDK, so `dnx` can still fail with "command or file was not found". If it does, launch the server from a folder outside the checkout, or use `master`.

### Sample `04.6.3-text-processing-walkthrough` crashes at the print tag

This is a bug in the sample, not in the printed walkthrough. At `v1.0-first-print` it prints its first result, then stops with:

```text
System.InvalidOperationException: Cannot use a Workflow that is already owned by another runner or parent workflow.
```

A workflow can belong to only one run at a time, and the sample starts its streaming run while the first run is still open. It is fixed on `master`. To fix your own copy, close the first run before starting the second:

```csharp
await using (var run = await InProcessExecution.RunAsync(workflow, "Hello, agent!"))
{
    foreach (var evt in run.NewEvents)
    {
        if (evt is WorkflowOutputEvent output)
            Console.WriteLine($"Result: {output.Data}");
    }
}
```

### Sample `05.6.3-mcp-agent-factory` ignores `OPENAI_API_KEY` at the print tag

If you set `OPENAI_API_KEY` as the sample's README says, it still crashes on startup with:

```text
System.ArgumentException: Value cannot be an empty string. (Parameter 'key')
```

The sample's `appsettings.json` contains `"ApiKey": ""`, and that empty value takes priority over the environment variable. It is fixed on `master`. To fix your own copy, delete that line from `appsettings.json`.

## Updates since print

### `master` now targets .NET 10

The book says every example targets .NET 9, and the Front Matter says `master` tracks .NET 9. `master` now targets .NET 10 LTS, because [.NET 9 support ends on November 10, 2026](https://dotnet.microsoft.com/en-us/platform/support/policy).

| If you want to | Use |
|---|---|
| Follow the code exactly as printed | The `v1.0-first-print` tag and a .NET 9 SDK |
| Build something you will keep or deploy | `master` and a .NET 10 SDK |

The tag is a frozen teaching snapshot. Its packages no longer receive fixes, and one of them, OpenTelemetry 1.10.0, has a known advisory ([GHSA-4625-4j76-fww9](https://github.com/advisories/GHSA-4625-4j76-fww9)). Use `master` for anything beyond learning.

To move a printed project to .NET 10, set `<TargetFramework>net10.0</TargetFramework>`, update any 9.x `Microsoft.Extensions.*` packages to their 10.x versions, and set the `global.json` SDK version to 10 if your project has one.

### Package versions have moved

The "Last validated" line at the start of each chapter, and Appendix A, list the versions used at print. The main ones have changed as follows:

| Package | In the book | On `master` |
|---|---|---|
| `Microsoft.Extensions.AI` | 10.5.2 | 10.11.0 |
| `Microsoft.Agents.AI` | 1.3.x | 1.27.0 |
| `ModelContextProtocol` | 1.2.x | 2.3.1 |

[`version-matrix.md`](version-matrix.md) has the full, current list.

### MCP 2.x: new handshake and an intermittent connection failure

Sections 5.1.2 and 5.4.1 describe a client that connects by sending `initialize`. That is still how the book's MCP 1.2 code works. MCP 2.x clients prefer the newer `2026-07-28` protocol revision, which removes `initialize`: they send a `server/discover` request first and use `initialize` only for older servers.

This can cause an intermittent failure if you run the printed `McpClient.CreateAsync(transport)` code on MCP 2.x:

```text
Method 'initialize' is not available on protocol version '2026-07-28'
```

**Why it happens:** by default, the client waits 5 seconds for an answer to `server/discover`, then also sends `initialize` on the same connection. A server that takes longer than that to start, as it might under `dotnet run` or `dnx`, receives both requests and can reject the second. The code at the `v1.0-first-print` tag uses MCP 1.2 and is not affected.

**The fix,** which the samples on `master` now use, is to wait for the answer:

```csharp
await using var client = await McpClient.CreateAsync(
    transport,
    new McpClientOptions { DiscoverProbeTimeout = Timeout.InfiniteTimeSpan });
```

Older servers that report `server/discover` as an unknown method still connect normally. The one trade-off is a server that ignores the request and never answers: it now fails when `InitializationTimeout` expires (60 seconds by default), instead of falling back to `initialize` after 5 seconds.

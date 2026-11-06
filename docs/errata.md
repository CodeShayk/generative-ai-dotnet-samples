# Errata and updates

For the first print of *Generative AI in .NET* and the code at the [`v1.0-first-print`](https://github.com/CodeShayk/generative-ai-dotnet-samples/tree/v1.0-first-print) tag.

**Last updated:** 2026-11-06

This page has two parts:

- [**Corrections**](#corrections) are mistakes in the book or its samples as printed.
- [**Updates since print**](#updates-since-print) cover places where the book was right when printed, but the platform has since moved on.

If you find a problem that isn't listed here, please [open an issue](https://github.com/CodeShayk/generative-ai-dotnet-samples/issues).

## Corrections

### How the printed code was checked

All 314 printed C# blocks were compiled against the versions pinned at `v1.0-first-print`. For packages the book doesn't pin, such as the Azure SDKs, the check used the book's stated major version or the newest stable release. The result:

| Printed C# blocks | Count |
|---|---|
| Compile as printed | 149 |
| Have at least one of the errors listed on this page | 91 |
| Depend on types or placeholders you supply, so compile only partly | 74 |

Keep in mind that:

- The 74 blocks in the last row showed no confirmed API errors, but calls made on types you supply, such as `InventoryDbContext`, can't be checked.
- This shows whether code compiles, not whether it behaves correctly. Unless a correction says it was run, its replacement has only been compiled.
- Every replacement on this page compiles against both the print versions and the versions on `master` today.

Most of these errors are API names that the packages don't have. Where a table below gives a replacement, the rest of the printed example can stay as it is.

### Chapters 1 and 2

| Section | As printed | Use instead |
|---|---|---|
| Chapter 1 "Requesting Structured (JSON) Responses", 2.2.3, 2.2.4, 2.2.5 | `T? result = await chatClient.GetResponseAsync<T>(...)` | The call returns `ChatResponse<T>`: `ChatResponse<T> response = await chatClient.GetResponseAsync<T>(...);`, then read `response.Result` |
| 2.3.3 | `tool.InvokeAsync(toolCall.Arguments, ...)` | `tool.InvokeAsync(new AIFunctionArguments(toolCall.Arguments), ...)` |
| 2.3.6 | `List<AIFunction> tools`, assigned to `ChatOptions.Tools` | Declare it as `List<AITool> tools` |
| 2.3.6 | `days > 1 ? ["Partly cloudy", ...][..n] : ["Partly cloudy"]` | Collection expressions have no type here. Use `new[] { "Partly cloudy", ... }[..n]` and `new[] { "Partly cloudy" }` |
| 2.4.5 | Overriding `GetResponseAsync(IList<ChatMessage> ...)` | The parameter is `IEnumerable<ChatMessage>`, so `messages.Count` also becomes `messages.Count()` |
| 2.4.5 | `int _tokensUsedInWindow`, added to from `usage.TotalTokenCount` | `TotalTokenCount` is a `long?`, so make the counter a `long` |

### Chapter 3

| Section | As printed | Use instead |
|---|---|---|
| 3.1.2 | `.AsIEmbeddingGenerator(dimensions: 512)` | `.AsIEmbeddingGenerator(defaultModelDimensions: 512)` |
| 3.1.3, 3.1.8 | `[VectorStoreVector(Dimensions: 1536, DistanceFunction = ...)]` | `[VectorStoreVector(1536, DistanceFunction = DistanceFunction.CosineSimilarity)]` |
| 3.2.3 | `newRecords.Partition(...)` | .NET has no `Partition` method, and the book doesn't define one. Use `newRecords.Where(r => !existingHashes.Contains(r.ContentHash)).ToList()` |
| 3.3.3 | `field.Value.AsString()`, `.AsDate()`, `.AsCurrency().Amount`, `.AsList()`, `.AsDictionary()` | `field.ValueString`, `.ValueDate`, `.ValueCurrency?.Amount`, `.ValueList`, `.ValueDictionary`. The amount is a `double?` and the date is a `DateTimeOffset?`, not `decimal` and `DateTimeOffset` |
| 3.4.3 | `GetResponseAsync<T>(messages, options, ct)` | `GetResponseAsync<T>(messages, options, cancellationToken: ct)` |
| 3.5.1, 3.5.5 | `var v = await embeddings.GenerateAsync("text"); v[0].Vector` | With a single string, the call returns one embedding: `v.Vector` |

### Sections 4.2 to 4.5 and 4.8: agents, tools and middleware

| Section | As printed | Use instead |
|---|---|---|
| 4.2.2, 4.4.4, 4.4.5 | `client.GetAIAgent(id)` on a `PersistentAgentsClient` | `await client.GetAIAgentAsync(id)`. This comes from the preview package `Microsoft.Agents.AI.AzureAI.Persistent`, which the printed package list leaves out |
| 4.2.2 | `new AIProjectClient(endpoint: ..., credential: ...)` | Pass both arguments by position: `new AIProjectClient(new Uri(...), new DefaultAzureCredential())` |
| 4.2.3, 4.4.4 | `OpenAIResponseClient`, `client.GetOpenAIResponseClient("gpt-4o")` | `ResponsesClient responses = client.GetResponsesClient();`. Pass the model name to `AsAIAgent(model: ...)`. Add `#pragma warning disable OPENAI001`, because OpenAI marks this API as evaluation-only |
| 4.4.4 | `ResponseTool.CreateCodeInterpreterTool()` | `ResponseTool.CreateCodeInterpreterTool(new CodeInterpreterToolContainer(CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration()))` |
| 4.2.6 | Custom agents overriding `Id`, returning `Task<AgentSession>`, and calling `new AgentSession()` | See [Section 4.2.6](#section-426-custom-agents) |
| 4.4.2 | `new ChatClientAgentRunOptions { AdditionalTools = [...] }` | `new ChatClientAgentRunOptions(new ChatOptions { Tools = [...] })` |
| 4.4.3, 6.5.5 | `UserInputRequests`, `FunctionApprovalRequest`, `FunctionApprovalRequestContent`, `ApprovalResponses`, `FunctionApprovalRequiredException` | See [Section 4.4.3](#section-443-tool-approval) |
| 4.4.5 | `PersistentFile`, `client.Files.UploadAsync`, `PersistentFilePurpose` | `PersistentAgentFileInfo`, `client.Files.UploadFileAsync`, `PersistentAgentFilePurpose` |
| 4.4.5 | `PersistentVectorStore`, `client.VectorStores.CreateAsync` | `PersistentAgentsVectorStore`, `client.VectorStores.CreateVectorStoreAsync` |
| 4.4.5 | `new FileSearchToolResource(vectorStoreIds: [store.Id])` | Create it with `new FileSearchToolResource()`, then call `resource.VectorStoreIds.Add(store.Id)` |
| 4.4.5 | `new BingGroundingToolDefinition(connectionId: id)` | `new BingGroundingToolDefinition(new BingGroundingSearchToolParameters([new BingGroundingSearchConfiguration(id)]))` |
| 4.4.7 | `CreateAgentAsync(toolboxes: [new ToolboxReference(...)])` | That parameter doesn't exist. Use `project.AsAIAgent(model: ..., instructions: ..., tools: [new HostedMcpToolboxAITool("FrontierResearchTools")])` on an `AIProjectClient` |
| 4.5.2, 4.5.4, 4.5.5 | `.Use(SecurityMiddleware.Apply)`, with `IReadOnlyCollection<ChatMessage>` and `AgentSession` parameters | Take `IEnumerable<ChatMessage>` and `AgentSession?`, then call `.Use(SecurityMiddleware.Apply, runStreamingFunc: null)`. The `AgentRunMiddleware` delegate in 4.5.2 changes the same way |
| 4.5.3 | `.UseFunctionInvocation(callback)` on an agent builder | `.Use(callback)`, where the callback takes `(AIAgent, FunctionInvocationContext, next, CancellationToken)` and returns `ValueTask<object?>` |
| 4.5.4 | `ChatClientAgentOptions.ClientFactory` | Build the client pipeline first with `chat.AsBuilder()...Build()`, then pass the result to `ChatClientAgent`. To change it for one run, use `ChatClientAgentRunOptions.ChatClientFactory` |
| 4.8.1 | `new HostedMcpToolDefinition(serverLabel, serverUrl, connectionName)` | `new MCPToolDefinition(serverLabel, serverUrl)` |
| 4.8.2 | `new HttpClientTransportOptions { Uri = ... }` | `new HttpClientTransportOptions { Endpoint = ... }` |

### Section 4.2.6: custom agents

Neither printed agent compiles. `Id` can't be overridden, sessions are created through `ValueTask`, `AgentSession` is abstract, and two serialization methods are required. This version of `EchoAgent` compiles on both package versions. `FaqAgent` needs the same changes:

```csharp
public sealed class EchoAgent : AIAgent
{
    private sealed class EchoSession : AgentSession { }

    protected override string? IdCore => "echo";
    public override string? Name => "Echo";
    public override string? Description => "Echoes the user's input back.";

    protected override ValueTask<AgentSession> CreateSessionCoreAsync(
        CancellationToken cancellationToken = default)
        => new(new EchoSession());

    protected override ValueTask<JsonElement> SerializeSessionCoreAsync(
        AgentSession session,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default)
        => new(JsonSerializer.SerializeToElement(new { }));

    protected override ValueTask<AgentSession> DeserializeSessionCoreAsync(
        JsonElement serializedState,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default)
        => new(new EchoSession());

    protected override Task<AgentResponse> RunCoreAsync(
        IEnumerable<ChatMessage> messages,
        AgentSession? session = null,
        AgentRunOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var lastUser = messages.LastOrDefault(m => m.Role == ChatRole.User)?.Text ?? "";
        return Task.FromResult(new AgentResponse(new ChatMessage(ChatRole.Assistant, lastUser)));
    }

    protected override async IAsyncEnumerable<AgentResponseUpdate> RunCoreStreamingAsync(
        IEnumerable<ChatMessage> messages,
        AgentSession? session = null,
        AgentRunOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (var ch in messages.LastOrDefault(m => m.Role == ChatRole.User)?.Text ?? "")
        {
            yield return new AgentResponseUpdate(ChatRole.Assistant, ch.ToString());
            await Task.Yield();
        }
    }
}
```

### Section 4.4.3: tool approval

The approval pattern in this section is right, but its types don't exist. Wrap the tool in `ApprovalRequiredAIFunction`, then read the request from the response:

```csharp
AIFunction guarded = new ApprovalRequiredAIFunction(deleteCustomer);

AgentResponse response = await agent.RunAsync("Delete customer 42.", session);

var approval = response.Messages
    .SelectMany(m => m.Contents)
    .OfType<ToolApprovalRequestContent>()
    .FirstOrDefault();

if (approval?.ToolCall is FunctionCallContent call)
{
    Console.WriteLine($"Agent wants to call: {call.Name}");
    bool decision = Console.ReadLine()?.Trim() == "y";

    AgentResponse continued = await agent.RunAsync(
        new ChatMessage(ChatRole.User, [approval.CreateResponse(decision)]),
        session);
    Console.WriteLine(continued);
}
```

This pattern was run against a stub chat client on both package versions. The tool did not run before the decision, ran once when approved, and did not run when rejected.

`ConditionalApprovalFunction` can't be written as printed, because there is no exception that requests approval from inside a tool. `ApprovalRequiredAIFunction` always asks, so put your condition where you handle the request, and approve the calls that don't need review.

The test in 6.5.5 changes the same way: look for `ToolApprovalRequestContent`, and cast its `ToolCall` to `FunctionCallContent` to read the name.

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

### Sections 4.6.2, 4.6.4, 4.6.5 and 4.6.7: edges and joins

| Section | As printed | Use instead |
|---|---|---|
| 4.6.4, 4.6.5, 4.6.7 | `builder.AddEdge(a, b, doc => doc.Confidence > 0.7)` | The compiler can't infer the message type, so state it: `builder.AddEdge<ClassifiedDoc>(a, b, condition: doc => doc?.Confidence > 0.7)`. The parameter can be null |
| 4.6.2 | `builder.AddEdge(a, b, msgType: typeof(T))` | There is no `msgType` parameter. Use `AddEdge<T>` with a condition |
| 4.6.4 | `builder.AddExecutor<TIn, TOut>(...)`, `AddEdge(..., mapper: ...)` | Neither exists. Convert the message in an executor placed on the edge |
| 4.6.4, 4.6.7 | `builder.AddJoinExecutor<...>(...)`, `aggregator.Input1` | Use `builder.AddFanInBarrierEdge([a, b], join)`. **This is not a drop-in change:** `join` waits for all sources, but its handler then runs once per message, not once with all of them. Collect the messages yourself |

The fan-in behaviour was confirmed by running it on both package versions.

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

For a complete example, see the new sample [`04.6.6-checkpointing-approval`](../samples/ch04-agent-framework/04.6.6-checkpointing-approval/). It pauses an expense workflow for approval, saves a checkpoint to disk, resumes from that checkpoint, and finishes with state written before the pause. It needs no model or API key. A two-process version of the same code, with the pause and the resume in separate runs, also passed on Workflows 1.3.0 and 1.27.0.

### Section 4.7: A2A agents

Most of the client API printed in 4.7.2 and 4.7.4 doesn't exist. The concepts still apply. [`04.7-a2a-server`](../samples/ch04-agent-framework/04.7-a2a-server/) has a working server.

| Section | As printed | Use instead |
|---|---|---|
| 4.7.2, 4.7.4 | `A2AAgent.ConnectAsync(endpoint, new A2AAgentOptions { ... })` | `AIAgent remote = new A2AClient(endpoint, httpClient).AsAIAgent(name: "ResearchSpecialist");` |
| 4.7.2 | `AuthInterceptor` | Set up authentication on the `HttpClient` you pass in, using its default headers or a `DelegatingHandler` |
| 4.7.2 | `A2AAgent.FetchCardAsync(uri)`, `A2AAgentCard` | `AgentCard card = await new A2ACardResolver(uri).GetAgentCardAsync();`. You can then call `card.AsAIAgent()` |
| 4.7.2 | `card.Capabilities.LongRunningTasks` | There is no such property. `AgentCapabilities` has `Streaming` and `PushNotifications` |
| 4.7.2 | `remote.StartTaskAsync(...)`, `A2ATask`, `task.RefreshAsync()`, `remote.StreamTaskAsync(id)` | `A2AClient.SendMessageAsync`, `GetTaskAsync` and `SubscribeToTaskAsync`, which take request objects, or `RunAsync` and `RunStreamingAsync` on the agent |
| 4.7.3 | `app.MapA2A(pattern: ..., agentName: ..., cardOptions: new A2AAgentCardOptions { ... })` | Register a handler with `AddA2AAgent<THandler>(card)`, then call `app.MapA2A("/a2a")` and `app.MapWellKnownAgentCard(card, "/a2a")`, as in the sample |

### Chapter 5

| Section | As printed | Use instead |
|---|---|---|
| 5.2.4 | `new TextContent(csv) { MimeType = "text/csv" }` in a `CallToolResult` | Tool results use content blocks: `new TextContentBlock { Text = csv }`. To carry a MIME type, use `new EmbeddedResourceBlock { Resource = new TextResourceContents { Uri = "...", MimeType = "text/csv", Text = csv } }` |
| 5.2.6, 5.2.10 | `[McpServerResource(Uri = "...")]` | `[McpServerResource(UriTemplate = "...")]` |
| 5.2.8, 5.2.10 | `new PromptMessage(role, content)` | `new PromptMessage { Role = Role.User, Content = new TextContentBlock { Text = "..." } }` |
| 5.3.3, 5.4.1, 5.8.4 | `HeadersProvider = async ct => ...` | There is no per-request callback. Use `AdditionalHeaders` for fixed values. For tokens that change, pass your own `HttpClient` with a `DelegatingHandler` to `new HttpClientTransport(options, httpClient)` |
| 5.4.3 | `client.CallToolAsync(name: "...", ...)` | `client.CallToolAsync(toolName: "...", ...)` |
| 5.4.3 | `content is TextContent`, `content is ImageContent`, `image.Data` | `content is TextContentBlock`, `content is ImageContentBlock`, `image.DecodedData.ToArray()` |
| 5.4.3 | `first?.MimeType == "application/json"` on text content | `TextContentBlock` has no `MimeType`. Check the tool's documented format, or use `result.StructuredContent` |
| 5.4.5 | `client.CallToolAsync(name, args, ct)` | The third parameter is a progress callback: `client.CallToolAsync(name, args, cancellationToken: ct)`. `args` must be an `IReadOnlyDictionary<string, object?>` |
| 5.4.5 | `catch (McpException ex) when (ex.ErrorCode == -32601)` | `catch (McpProtocolException ex) when (ex.ErrorCode == McpErrorCode.MethodNotFound)` |
| 5.8.2 | `new HttpClientTransportOptions { HttpClient = httpClient, ... }` | `new HttpClientTransport(options, httpClient)` |

### Chapter 6 and Appendix D

| Section | As printed | Use instead |
|---|---|---|
| 6.1.2, 6.2.2, D.9 | `embedder.GenerateEmbeddingAsync(text)` | `embedder.GenerateAsync(text)`, which returns one `Embedding<float>` |
| 6.1.2, 6.2.2, 6.2.3 | `IVectorStoreRecordCollection<TKey, TRecord>` | `VectorStoreCollection<TKey, TRecord>` |
| 6.2.2 | `[VectorStoreRecordKey]`, `[VectorStoreRecordData]`, `[VectorStoreRecordVector(Dimensions: 1536, ...)]` | `[VectorStoreKey]`, `[VectorStoreData]`, `[VectorStoreVector(1536, DistanceFunction = DistanceFunction.CosineSimilarity)]` |
| 6.2.1 | `new OpenAIClient(apiKeyString, options)` | `new OpenAIClient(new ApiKeyCredential(apiKeyString), options)` |
| 6.3.2 | `ContentSafetyClient.ShieldPromptAsync`, `ShieldPromptOptions` | The stable `Azure.AI.ContentSafety` package has no Prompt Shields method. Call the [Shield Prompt REST API](https://learn.microsoft.com/en-us/rest/api/contentsafety/text-operations/shield-prompt?view=rest-contentsafety-2024-09-01) instead |
| 6.5.1 | `new ChatResponseUpdate { Role = ..., Text = ... }` | `new ChatResponseUpdate(ChatRole.Assistant, text)` |
| 6.5.1 | `new InMemoryVectorStoreCollection<DocChunk>(records)` | `new InMemoryCollection<string, DocChunk>("docs")` from `Microsoft.SemanticKernel.Connectors.InMemory`. Then call `EnsureCollectionExistsAsync` and `UpsertAsync` |
| 6.5.2 | `new OllamaApiClient(...).AsIChatClient()` | Remove `.AsIChatClient()`: `OllamaApiClient` already implements `IChatClient` |
| 6.5.4 | `result.TestName`, `result.Score` on `EvaluationResult` | Neither exists. Read a score with `result.Get<NumericMetric>(metricName).Value`, and keep the test name yourself |
| D.4 | `string? finishReason = response.FinishReason` | `ChatFinishReason? finishReason = response.FinishReason` |

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

This is SDK issue [#1954](https://github.com/modelcontextprotocol/csharp-sdk/issues/1954). The [server-side fix](https://github.com/modelcontextprotocol/csharp-sdk/pull/1956) has merged, but it isn't in 2.3.1, the newest release on 2026-11-06, so you still need the client change below.

**The fix,** which the samples on `master` now use, is to wait for the answer:

```csharp
await using var client = await McpClient.CreateAsync(
    transport,
    new McpClientOptions { DiscoverProbeTimeout = Timeout.InfiniteTimeSpan });
```

Older servers that report `server/discover` as an unknown method still connect normally. The one trade-off is a server that ignores the request and never answers: it now fails when `InitializationTimeout` expires (60 seconds by default), instead of falling back to `initialize` after 5 seconds.

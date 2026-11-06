using Microsoft.Agents.AI.Workflows;

var upper = new FunctionExecutor<string, string>(
    "uppercase",
    (s, ctx, ct) => ValueTask.FromResult(s.ToUpperInvariant()));

var reverse = new FunctionExecutor<string, string>(
    "reverse",
    (s, ctx, ct) => ValueTask.FromResult(new string(s.Reverse().ToArray())));

Workflow workflow = new WorkflowBuilder(upper)
    .AddEdge(upper, reverse)
    .WithOutputFrom(reverse)
    .Build();

// A Workflow can only be owned by one run at a time, so dispose this run
// before starting the streaming run below.
await using (var run = await InProcessExecution.RunAsync(workflow, "Hello, agent!"))
{
    foreach (var evt in run.NewEvents)
    {
        if (evt is WorkflowOutputEvent output)
        {
            Console.WriteLine($"Result: {output.Data}");
        }
    }
}

Console.WriteLine();
Console.WriteLine("Streaming events:");

await using var stream = await InProcessExecution.RunStreamingAsync(workflow, "Streaming demo");
await foreach (WorkflowEvent evt in stream.WatchStreamAsync())
{
    switch (evt)
    {
        case WorkflowOutputEvent output:
            Console.WriteLine($"  output: {output.Data}");
            break;
        case ExecutorCompletedEvent completed:
            Console.WriteLine($"  executor done: {completed.ExecutorId}");
            break;
    }
}

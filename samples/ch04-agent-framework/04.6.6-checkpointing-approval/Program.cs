using Microsoft.Agents.AI.Workflows;
using Microsoft.Agents.AI.Workflows.Checkpointing;

// A long-running approval: the workflow pauses for a human, and is later resumed from
// the checkpoint on disk. Both parts run here for convenience, but part 2 shares nothing
// with part 1 except those files, so it could just as well be a later process.
// Pass --reject to see the other outcome.
bool approved = !args.Contains("--reject");
var report = new ExpenseReport("E-1042", "Ada", 1850m);
var checkpoints = new DirectoryInfo(Path.Combine(Path.GetTempPath(), $"expense-approval-{Guid.NewGuid():N}"));

try
{
    Console.WriteLine("Part 1: run until approval is needed");
    CheckpointInfo pausedAt;
    using (var store = new FileSystemJsonCheckpointStore(checkpoints))
    {
        await using StreamingRun run = await InProcessExecution.RunStreamingAsync(
            BuildWorkflow(), report, CheckpointManager.CreateJson(store));
        pausedAt = await RunUntilApprovalNeededAsync(run);
    }
    Console.WriteLine($"  paused at checkpoint {pausedAt.CheckpointId}");

    // Only the files on disk and the checkpoint's IDs carry over from here on:
    // the workflow, its executors and the checkpoint store are all created again.
    Console.WriteLine();
    Console.WriteLine($"Part 2: resume and {(approved ? "approve" : "reject")}");
    using (var store = new FileSystemJsonCheckpointStore(checkpoints))
    {
        await using StreamingRun run = await InProcessExecution.ResumeStreamingAsync(
            BuildWorkflow(), pausedAt, CheckpointManager.CreateJson(store));
        await ReplyAndFinishAsync(run, new ApprovalDecision(approved, approved ? "Within policy." : "Over budget."));
    }
}
finally
{
    checkpoints.Refresh();
    if (checkpoints.Exists) checkpoints.Delete(recursive: true);
}

// A Workflow belongs to one run at a time, so each process builds its own.
static Workflow BuildWorkflow()
{
    var validate = new ValidateExpenseExecutor();
    var approval = RequestPort.Create<ExpenseReport, ApprovalDecision>("manager-approval");
    var finish = new FinishExpenseExecutor();

    return new WorkflowBuilder(validate)
        .AddEdge(validate, approval)
        .AddEdge(approval, finish)
        .WithOutputFrom(finish)
        .Build();
}

static async Task<CheckpointInfo> RunUntilApprovalNeededAsync(StreamingRun run)
{
    await foreach (WorkflowEvent evt in run.WatchStreamAsync())
    {
        switch (evt)
        {
            case ExpenseValidatedEvent validated:
                Console.WriteLine($"  {validated.Data}");
                break;
            case RequestInfoEvent request when request.Request.TryGetDataAs<ExpenseReport>(out var pending):
                Console.WriteLine($"  approval requested for {pending!.Id} ({pending.Amount:0.00})");
                break;
            // The step that raised the request has finished and been saved, so it is safe to stop.
            case SuperStepCompletedEvent { CompletionInfo: { HasPendingRequests: true, Checkpoint: { } checkpoint } }:
                return checkpoint;
        }
    }
    throw new InvalidOperationException("The workflow ended without asking for approval.");
}

static async Task ReplyAndFinishAsync(StreamingRun run, ApprovalDecision decision)
{
    await foreach (WorkflowEvent evt in run.WatchStreamAsync())
    {
        switch (evt)
        {
            case RequestInfoEvent request:
                Console.WriteLine($"  replying to request {request.Request.RequestId}");
                await run.SendResponseAsync(request.Request.CreateResponse(decision));
                break;
            case WorkflowOutputEvent output:
                Console.WriteLine($"  {output.Data}");
                return;
        }
    }
    throw new InvalidOperationException("The workflow ended without producing a result.");
}

public sealed record ExpenseReport(string Id, string Employee, decimal Amount);

public sealed record ApprovalDecision(bool Approved, string Comment);

public sealed class ExpenseValidatedEvent(string message) : WorkflowEvent(message);

internal static class ExpenseState
{
    public const string Scope = "expense";
    public const string ReportId = "report-id";
}

public sealed class ValidateExpenseExecutor() : Executor<ExpenseReport, ExpenseReport>("validate")
{
    public override async ValueTask<ExpenseReport> HandleAsync(
        ExpenseReport report,
        IWorkflowContext context,
        CancellationToken cancellationToken = default)
    {
        if (report.Amount <= 0)
            throw new ArgumentException("An expense must be greater than zero.", nameof(report));

        // Workflow state is saved in the checkpoint, unlike a field on this object.
        await context.QueueStateUpdateAsync(ExpenseState.ReportId, report.Id, ExpenseState.Scope, cancellationToken);
        await context.AddEventAsync(new ExpenseValidatedEvent($"validated {report.Id} for {report.Employee}"), cancellationToken);
        return report;
    }
}

public sealed class FinishExpenseExecutor() : Executor<ApprovalDecision, string>("finish")
{
    public override async ValueTask<string> HandleAsync(
        ApprovalDecision decision,
        IWorkflowContext context,
        CancellationToken cancellationToken = default)
    {
        // This value was written in part 1 and read back from the checkpoint.
        string? reportId = await context.ReadStateAsync<string>(ExpenseState.ReportId, ExpenseState.Scope, cancellationToken);
        string outcome = decision.Approved ? "APPROVED" : "REJECTED";
        return $"{reportId} {outcome}: {decision.Comment}";
    }
}

# Chapter 4.6.6 -- Checkpointing and Human Approval

Companion code for **Generative AI in .NET**, Chapter 4 section 4.6.6 ("Checkpointing and Long-Running Workflows").

This sample was added after the first print, because the code printed in 4.6.6 does not compile. See the [errata](../../../docs/errata.md#section-466-checkpointing-and-human-approval) for how the printed APIs map to these.

An expense report is validated and then waits for a manager's approval. The workflow saves a checkpoint to disk while it waits. It then resumes from that checkpoint with a newly built workflow and checkpoint store, receives the decision, and finishes using state written before the pause.

| What 4.6.6 teaches | How this sample does it |
|---|---|
| Custom executor | `Executor<TIn, TOut>` with `HandleAsync` and `IWorkflowContext` |
| Durable checkpoints | `FileSystemJsonCheckpointStore` and `CheckpointManager.CreateJson` |
| Pausing for a person | `RequestPort.Create<ExpenseReport, ApprovalDecision>` |
| Resuming | `InProcessExecution.ResumeStreamingAsync` |
| Replying to the pause | `RequestInfoEvent`, `ExternalRequest.CreateResponse` and `StreamingRun.SendResponseAsync` |
| State that survives a restart | `QueueStateUpdateAsync` and `ReadStateAsync` |
| Custom events | A `WorkflowEvent` subclass with `AddEventAsync` |

## Run it

```bash
dotnet run --project samples/ch04-agent-framework/04.6.6-checkpointing-approval
```

Add `-- --reject` to see the other outcome.

Expected output (the IDs change on each run):

```
Part 1: run until approval is needed
  validated E-1042 for Ada
  approval requested for E-1042 (1850.00)
  paused at checkpoint 3a04229c435a401799e651a1263b9b27

Part 2: resume and approve
  replying to request f1c013d6c3554bab912235984f41c7d9
  E-1042 APPROVED: Within policy.
```

Both parts run in one process so the sample stays simple. To resume in a different process, save the checkpoint's `SessionId` and `CheckpointId`, then pass them to `new CheckpointInfo(sessionId, checkpointId)`. A two-process version of this code was tested on Workflows 1.3.0 and 1.27.0.

## Keep in mind

- **Build a new workflow for each run.** A `Workflow` can belong to only one run at a time.
- **Keep what must survive in workflow state.** Executor fields start empty after a restart unless you save and restore them yourself.
- **Enforce deadlines yourself.** A `RequestPort` waits until it gets a response.

## Prerequisites

- .NET 10 SDK
- No model provider or API key

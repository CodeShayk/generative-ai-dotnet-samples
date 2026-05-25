# Verification Log

Pre-publication verification record for *Generative AI in .NET*. One entry per pass. The most-recent fully-green entry is the print sign-off gate.

**Cadence:**

- **Pre-print:** weekly for the four weeks before print drop.
- **Post-print:** monthly for six months, then quarterly (drives errata releases).

**What each entry covers:** package versions (Critical-5 list), code samples (build + smoke runs), URLs (chapter links + appendices), Anthropic API surface (model IDs in Appendix B + Chapter 4.2.4).

**Sign-off gate before print:**

- [ ] Most recent week is fully green.
- [ ] No package on the watch list has a known breaking change pending.
- [ ] Companion repo CI green on the latest commit.
- [ ] Companion repo tagged `v1.0-first-print` matching the manuscript version.

---

## Template

Copy this block to start a new entry. Date format `YYYY-MM-DD`.

```markdown
## YYYY-MM-DD verification pass

### Packages (Critical-5 list)
- [ ] Microsoft.Extensions.AI -- vX.Y.Z, no change / changelog reviewed
- [ ] Microsoft.Extensions.AI.Abstractions -- ...
- [ ] Microsoft.Extensions.AI.OpenAI -- ...
- [ ] Microsoft.Extensions.AI.Ollama -- ...
- [ ] Microsoft.Extensions.AI.AzureAIInference -- ...
- [ ] Microsoft.Agents.AI -- ...
- [ ] Microsoft.Agents.AI.OpenAI -- ...
- [ ] Microsoft.Agents.AI.Workflows -- ...
- [ ] Microsoft.Agents.AI.AzureAI -- ...
- [ ] ModelContextProtocol -- ...
- [ ] ModelContextProtocol.Core -- ...
- [ ] ModelContextProtocol.AspNetCore -- ...
- [ ] Microsoft.McpServer.ProjectTemplates -- ...
- [ ] Microsoft.Azure.Functions.Worker.Extensions.Mcp -- ...
- [ ] Azure.AI.OpenAI -- ...
- [ ] OpenAI -- ...
- [ ] OllamaSharp -- ...
- [ ] Anthropic.SDK -- ...

### Code samples
- [ ] CI matrix green on commit `<sha>`
- [ ] Live-API smoke tests green (or skipped, with reason)

### URLs
- [ ] Anthropic / Claude documentation links resolve
- [ ] Microsoft Learn links resolve
- [ ] Azure documentation links resolve
- [ ] NuGet package pages resolve

### Anthropic API surface
- [ ] Every model ID in `Appendix-B-Model-Quick-Reference.md` is callable
- [ ] Every model ID in `Chapter-04.md` section 4.2.4 is callable
- [ ] `Anthropic.SDK` API surface used in the chapter examples matches the latest stable

### Issues found / actions taken
- (none) | <description + commit ref + manuscript section touched>
```

---

## 2026-04-30 -- Initial sweep (kickoff)

**Status:** Partial -- snapshot only; subsequent weeks will be full passes.

### Packages
- [x] Critical-5 list re-verified against live NuGet feed; companion repo pinned to `Microsoft.Agents.AI 1.3` and `ModelContextProtocol 1.2`.
- [x] All 37 sample projects build clean on these versions (companion-repo commits `aed6f48` + `1173364`).
- [x] CI matrix green (run 25136332826).

### Code samples
- [x] All 37 samples build clean.
- [ ] Live-API smoke tests -- not yet wired up (P2-1 in next-steps-plan).

### URLs
- [ ] Not run yet -- queue for the first scheduled weekly pass.

### Anthropic API surface
- [ ] Not run yet -- queue for the first scheduled weekly pass (P0-4 in next-steps-plan).

### Issues found / actions taken
- 15 placeholder samples ported to 1.x stable APIs (book-repo commit `09bb7d9` cleared the API-update-pending punch list).

---

*New entries go below this line, most recent first.*

---

## 2026-05-25 -- First post-release monthly sweep; three package families have upgrades; CI verification required

**Status:** Pending -- NuGet survey complete; three package families have upgrades pending CI verification before pins are bumped. No key available for live-API smoke (§2.2 Anthropic key rotation outstanding).

### Packages (Critical-5 list)
- [x] `Microsoft.Extensions.AI` -- **10.5.2 → 10.6.0** (minor bump). Hold at 10.5.2 pending CI verification.
- [x] `Microsoft.Extensions.AI.Abstractions` -- **10.5.2 → 10.6.0**. Hold with family.
- [x] `Microsoft.Extensions.AI.OpenAI` -- **10.5.2 → 10.6.0**. Hold with family.
- [x] `Microsoft.Extensions.AI.Evaluation` -- **10.5.0 → 10.6.0** (skips 10.5.1 -- that version never appeared on NuGet, as expected). Evaluation family finally catches up to core. Hold with MEAI family.
- [x] `Microsoft.Extensions.AI.Evaluation.Quality` -- **10.5.0 → 10.6.0**. Hold with family.
- [x] `Microsoft.Agents.AI` -- **1.3.0 → 1.6.2** (three minor jumps; 1.4.0, 1.5.0, 1.6.x all landed since 2026-05-09 where 1.5.0 was first observed). Hold at 1.3.0 pending CI verification and changelog review.
- [x] `Microsoft.Agents.AI.Abstractions` -- **1.3.0 → 1.6.2**. Hold with family.
- [x] `Microsoft.Agents.AI.OpenAI` -- **1.3.0 → 1.6.2**. Hold with family.
- [x] `Microsoft.Agents.AI.Workflows` -- **1.3.0 → 1.6.2**. Hold with family.
- [x] `Microsoft.Agents.AI.Foundry` -- **1.3.0 → 1.5.0** stable (1.6.2-preview.260521.1 on NuGet; behind the family stable ceiling). Hold; bump to 1.5.0 once family CI is green.
- [x] `Microsoft.Agents.AI.A2A` -- **1.3.0-preview.260423.1 → 1.6.2-preview.260521.1** (preview). Hold with family.
- [x] `Microsoft.Agents.AI.Hosting` -- **1.3.0-preview.260423.1 → 1.6.2-preview.260521.1** (preview). Hold with family.
- [x] `A2A.AspNetCore` -- **1.0.0-preview2** confirmed; no change.
- [x] `ModelContextProtocol` -- **1.2.0 → 1.3.0** (same version observed on 2026-05-09; no further release since). Lowest risk; recommend bumping once CI green.
- [x] `ModelContextProtocol.Core` -- **1.2.0 → 1.3.0**. Hold with family.
- [x] `ModelContextProtocol.AspNetCore` -- **1.2.0 → 1.3.0**. Hold with family.
- [x] `Azure.AI.OpenAI` -- **2.1.0** confirmed; no stable change. `2.9.0-beta.1` preview exists; no action on stable pin.
- [x] `OpenAI` -- **2.10.0** confirmed; no change.
- [x] `OllamaSharp` -- **5.4.25** confirmed; no change.
- [x] `Anthropic.SDK` -- **5.10.0** confirmed; 5.11+ (rebuilt against M.E.AI 10.5+) still not on NuGet. `AnthropicChatClient.cs` shim remains in place.

### Code samples
- [ ] CI matrix not run in this pass -- required before bumping any of the held versions.
- [ ] Live-API smoke tests blocked -- §2.2 Anthropic key rotation not yet completed; no key for live smoke.

### URLs
- [ ] URL audit deferred to next pass.

### Anthropic API surface
- [ ] Skipped -- no Anthropic API key (§2.2 pending).

### Issues found / actions taken
- No pins changed in this pass. Three upgrade paths queued:
    1. **MEAI family 10.5.2 → 10.6.0** (+ Evaluation 10.5.0 → 10.6.0): minor bump. Run CI; if green, bump all five packages together and update `version-matrix.md`.
    2. **Microsoft.Agents.AI family 1.3.0 → 1.6.2**: three minor jumps since last pin; review changelog for breaking changes before bumping. Note: `Foundry` trails at 1.5.0 stable; bump it to 1.5.0 and preview packages (A2A, Hosting) to `1.6.2-preview.260521.1`. Remainder of family to 1.6.2.
    3. **ModelContextProtocol family 1.2.0 → 1.3.0**: was already held from 2026-05-09; no further release since; safest bump.

### Next-pass to-dos
- [ ] Run CI against proposed bumps (MEAI 10.6.0, Agents.AI 1.6.2, MCP 1.3.0). If green, update `Directory.Packages.props` and `docs/version-matrix.md` together per family.
- [ ] Rotate Anthropic API key (§2.2) -- user action at <https://console.anthropic.com/>; unblocks live-API smoke.
- [ ] Once CI green and key rotated: run live-API smoke (workflow_dispatch) to confirm all three Claude model IDs still callable.
- [ ] Create `docs/errata.md` in companion repo (§5 post-print follow-up).
- [ ] Set up weekly CI schedule for live-API smoke (§5 post-print follow-up).

---

## 2026-05-09 -- Pre-print weekly sweep; MEAI patch bump to 10.5.2; manuscript quality fixes; live-API smoke green

**Status:** **Green** -- all builds pass, all 3 Claude model IDs confirmed callable against live API via CI secret, manuscript quality issues fixed.

### Packages (Critical-5 list)
- [x] `Microsoft.Extensions.AI` -- bumped **10.5.1 → 10.5.2** (patch). `Directory.Packages.props` and `docs/version-matrix.md` updated.
- [x] `Microsoft.Extensions.AI.Abstractions` -- bumped **10.5.1 → 10.5.2** (patch).
- [x] `Microsoft.Extensions.AI.OpenAI` -- bumped **10.5.1 → 10.5.2** (patch).
- [x] `Microsoft.Extensions.AI.Evaluation` -- **10.5.0** confirmed; no 10.5.1 on NuGet (as expected). Corrected the version-matrix entry which incorrectly showed 10.5.1.
- [x] `Microsoft.Extensions.AI.Evaluation.Quality` -- **10.5.0** confirmed; same note.
- [x] `Microsoft.Agents.AI` -- **1.5.0** now on NuGet (was 1.3.0; skips 1.4.x). **Held at 1.3.0** pending CI verification. Watch-list item: run CI against 1.5.0 before next print drop.
- [x] `Microsoft.Agents.AI.OpenAI` -- **1.5.0** on NuGet. Held at 1.3.0 with the family.
- [x] `Microsoft.Agents.AI.Workflows` / `.Foundry` / `.Abstractions` -- **1.5.0** family. Held at 1.3.0.
- [x] `ModelContextProtocol` -- **1.3.0** now on NuGet (was 1.2.0). **Held at 1.2.0** pending CI verification.
- [x] `ModelContextProtocol.Core` -- **1.3.0** on NuGet. Held with family.
- [x] `ModelContextProtocol.AspNetCore` -- **1.3.0** on NuGet. Held with family.
- [x] `Azure.AI.OpenAI` -- **2.1.0** confirmed; no change.
- [x] `OpenAI` -- **2.10.0** confirmed; no change.
- [x] `OllamaSharp` -- **5.4.25** confirmed; no change.
- [x] `Anthropic.SDK` -- **5.10.0** confirmed; no change. 5.11+ (rebuilt against M.E.AI 10.5+) still not on NuGet.
- [x] `Microsoft.Extensions.AI.Ollama` / `.AzureAIInference` -- confirmed NOT referenced in `Directory.Packages.props`; samples use `OllamaSharp` and `Azure.AI.OpenAI` directly.

### Code samples
- [x] CI matrix green at companion commit `3f81f99` (2026-05-09). All 6 chapter build jobs pass against MEAI 10.5.2 (run [25599382646](https://github.com/CodeShayk/generative-ai-dotnet-samples/actions/runs/25599382646)).
- [x] **Live-API smoke tests green** -- `workflow_dispatch` run [25599382646](https://github.com/CodeShayk/generative-ai-dotnet-samples/actions/runs/25599382646) ran `tests/AnthropicVerification` against the `ANTHROPIC_API_KEY` repository secret. All three model IDs returned `OK`: `PASS  claude-opus-4-7: OK` / `PASS  claude-sonnet-4-6: OK` / `PASS  claude-haiku-4-5-20251001: OK`.

### URLs
- [x] Full URL audit done 2026-05-03 (114 URLs; 8 broken links fixed). No manuscript URL changes made in this pass beyond the "Last validated" blockquote date update. No new external links added.

### Anthropic API surface
- [x] All three model IDs cited in `Appendix-B-Model-Quick-Reference.md` and `Chapter-04.md` (§4.2.4) confirmed callable against the live API via CI: `claude-opus-4-7`, `claude-sonnet-4-6`, `claude-haiku-4-5-20251001` -- each returned `OK`.
- [x] `Anthropic.SDK` 5.10.0 API surface unchanged. `AnthropicClient.Messages` as `IChatClient` with MEAI 10.3.0 override still works end-to-end.

### Issues found / actions taken
- **Manuscript: "Last validated" blockquotes in all six chapters cited `9.x stable`** (stale version string from original drafting). Updated to `10.5.2 (Evaluation 10.5.0)` in `Chapter-01.md` through `Chapter-06.md`. Date updated from `April 2026` to `May 2026`.
- **Manuscript: Chapter 1 csproj snippet** pinned `Microsoft.Extensions.AI` at `9.4.0` and `OllamaSharp` at `5.1.12` (both stale). Updated to `10.5.2` and `5.4.25` respectively (`Chapter-01.md`).
- **Manuscript: Chapter 4 csproj snippets** had `Microsoft.Extensions.AI Version="9.*"` in two project file examples (lines 222 and 949 of the source). Changed to `Version="10.*"` (`Chapter-04.md`).
- **Manuscript: Appendix C** had `SerializeSession` (truncated, missing `Async`) and described `serialize the thread` (should be `session`). Fixed both in `Appendix-C-Provider-Support-Matrix.md`.
- **Manuscript: TOC section 5.1.3** described `ModelContextProtocol.Client`, `ModelContextProtocol.Server` as separate SDK packages. Corrected to describe the unified `ModelContextProtocol` façade (`TOC.md`).
- **version-matrix.md** showed `Microsoft.Extensions.AI.Evaluation` at `10.5.1` (incorrect -- the package was never published at that version). Corrected to `10.5.0`.

### Next-pass to-dos
- [x] ~~Trigger CI on companion repo after the 10.5.2 MEAI bump; verify all 6 chapter build jobs pass.~~ Done -- run 25599382646 green.
- [x] ~~Force-update `v1.0-first-print` companion tag to HEAD post-CI.~~ Done -- tag at `3f81f99`.
- [ ] Evaluate `Microsoft.Agents.AI` 1.5.0 and `ModelContextProtocol` 1.3.0 for breaking changes; update pins if CI stays green (next weekly pass).
- [ ] Rotate Anthropic API key (§2.2) -- user action at <https://console.anthropic.com/>.

---

## 2026-05-03 -- Option-2 Anthropic shim landed; 04.2.4 sample now runs

**Status:** Green for the previously-yellow Anthropic chapter sample. Defect from 2026-05-02 cleared via path 2 (custom `IChatClient` adapter).

### Packages
- [x] `Anthropic.SDK` -- still v5.10.0 (no 5.11+ on NuGet yet; checked via `dotnet package search Anthropic.SDK --exact-match`).
- [x] `Microsoft.Extensions.AI` -- v10.5.0 central pin unchanged. No per-project `VersionOverride` on the chapter sample.

### Code samples
- [x] `samples/ch04-agent-framework/04.2.4-anthropic-agents` builds clean against the central pins (no override needed).
- [x] Live-API end-to-end run with `claude-haiku-4-5-20251001` -- both turns of the conversation produced real Claude output. No `MissingMethodException`.

### Anthropic API surface
- [x] `ChatClientAgent` over the local shim round-trips through `AnthropicClient.Messages.GetClaudeMessageAsync` with multi-turn history preserved across the second call.

### Issues found / actions taken
- **Implemented path 2 from the 2026-05-02 entry.** Added `samples/ch04-agent-framework/04.2.4-anthropic-agents/AnthropicChatClient.cs` -- a ~120-line `IChatClient` adapter that calls `AnthropicClient.Messages.GetClaudeMessageAsync` directly and translates between Anthropic's wire types and `Microsoft.Extensions.AI` types. Bypasses Anthropic.SDK's bundled `ChatClientHelper`, which is the path that touches the reshaped `HostedMcpServerTool.AuthorizationToken` and throws under M.E.AI 10.5. `Program.cs` now constructs `new AnthropicChatClient(new AnthropicClient(apiKey), modelId)` instead of `new AnthropicClient(apiKey).Messages`. README updated to explain the shim and to call out that it can be removed once Anthropic.SDK 5.11+ ships.
- Streaming is implemented as a single-update wrapper around the non-streaming path; the chapter sample does not stream so this is sufficient. If streaming becomes part of the chapter prose, swap to `AnthropicClient.Messages.StreamClaudeMessageAsync` and yield per chunk.
- Tool calling is intentionally not in the shim (the chapter sample is conversational only). Adding it would mean translating `ChatOptions.Tools` -> `MessageParameters.Tools` and translating `ToolUseContent` responses back into `FunctionCallContent`. Left as future work; not a print-blocker.

### Next-pass to-dos
- [ ] Watch <https://www.nuget.org/packages/Anthropic.SDK> for 5.11+. When it ships rebuilt against M.E.AI 10.5+, delete `AnthropicChatClient.cs`, revert `Program.cs` to `new AnthropicClient(apiKey).Messages`, and re-run the live smoke.
- [ ] Resume the broader URL audit deferred from 2026-05-02.

---

## 2026-05-02 -- P0-4 Anthropic live-API smoke

**Status:** Yellow -- model IDs and URLs verified green; one real defect (M.E.AI ↔ Anthropic.SDK runtime binding gap) blocks the existing Anthropic sample and must be cleared before print.

**Test runs in this entry:** initial pass blocked on zero credit balance; re-run later the same day with funded key returned all three model IDs `OK`.

### Packages
- [x] `Anthropic.SDK` -- v5.10.0 (latest stable on NuGet); central pin unchanged.
- [x] `Microsoft.Extensions.AI` -- v10.5.0 central pin; harness overrides to v10.3.0 to match Anthropic.SDK's compile-time target (see Issues).

### Code samples
- [x] Verification harness at `tests/AnthropicVerification/` builds clean with M.E.AI 10.3.0 override.
- [x] Live-API model-ID smoke through the harness -- **green for all three IDs** (`PASS  claude-opus-4-7: OK`; `PASS  claude-sonnet-4-6: OK`; `PASS  claude-haiku-4-5-20251001: OK`).
- [ ] Existing `samples/ch04-agent-framework/04.2.4-anthropic-agents` -- builds clean but **fails at runtime** with `MissingMethodException` from `Anthropic.SDK.Messaging.ChatClientHelper.CreateMessageParameters` -> `Microsoft.Extensions.AI.FunctionInvokingChatClient.GetResponseAsync` -> `Microsoft.Agents.AI.ChatClientAgent.RunCoreAsync`. Re-confirmed with funded key on 2026-05-02; the defect is independent of credits (see Issues).

### URLs
- [x] `https://docs.anthropic.com/` (cited at `Manuscript/Chapter-04.md:3609`) -- HTTP 200.
- [x] `https://platform.claude.com/docs/en/about-claude/models/overview` (cited at `Manuscript/Appendix-B-Model-Quick-Reference.md:36`) -- HTTP 200.
- [x] Sanity: `https://platform.claude.com/`, `https://docs.anthropic.com/en/docs/about-claude/models/overview` -- both HTTP 200.
- [ ] Microsoft Learn / Azure / NuGet links -- deferred; not in the P0-4 scope.

### Anthropic API surface
- [x] Model IDs in `Manuscript/Appendix-B-Model-Quick-Reference.md:32-34` and `Manuscript/Chapter-04.md:557` (`claude-opus-4-7`, `claude-sonnet-4-6`, `claude-haiku-4-5-20251001`) -- all three callable; harness round-trip returned the expected `OK` response.
- [x] `Anthropic.SDK` package surface used in chapter examples (`new AnthropicClient(key).Messages` as `IChatClient`) -- wire-compatible with the live API; full request/response round-trip confirmed when paired with M.E.AI 10.3.0.

### Issues found / actions taken
- **Defect (blocks print): `samples/ch04-agent-framework/04.2.4-anthropic-agents` does not run against the repo's central pin.** Throws `MissingMethodException: Method not found: 'System.String Microsoft.Extensions.AI.HostedMcpServerTool.get_AuthorizationToken()'.` from `Anthropic.SDK.Messaging.ChatClientHelper.CreateMessageParameters`. Cause: `Anthropic.SDK` 5.10.0's nuspec declares `Microsoft.Extensions.AI.Abstractions >= 10.3.0` but the assembly is compiled against 10.3.0 specifically; M.E.AI 10.5.0 changed the shape of `HostedMcpServerTool.AuthorizationToken` (property-getter no longer present). CI is green because builds succeed against the *abstractions* package surface; runtime binding does not.
    - **Tried: per-project `VersionOverride` to 10.3.0 (initially proposed as option 3).** Verified to *not work* for this sample: `Microsoft.Agents.AI` 1.3.0 is itself compiled against `Microsoft.Extensions.AI.Abstractions` 10.5.0, so downgrading abstractions to 10.3.0 raises `CS1705 (uses higher version than referenced assembly)` at compile time. Override reverted; sample is back to clean build, broken runtime.
    - **The harness avoids the conflict only because it has no `Microsoft.Agents.AI` dependency** -- pure Anthropic.SDK + M.E.AI. Override pin 10.3.0 stays on the harness as the runtime mitigation there.
    - **Remaining viable paths (pre-print decision):**
        1. Wait for `Anthropic.SDK` 5.11+ rebuilt against M.E.AI 10.5+. Cleanest, but not on NuGet as of 2026-05-02 (latest stable: 5.10.0). Watch <https://www.nuget.org/packages/Anthropic.SDK>.
        2. Replace Anthropic.SDK's IChatClient bridge with a small custom `IChatClient` that calls `AnthropicClient.Messages.GetClaudeMessageAsync` directly. ~50 lines in the sample; bypasses the broken `ChatClientHelper`. Changes the chapter narrative slightly (the sample now ships a thin adapter rather than relying on the SDK's built-in adapter).
        3. Switch the sample to the OpenAI SDK pointed at Anthropic's OpenAI-compatibility endpoint. Strongest provider-neutral story, but rewrites the chapter section.
- **CI gap:** the build matrix needs at least one runtime-execution lane for samples that have non-cloud-key prerequisites (currently 04.2.4 needs ANTHROPIC_API_KEY so cannot run unattended; consider adding a stub-key smoke that exercises the M.E.AI binding via `IChatClient` invocation up to the wire-send point).
- Verification harness lives at `tests/AnthropicVerification/` (throwaway, not in `AI in .Net.sln`). Re-run: `ANTHROPIC_API_KEY=<key> dotnet run --project tests/AnthropicVerification`.

### Next-pass to-dos
- [ ] Pick one of paths 1-3 above for the chapter sample. If path 1 (wait for SDK 5.11), open a tracking issue and re-check NuGet weekly. If path 2 (custom IChatClient), implement the bridge, re-run, confirm green. If path 3 (OpenAI-compat endpoint), revise the chapter prose for §4.2.4.
- [ ] Run the broader URL audit (Microsoft Learn, Azure, NuGet) and fold into the next weekly entry.

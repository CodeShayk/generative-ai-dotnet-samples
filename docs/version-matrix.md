# Version Matrix

Mirrors the package matrix in `Appendix-C-Provider-Support-Matrix.md` and `Appendix-A-Package-Reference.md`. Maintain independently of the manuscript so readers can see the *currently-validated* set without rebuying the book.

> **Note.** Versions below are the build-time pins from `Directory.Packages.props`. Per the Critical-5 cadence: weekly until print, monthly for the first six months post-print, quarterly thereafter. When a major or minor version moves, update both `Directory.Packages.props` and this file together.

> **Target framework.** All samples target `net10.0` (.NET 10 LTS) and build with the .NET 10 SDK. The printed book targets .NET 9; the `v1.0-first-print` tag preserves that code.

## Core abstractions

| Package | Pinned version | Stability |
|---|---|---|
| `Microsoft.Extensions.AI` | 10.11.0 | Stable |
| `Microsoft.Extensions.AI.Abstractions` | 10.11.0 | Stable |
| `Microsoft.Extensions.AI.OpenAI` | 10.11.0 | Stable |
| `Microsoft.Extensions.AI.Evaluation` | 10.11.0 | Stable |
| `Microsoft.Extensions.AI.Evaluation.Quality` | 10.11.0 | Stable |

## Microsoft Agent Framework

| Package | Pinned version | Stability |
|---|---|---|
| `Microsoft.Agents.AI` | 1.27.0 | Stable |
| `Microsoft.Agents.AI.Abstractions` | 1.27.0 | Stable |
| `Microsoft.Agents.AI.OpenAI` | 1.27.0 | Stable |
| `Microsoft.Agents.AI.Workflows` | 1.27.0 | Stable |
| `Microsoft.Agents.AI.Foundry` | 1.5.0 | Stable |
| `Microsoft.Agents.AI.A2A` | 1.27.0-preview.261030.1 | Preview |
| `Microsoft.Agents.AI.Hosting` | 1.27.0-preview.261030.1 | Preview |
| `A2A.AspNetCore` | 1.0.0-preview3 | Preview |

## Model Context Protocol

| Package | Pinned version | Stability |
|---|---|---|
| `ModelContextProtocol` | 2.3.1 | Stable |
| `ModelContextProtocol.Core` | 2.3.1 | Stable |
| `ModelContextProtocol.AspNetCore` | 2.3.1 | Stable |

> **Major-version note.** The MCP C# SDK moved 1.x → 2.x after the first print. The samples that create an MCP client now set `DiscoverProbeTimeout` to avoid an intermittent connection failure (see [`errata.md`](errata.md#mcp-2x-new-handshake-and-an-intermittent-connection-failure)). `Appendix-A-Package-Reference.md` describes the `1.2.x` packages as printed. Treat this table as authoritative for current builds.

## Provider SDKs

| Package | Pinned version | Stability |
|---|---|---|
| `Azure.AI.OpenAI` | 2.1.0 | Stable |
| `OpenAI` | 2.15.0 | Stable |
| `OllamaSharp` | 5.5.2 | Stable |
| `Anthropic.SDK` | 5.10.0 | Stable |

## Hosting / DI / ASP.NET Core

| Package | Pinned version |
|---|---|
| `Microsoft.Extensions.Hosting` | 10.0.14 |
| `Microsoft.Extensions.DependencyInjection` | 10.0.14 |
| `Microsoft.Extensions.Configuration` | 10.0.14 |
| `Microsoft.Extensions.Logging` | 10.0.14 |
| `Microsoft.AspNetCore.OpenApi` | 10.0.14 |

## Resilience and Telemetry

| Package | Pinned version |
|---|---|
| `Microsoft.Extensions.Http.Resilience` | 10.11.0 |
| `Microsoft.Extensions.Caching.Memory` | 10.0.14 |
| `OpenTelemetry.Extensions.Hosting` | 1.20.1 |
| `OpenTelemetry.Exporter.OpenTelemetryProtocol` | 1.20.1 |

## Testing

| Package | Pinned version |
|---|---|
| `xunit` | 2.9.3 |
| `xunit.runner.visualstudio` | 4.0.1 |
| `Microsoft.NET.Test.Sdk` | 18.11.0 |

## Last validated

- **2026-11-06** -- Migrated every sample and `tests/AnthropicVerification` from `net9.0` to `net10.0`; `global.json` and CI moved to the .NET 10 SDK. This takes the packages held back in earlier sweeps: the `Microsoft.Extensions.*` hosting/DI/config/logging/caching stack and `Microsoft.AspNetCore.OpenApi` 9.0.0 → 10.0.14, `Microsoft.Extensions.Http.Resilience` 9.0.0 → 10.11.0. No source changes were needed for the migration. Full-solution `dotnet build -c Release` clean with 0 warnings (the OllamaSharp CS9057 warnings are gone, since the newer compiler matches that analyzer); unit tests pass (2/2); `tests/AnthropicVerification` builds clean. Run on .NET 10 without a model or key: `01.4`, `04.6.3`, `06.2.1`, `output-guard-chat-client`, MCP client over stdio (`05.2.10`, `05.3.1`) and HTTP (`05.3.2`, `05.3.3`), plus `cached-mcp-tool-provider`. `02.2` and `04.7` started and answered HTTP. Smoke-tested the same day after fixing the MCP client connection failure and `05.6.3`'s empty-key crash (see [`errata.md`](errata.md)): `tests/AnthropicVerification` passed against the live API for all three Claude models; all 15 Ollama samples ran against `llama3.2` and `nomic-embed-text` rather than `phi4-mini`, with no model downloaded for the test. `04.8` and `05.6.3` were run only as far as connecting to MCP. The 8 OpenAI samples and `04.2.4` were not run, because no key was available locally.
- **2026-11-05** -- Month 6 post-release monthly sweep, the final monthly pass (scheduled 2026-11-09; the Month 5 slot of 2026-10-09 was missed and is superseded by this pass, so this sweep covers two slots of drift). Bumped: MEAI family incl. Evaluation 10.10.0 → 10.11.0; `Microsoft.Agents.AI` core (AI/Abstractions/OpenAI/Workflows) 1.22.0 → 1.27.0 (5 minors; Foundry held at 1.5.0 — still the stable ceiling; preview A2A + Hosting → 1.27.0-preview.261030.1, `04.7-a2a-server` `VersionOverride` bumped to match); `A2A.AspNetCore` 1.0.0-preview2 → 1.0.0-preview3; `ModelContextProtocol` (façade/Core/AspNetCore) 2.2.0 → 2.3.1; `OpenAI` 2.14.0 → 2.15.0; `OllamaSharp` 5.4.30 → 5.5.2; OpenTelemetry (exporter + hosting) 1.19.1 → 1.20.1; test stack `xunit.runner.visualstudio` 4.0.0 → 4.0.1, `Microsoft.NET.Test.Sdk` 18.10.1 → 18.11.0. **One source change:** `MessageResponder.ReplyAsync` gained an optional `metadata` parameter in A2A preview3, so `04.7-a2a-server/Program.cs` now passes `cancellationToken:` by name (the code is not printed in the book). **`A2A.AspNetCore` deliberately held at preview3, not the available preview4:** `Microsoft.Agents.AI.A2A` 1.27 depends on `A2A` 1.0.0-preview3, and these two have moved in lockstep; move them together when the Agent Framework takes preview4. No change: `Azure.AI.OpenAI` 2.1.0, `Anthropic.SDK` 5.10.0 (5.11+ still not published), `Microsoft.Agents.AI.Foundry` 1.5.0, `xunit` 2.9.3 — all at stable NuGet ceiling. **Deliberately held:** the `Microsoft.Extensions.*` hosting/DI/config/logging/caching stack and `Microsoft.AspNetCore.OpenApi` (9.0.0 pinned, 10.0.14 available) and `Microsoft.Extensions.Http.Resilience` (9.0.0 pinned, 10.11.0 available) — still a .NET 10 TFM migration, not a sweep. Full-solution `dotnet build -c Release` clean (0 errors; 15 pre-existing benign OllamaSharp CS9057 analyzer-version warnings), in-solution unit tests pass (2/2), out-of-solution `tests/AnthropicVerification` builds clean, and no vulnerable packages reported. `04.7-a2a-server` was also started locally: the agent card returned 200 and a message reached the agent through to OllamaSharp, failing only on the connection because no Ollama was running, so the `ReplyAsync` line itself was not exercised.
- **2026-09-23** -- Month 4 post-release monthly sweep (scheduled 2026-09-09; the Month 3 slot of 2026-08-09 was missed and is superseded by this pass, so this sweep covers two months of drift). Bumped: MEAI family incl. Evaluation 10.7.0 → 10.10.0 (3 minors); `Microsoft.Agents.AI` core (AI/Abstractions/OpenAI/Workflows) 1.13.0 → 1.22.0 (9 minors; Foundry held at 1.5.0 — still ceiling; preview A2A + Hosting → 1.22.0-preview.260918.1, `04.7-a2a-server` `VersionOverride` bumped to match); **`ModelContextProtocol` (façade/Core/AspNetCore) 1.4.1 → 2.2.0 — a major-version move**; `OpenAI` 2.12.0 → 2.14.0; `OllamaSharp` 5.4.25 → 5.4.30; OpenTelemetry (exporter + hosting) 1.16.0 → 1.19.1; test stack `xunit` 2.9.2 → 2.9.3, `xunit.runner.visualstudio` 2.8.2 → 4.0.0 (major), `Microsoft.NET.Test.Sdk` 17.11.1 → 18.10.1 (major). No change: `Azure.AI.OpenAI` 2.1.0, `Anthropic.SDK` 5.10.0 (5.11+ still not published), `Microsoft.Agents.AI.Foundry` 1.5.0, `A2A.AspNetCore` 1.0.0-preview2 — all at current NuGet ceiling. **Deliberately held:** the `Microsoft.Extensions.*` hosting/DI/config/logging stack, `Microsoft.AspNetCore.OpenApi` (9.0.0 pinned, 10.0.12 available) and `Microsoft.Extensions.Http.Resilience` (9.0.0 pinned, 10.10.0 available) — moving those is a .NET 10 major-version migration for every sample, not a sweep-sized change. Despite the MCP major bump, no source changes were needed: full-solution `dotnet build -c Release` clean (0 errors; 15 pre-existing benign OllamaSharp CS9057 analyzer-version warnings) and in-solution unit tests pass (2/2).
- **2026-07-11** -- Month 2 post-release monthly sweep (scheduled 2026-07-09). Bumped: `Microsoft.Agents.AI` core (AI/Abstractions/OpenAI/Workflows) 1.11.1 → 1.13.0 (2 minors; Foundry held at 1.5.0 — still ceiling; preview A2A + Hosting → 1.13.0-preview.260703.1, `04.7-a2a-server` `VersionOverride` bumped to match); `ModelContextProtocol` (core/Core/AspNetCore) 1.4.0 → 1.4.1 (patch); `OpenAI` 2.11.0 → 2.12.0. No change: MEAI family 10.7.0, MEAI.Evaluation 10.7.0, OpenTelemetry 1.16.0, Azure.AI.OpenAI 2.1.0, OllamaSharp 5.4.25, Anthropic.SDK 5.10.0 — all at current NuGet ceiling (Anthropic.SDK 5.11+ still not published). Full-solution `dotnet build -c Release` clean (0 errors; only the pre-existing benign OllamaSharp CS9057 analyzer-version warnings); in-solution unit tests pass (2/2). No API breakages across the bumps.
- **2026-06-27** -- Month 1 post-release monthly sweep (scheduled 2026-06-09). Bumped: MEAI core+Evaluation 10.6.0 → 10.7.0; Agents.AI core (AI/Abstractions/OpenAI/Workflows) 1.6.2 → 1.11.1 (5 minors; Foundry held at 1.5.0 — latest; preview A2A + Hosting → 1.11.1-preview.260625.1); MCP 1.3.0 → 1.4.0; OpenAI 2.10.0 → 2.11.0. OpenTelemetry (exporter + hosting) 1.10.0 → 1.16.0 to clear advisory GHSA-4625-4j76-fww9 (NU1902, moderate). Azure.AI.OpenAI 2.1.0, OllamaSharp 5.4.25, Anthropic.SDK 5.10.0 already at ceiling (5.11+ still not on NuGet). Also fixed a latent override: `04.7-a2a-server` pinned A2A to 1.3.0-preview via `VersionOverride` while the central pin was newer — bumped the override to match (1.11.1-preview.260625.1). Full solution build + unit tests green locally.
- **2026-05-25** -- First post-release monthly sweep; bumped all three held families together after CI verification: MEAI core 10.5.2 → 10.6.0 (Evaluation 10.5.0 → 10.6.0); Agents.AI 1.3.0 → 1.6.2 (Foundry 1.3.0 → 1.5.0; preview A2A + Hosting updated to 1.6.2-preview.260521.1); MCP 1.2.0 → 1.3.0. Anthropic.SDK still 5.10.0 (5.11+ not yet on NuGet).
- **2026-05-09** -- NuGet sweep; bumped `Microsoft.Extensions.AI` (core + Abstractions + OpenAI) from `10.5.1` to `10.5.2` (patch). Corrected Evaluation pin entry — `Microsoft.Extensions.AI.Evaluation` and `.Evaluation.Quality` remain at `10.5.0`; a 10.5.1 for those packages never appeared on NuGet. `Microsoft.Agents.AI` 1.5.0 and `ModelContextProtocol` 1.3.0 observed on NuGet; held at 1.3.0 and 1.2.0 respectively pending CI verification before bumping.
- **2026-05-03** -- NuGet sweep; bumped `Microsoft.Extensions.AI` family from `10.5.0` to `10.5.1`. All other Critical-5 pins confirmed at their current stable ceiling. Version matrix rewritten from stale 0.3.x-preview baseline.

# Version Matrix

Mirrors the package matrix in `Appendix-C-Provider-Support-Matrix.md` and `Appendix-A-Package-Reference.md`. Maintain independently of the manuscript so readers can see the *currently-validated* set without rebuying the book.

> **Note.** Versions below are the build-time pins from `Directory.Packages.props`. Per the Critical-5 cadence: weekly until print, monthly for the first six months post-print, quarterly thereafter. When a major or minor version moves, update both `Directory.Packages.props` and this file together.

## Core abstractions

| Package | Pinned version | Stability |
|---|---|---|
| `Microsoft.Extensions.AI` | 10.10.0 | Stable |
| `Microsoft.Extensions.AI.Abstractions` | 10.10.0 | Stable |
| `Microsoft.Extensions.AI.OpenAI` | 10.10.0 | Stable |
| `Microsoft.Extensions.AI.Evaluation` | 10.10.0 | Stable |
| `Microsoft.Extensions.AI.Evaluation.Quality` | 10.10.0 | Stable |

## Microsoft Agent Framework

| Package | Pinned version | Stability |
|---|---|---|
| `Microsoft.Agents.AI` | 1.22.0 | Stable |
| `Microsoft.Agents.AI.Abstractions` | 1.22.0 | Stable |
| `Microsoft.Agents.AI.OpenAI` | 1.22.0 | Stable |
| `Microsoft.Agents.AI.Workflows` | 1.22.0 | Stable |
| `Microsoft.Agents.AI.Foundry` | 1.5.0 | Stable |
| `Microsoft.Agents.AI.A2A` | 1.22.0-preview.260918.1 | Preview |
| `Microsoft.Agents.AI.Hosting` | 1.22.0-preview.260918.1 | Preview |
| `A2A.AspNetCore` | 1.0.0-preview2 | Preview |

## Model Context Protocol

| Package | Pinned version | Stability |
|---|---|---|
| `ModelContextProtocol` | 2.2.0 | Stable |
| `ModelContextProtocol.Core` | 2.2.0 | Stable |
| `ModelContextProtocol.AspNetCore` | 2.2.0 | Stable |

> **Major-version note.** The MCP C# SDK moved 1.x → 2.x after the first print. The Chapter 5 samples build and run unchanged against 2.2.0, but `Appendix-A-Package-Reference.md` describes the `1.2.x` packages as printed. Treat this table as authoritative for current builds.

## Provider SDKs

| Package | Pinned version | Stability |
|---|---|---|
| `Azure.AI.OpenAI` | 2.1.0 | Stable |
| `OpenAI` | 2.14.0 | Stable |
| `OllamaSharp` | 5.4.30 | Stable |
| `Anthropic.SDK` | 5.10.0 | Stable |

## Hosting / DI / ASP.NET Core

| Package | Pinned version |
|---|---|
| `Microsoft.Extensions.Hosting` | 9.0.0 |
| `Microsoft.Extensions.DependencyInjection` | 9.0.0 |
| `Microsoft.Extensions.Configuration` | 9.0.0 |
| `Microsoft.Extensions.Logging` | 9.0.0 |
| `Microsoft.AspNetCore.OpenApi` | 9.0.0 |

## Resilience and Telemetry

| Package | Pinned version |
|---|---|
| `Microsoft.Extensions.Http.Resilience` | 9.0.0 |
| `Microsoft.Extensions.Caching.Memory` | 9.0.0 |
| `OpenTelemetry.Extensions.Hosting` | 1.19.1 |
| `OpenTelemetry.Exporter.OpenTelemetryProtocol` | 1.19.1 |

## Testing

| Package | Pinned version |
|---|---|
| `xunit` | 2.9.3 |
| `xunit.runner.visualstudio` | 4.0.0 |
| `Microsoft.NET.Test.Sdk` | 18.10.1 |

## Last validated

- **2026-09-23** -- Month 4 post-release monthly sweep (scheduled 2026-09-09; the Month 3 slot of 2026-08-09 was missed and is superseded by this pass, so this sweep covers two months of drift). Bumped: MEAI family incl. Evaluation 10.7.0 → 10.10.0 (3 minors); `Microsoft.Agents.AI` core (AI/Abstractions/OpenAI/Workflows) 1.13.0 → 1.22.0 (9 minors; Foundry held at 1.5.0 — still ceiling; preview A2A + Hosting → 1.22.0-preview.260918.1, `04.7-a2a-server` `VersionOverride` bumped to match); **`ModelContextProtocol` (façade/Core/AspNetCore) 1.4.1 → 2.2.0 — a major-version move**; `OpenAI` 2.12.0 → 2.14.0; `OllamaSharp` 5.4.25 → 5.4.30; OpenTelemetry (exporter + hosting) 1.16.0 → 1.19.1; test stack `xunit` 2.9.2 → 2.9.3, `xunit.runner.visualstudio` 2.8.2 → 4.0.0 (major), `Microsoft.NET.Test.Sdk` 17.11.1 → 18.10.1 (major). No change: `Azure.AI.OpenAI` 2.1.0, `Anthropic.SDK` 5.10.0 (5.11+ still not published), `Microsoft.Agents.AI.Foundry` 1.5.0, `A2A.AspNetCore` 1.0.0-preview2 — all at current NuGet ceiling. **Deliberately held:** the `Microsoft.Extensions.*` hosting/DI/config/logging stack, `Microsoft.AspNetCore.OpenApi` (9.0.0 pinned, 10.0.12 available) and `Microsoft.Extensions.Http.Resilience` (9.0.0 pinned, 10.10.0 available) — moving those is a .NET 10 major-version migration for every sample, not a sweep-sized change. Despite the MCP major bump, no source changes were needed: full-solution `dotnet build -c Release` clean (0 errors; 15 pre-existing benign OllamaSharp CS9057 analyzer-version warnings) and in-solution unit tests pass (2/2).
- **2026-07-11** -- Month 2 post-release monthly sweep (scheduled 2026-07-09). Bumped: `Microsoft.Agents.AI` core (AI/Abstractions/OpenAI/Workflows) 1.11.1 → 1.13.0 (2 minors; Foundry held at 1.5.0 — still ceiling; preview A2A + Hosting → 1.13.0-preview.260703.1, `04.7-a2a-server` `VersionOverride` bumped to match); `ModelContextProtocol` (core/Core/AspNetCore) 1.4.0 → 1.4.1 (patch); `OpenAI` 2.11.0 → 2.12.0. No change: MEAI family 10.7.0, MEAI.Evaluation 10.7.0, OpenTelemetry 1.16.0, Azure.AI.OpenAI 2.1.0, OllamaSharp 5.4.25, Anthropic.SDK 5.10.0 — all at current NuGet ceiling (Anthropic.SDK 5.11+ still not published). Full-solution `dotnet build -c Release` clean (0 errors; only the pre-existing benign OllamaSharp CS9057 analyzer-version warnings); in-solution unit tests pass (2/2). No API breakages across the bumps.
- **2026-06-27** -- Month 1 post-release monthly sweep (scheduled 2026-06-09). Bumped: MEAI core+Evaluation 10.6.0 → 10.7.0; Agents.AI core (AI/Abstractions/OpenAI/Workflows) 1.6.2 → 1.11.1 (5 minors; Foundry held at 1.5.0 — latest; preview A2A + Hosting → 1.11.1-preview.260625.1); MCP 1.3.0 → 1.4.0; OpenAI 2.10.0 → 2.11.0. OpenTelemetry (exporter + hosting) 1.10.0 → 1.16.0 to clear advisory GHSA-4625-4j76-fww9 (NU1902, moderate). Azure.AI.OpenAI 2.1.0, OllamaSharp 5.4.25, Anthropic.SDK 5.10.0 already at ceiling (5.11+ still not on NuGet). Also fixed a latent override: `04.7-a2a-server` pinned A2A to 1.3.0-preview via `VersionOverride` while the central pin was newer — bumped the override to match (1.11.1-preview.260625.1). Full solution build + unit tests green locally.
- **2026-05-25** -- First post-release monthly sweep; bumped all three held families together after CI verification: MEAI core 10.5.2 → 10.6.0 (Evaluation 10.5.0 → 10.6.0); Agents.AI 1.3.0 → 1.6.2 (Foundry 1.3.0 → 1.5.0; preview A2A + Hosting updated to 1.6.2-preview.260521.1); MCP 1.2.0 → 1.3.0. Anthropic.SDK still 5.10.0 (5.11+ not yet on NuGet).
- **2026-05-09** -- NuGet sweep; bumped `Microsoft.Extensions.AI` (core + Abstractions + OpenAI) from `10.5.1` to `10.5.2` (patch). Corrected Evaluation pin entry — `Microsoft.Extensions.AI.Evaluation` and `.Evaluation.Quality` remain at `10.5.0`; a 10.5.1 for those packages never appeared on NuGet. `Microsoft.Agents.AI` 1.5.0 and `ModelContextProtocol` 1.3.0 observed on NuGet; held at 1.3.0 and 1.2.0 respectively pending CI verification before bumping.
- **2026-05-03** -- NuGet sweep; bumped `Microsoft.Extensions.AI` family from `10.5.0` to `10.5.1`. All other Critical-5 pins confirmed at their current stable ceiling. Version matrix rewritten from stale 0.3.x-preview baseline.

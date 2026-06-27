# Version Matrix

Mirrors the package matrix in `Appendix-C-Provider-Support-Matrix.md` and `Appendix-A-Package-Reference.md`. Maintain independently of the manuscript so readers can see the *currently-validated* set without rebuying the book.

> **Note.** Versions below are the build-time pins from `Directory.Packages.props`. Per the Critical-5 cadence: weekly until print, monthly for the first six months post-print, quarterly thereafter. When a major or minor version moves, update both `Directory.Packages.props` and this file together.

## Core abstractions

| Package | Pinned version | Stability |
|---|---|---|
| `Microsoft.Extensions.AI` | 10.7.0 | Stable |
| `Microsoft.Extensions.AI.Abstractions` | 10.7.0 | Stable |
| `Microsoft.Extensions.AI.OpenAI` | 10.7.0 | Stable |
| `Microsoft.Extensions.AI.Evaluation` | 10.7.0 | Stable |
| `Microsoft.Extensions.AI.Evaluation.Quality` | 10.7.0 | Stable |

## Microsoft Agent Framework

| Package | Pinned version | Stability |
|---|---|---|
| `Microsoft.Agents.AI` | 1.11.1 | Stable |
| `Microsoft.Agents.AI.Abstractions` | 1.11.1 | Stable |
| `Microsoft.Agents.AI.OpenAI` | 1.11.1 | Stable |
| `Microsoft.Agents.AI.Workflows` | 1.11.1 | Stable |
| `Microsoft.Agents.AI.Foundry` | 1.5.0 | Stable |
| `Microsoft.Agents.AI.A2A` | 1.11.1-preview.260625.1 | Preview |
| `Microsoft.Agents.AI.Hosting` | 1.11.1-preview.260625.1 | Preview |
| `A2A.AspNetCore` | 1.0.0-preview2 | Preview |

## Model Context Protocol

| Package | Pinned version | Stability |
|---|---|---|
| `ModelContextProtocol` | 1.4.0 | Stable |
| `ModelContextProtocol.Core` | 1.4.0 | Stable |
| `ModelContextProtocol.AspNetCore` | 1.4.0 | Stable |

## Provider SDKs

| Package | Pinned version | Stability |
|---|---|---|
| `Azure.AI.OpenAI` | 2.1.0 | Stable |
| `OpenAI` | 2.11.0 | Stable |
| `OllamaSharp` | 5.4.25 | Stable |
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
| `OpenTelemetry.Extensions.Hosting` | 1.16.0 |
| `OpenTelemetry.Exporter.OpenTelemetryProtocol` | 1.16.0 |

## Last validated

- **2026-06-27** -- Month 1 post-release monthly sweep (scheduled 2026-06-09). Bumped: MEAI core+Evaluation 10.6.0 → 10.7.0; Agents.AI core (AI/Abstractions/OpenAI/Workflows) 1.6.2 → 1.11.1 (5 minors; Foundry held at 1.5.0 — latest; preview A2A + Hosting → 1.11.1-preview.260625.1); MCP 1.3.0 → 1.4.0; OpenAI 2.10.0 → 2.11.0. OpenTelemetry (exporter + hosting) 1.10.0 → 1.16.0 to clear advisory GHSA-4625-4j76-fww9 (NU1902, moderate). Azure.AI.OpenAI 2.1.0, OllamaSharp 5.4.25, Anthropic.SDK 5.10.0 already at ceiling (5.11+ still not on NuGet). Also fixed a latent override: `04.7-a2a-server` pinned A2A to 1.3.0-preview via `VersionOverride` while the central pin was newer — bumped the override to match (1.11.1-preview.260625.1). Full solution build + unit tests green locally.
- **2026-05-25** -- First post-release monthly sweep; bumped all three held families together after CI verification: MEAI core 10.5.2 → 10.6.0 (Evaluation 10.5.0 → 10.6.0); Agents.AI 1.3.0 → 1.6.2 (Foundry 1.3.0 → 1.5.0; preview A2A + Hosting updated to 1.6.2-preview.260521.1); MCP 1.2.0 → 1.3.0. Anthropic.SDK still 5.10.0 (5.11+ not yet on NuGet).
- **2026-05-09** -- NuGet sweep; bumped `Microsoft.Extensions.AI` (core + Abstractions + OpenAI) from `10.5.1` to `10.5.2` (patch). Corrected Evaluation pin entry — `Microsoft.Extensions.AI.Evaluation` and `.Evaluation.Quality` remain at `10.5.0`; a 10.5.1 for those packages never appeared on NuGet. `Microsoft.Agents.AI` 1.5.0 and `ModelContextProtocol` 1.3.0 observed on NuGet; held at 1.3.0 and 1.2.0 respectively pending CI verification before bumping.
- **2026-05-03** -- NuGet sweep; bumped `Microsoft.Extensions.AI` family from `10.5.0` to `10.5.1`. All other Critical-5 pins confirmed at their current stable ceiling. Version matrix rewritten from stale 0.3.x-preview baseline.

# Chapter 1.4 -- Secrets and Configuration

Companion code for **Generative AI in .NET**, Chapter 1 section 1.4.4 ("Managing Secrets with User Secrets and Environment Variables").

Demonstrates the canonical .NET configuration stack used by every other sample: `appsettings.json` for non-secret defaults, **User Secrets** for per-developer credentials in development, and **environment variables** for CI/production. Values are merged in that order; later sources override earlier ones.

## Run it

```bash
# 1. Add a development secret (this writes to ~/.microsoft/usersecrets/<UserSecretsId>/secrets.json -- never the repo).
dotnet user-secrets set "OpenAI:ApiKey" "sk-test-123" \
  --project samples/ch01-foundations/01.4-secrets-and-config

# 2. Run.
dotnet run --project samples/ch01-foundations/01.4-secrets-and-config

# 3. Override at the env-var level.
OpenAI__ApiKey=env-wins dotnet run --project samples/ch01-foundations/01.4-secrets-and-config
```

The output masks every value so you can demonstrate secret resolution in a screencast or workshop without leaking credentials.

## Manuscript reference

- `Manuscript/Chapter-01.md`, section 1.4.4.

## Prerequisites

- .NET 10 SDK.

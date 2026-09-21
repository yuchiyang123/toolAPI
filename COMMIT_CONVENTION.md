# Commit Message Convention

All commit messages are written in **English** and follow
[Conventional Commits 1.0](https://www.conventionalcommits.org/).

```
<type>(<scope>): <subject>

<body>

<footer>
```

## Type (required)

| type | use for |
|---|---|
| `feat` | a new user-facing capability |
| `fix` | a bug fix |
| `perf` | a change that improves performance without changing behaviour |
| `refactor` | code change that neither fixes a bug nor adds a feature |
| `security` | hardening: auth, input validation, secrets, headers |
| `build` | build system, dependencies, Dockerfile, package.json |
| `ci` | CI/CD workflow changes |
| `test` | adding or fixing tests only |
| `docs` | documentation only |
| `chore` | anything else that does not touch src or tests |

## Scope (required)

Backend (`toolAPI`): `api`, `judge`, `post`, `recipe`, `flow`, `8bit`, `cache`, `mq`, `auth`, `config`, `db`
Frontend (`tools`): `web`, `capsule`, `judge`, `post`, `recipe`, `flow`, `8bit`, `draw`, `proxy`, `config`, `deps`
Cross-cutting: `ci`, `docker`, `docs`

## Subject (required)

- imperative mood, lower-case, no trailing period: `add`, `fix`, `remove` — not `added`, `fixes`
- ≤ 72 characters
- no ticket numbers here; put them in the footer

## Body (recommended for anything non-trivial)

- wrap at 72 columns
- explain **what** and **why**, not how
- one bullet per logical change when a commit touches several things
- reference audit items from `重構核心.md` by id, e.g. `Refs: B14, B17`

## Footer

- `BREAKING CHANGE: <description>` when a public API / config key / env var changes
- `Refs: <ids>` for audit items, `Closes #<n>` for GitHub issues
- attribution trailers (`Co-Authored-By:`) go last

## Examples

```
perf(cache): replace SCAN-based list invalidation with version keys

List caches were invalidated by scanning the whole Redis keyspace on
every write. Each list now carries a version number (`ver:{service}`)
that is bumped on invalidation, so writes are O(1) and stale pages
simply miss on the next read.

Also fixes RecipeList and ProblemsList sharing the same cache key.

Refs: B14
```

```
fix(capsule): unwrap AppKit provider ref before creating wallet client

`useAppKitProvider()` returns a Ref; passing it straight to
`custom()` produced an invalid EIP-1193 transport and every write
failed. Switch to `switchChainAsync` so the chain change is awaited
before signing.

Refs: W3, W4
```

## Rules

1. One logical change per commit. Formatting-only changes (`csharpier`, prettier) get their own `chore` commit.
2. Never commit secrets, `.env`, or generated output (`dist/`, `bin/`, `obj/`).
3. Every commit on `master` must build and pass tests — CI is the gate.

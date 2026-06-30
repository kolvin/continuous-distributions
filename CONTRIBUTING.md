<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
## Contents

- [Contributing](#contributing)
    - [Prerequisites](#prerequisites)
    - [Setup](#setup)
    - [Development workflow](#development-workflow)
    - [Commit conventions](#commit-conventions)
    - [CI](#ci)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# Contributing

## Prerequisites

- [.NET 10 SDK](https://aka.ms/dotnet/download)
- [pre-commit](https://pre-commit.com/#install)
- Git

## Setup

After cloning, install the pre-commit hooks:

```bash
make install
```

This ensures every commit is checked for formatting, merge conflicts, and file hygiene before it leaves your machine.

## Development workflow

1. Create a branch from `main`:
   ```bash
   git checkout -b feat/my-feature
   ```

2. Make your changes. All new logic must be accompanied by test coverage.

3. Run pre-commit checks locally before pushing:
   ```bash
   make validate
   ```

4. Commit using [Conventional Commits](https://www.conventionalcommits.org):
   ```
   feat: add new distribution
   fix: correct formula
   docs: update README
   test: add edge-case coverage
   chore: bump dependencies
   ```

5. Open a pull request against `main`.

6. Squash and merge — all commits on the branch are squashed into a single commit on `main`. Make sure the squash commit message follows the Conventional Commits format, as this is what semantic-release reads to determine the version bump.

## Commit conventions

This repo uses [semantic-release](https://semantic-release.gitbook.io) to automate versioning and GitHub releases. The version bump is determined solely by commit message prefixes:

| Prefix | When to use | Version effect |
|---|---|---|
| `feat:` | new user-visible behaviour | minor bump |
| `fix:` | bug correction | patch bump |
| `feat!:` / `BREAKING CHANGE:` footer | breaks existing API | major bump |
| `docs:` | documentation only | no release |
| `test:` | tests only | no release |
| `chore:` | tooling, deps, config | no release |
| `refactor:` | internal restructure, no behaviour change | no release |

## CI

The GitHub Actions workflow runs on every push to `main`:

1. `dotnet restore`
2. `dotnet build --configuration Release`
3. `dotnet test --configuration Release`
4. `semantic-release` — creates a GitHub release and tag if the commit warrants one

Pull request branches are not released — only merges to `main` trigger a release.

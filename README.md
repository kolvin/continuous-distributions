<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
## Contents

- [continuous-distributions](#continuous-distributions)
    - [Overview](#overview)
    - [Requirements](#requirements)
    - [Roadmap](#roadmap)
    - [Releases](#releases)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# continuous-distributions

A C# library of continuous probability distributions.

## Overview

This library provides a shared interface for continuous probability distributions, making it straightforward to work with different distributions in a consistent, polymorphic way.

## Requirements

- [.NET 10 SDK](https://aka.ms/dotnet/download)

## Roadmap

- [ ] `IContinuousDistribution` interface
- [ ] `NormalDistribution` implementation
- [ ] `LogNormalDistribution` implementation
- [ ] Unit, integration and functional test suite
- [ ] CLI console application
- [ ] CI pipeline with lint, static analysis, test, and semantic-release
- [ ] Branch protection and PR workflow

## Releases

Versioning is handled automatically by [semantic-release](https://semantic-release.gitbook.io) on every push to `main`. Commit messages must follow [Conventional Commits](https://www.conventionalcommits.org):

| Prefix | Effect |
|---|---|
| `feat:` | minor version bump |
| `fix:` | patch version bump |
| `feat!:` or `BREAKING CHANGE:` | major version bump |
| `chore:`, `docs:`, `test:` | no release |

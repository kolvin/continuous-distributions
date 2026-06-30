# continuous-distributions

[![codecov](https://codecov.io/gh/kolvin/continuous-distributions/graph/badge.svg)](https://codecov.io/gh/kolvin/continuous-distributions)
[![Conventional Commits](https://img.shields.io/badge/Conventional%20Commits-1.0.0-%23FE5196?logo=conventionalcommits&logoColor=white)](https://conventionalcommits.org)

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
## Contents

- [Overview](#overview)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
    - [Normal distribution](#normal-distribution)
    - [Log-normal distribution](#log-normal-distribution)
    - [Polymorphic usage](#polymorphic-usage)
    - [Float precision](#float-precision)
    - [Console application](#console-application)
- [Roadmap](#roadmap)
- [Releases](#releases)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

A C# library of continuous probability distributions.

## Overview

This library provides a shared interface for continuous probability distributions, making it straightforward to work with different distributions in a consistent, polymorphic way.

Both distributions are generic over `IFloatingPointIeee754<T>`, so they work with `double`, `float`, or any other IEEE 754 floating-point type — no code duplication required.

## Requirements

- [.NET 10 SDK](https://aka.ms/dotnet/download)

## Installation

Packages are published to [GitHub Packages](https://github.com/kolvin/continuous-distributions/pkgs/nuget/Distributions). First add the source:

```sh
dotnet nuget add source \
  --username <your-github-username> \
  --password <your-github-token> \
  --store-password-in-clear-text \
  --name github \
  "https://nuget.pkg.github.com/kolvin/index.json"
```

Then add the package:

```sh
dotnet add package Distributions
```

## Usage

### Normal distribution

```csharp
using Distributions;

var dist = new NormalDistribution<double>(mu: 3, sigmaSquared: 1.5);

Console.WriteLine(dist.Pdf(3.6));   // 0.28890103549202527
Console.WriteLine(dist.Mean);       // 3
Console.WriteLine(dist.Variance);   // 1.5
Console.WriteLine(dist);            // Normal(μ=3, σ²=1.5)
```

### Log-normal distribution

```csharp
using Distributions;

var dist = new LogNormalDistribution<double>(mu: 3, sigmaSquared: 1.5);

Console.WriteLine(dist.Pdf(3.6));   // 0.033787385801803826
Console.WriteLine(dist.Mean);       // 42.52108200006278
Console.WriteLine(dist.Variance);   // 6295.041513119321
Console.WriteLine(dist);            // Log-normal(μ=3, σ²=1.5)
```

### Polymorphic usage

Both distributions implement `IContinuousDistribution<T>`, so they can be used interchangeably:

```csharp
using Distributions;

IContinuousDistribution<double>[] distributions =
[
    new NormalDistribution<double>(mu: 0, sigmaSquared: 1),
    new LogNormalDistribution<double>(mu: 0, sigmaSquared: 1),
];

foreach (var dist in distributions)
{
    Console.WriteLine($"{dist} → Pdf(1.0) = {dist.Pdf(1.0):F4}");
}
```

### Float precision

For performance-sensitive paths, use `float` instead of `double`:

```csharp
using Distributions;

var dist = new NormalDistribution<float>(mu: 3f, sigmaSquared: 1.5f);
Console.WriteLine(dist.Pdf(3.6f));
```

### Console application

The included CLI prints both distributions for given parameters:

```sh
dotnet run --project Distributions.Console -- <mu> <sigmaSquared> <x>
```

```sh
$ dotnet run --project Distributions.Console -- 3 1.5 3.6
Normal(3.6;3,1.5) = 0.2889010354920253 (Mean : 3, Variance : 1.5)
Log-normal(3.6;3,1.5) = 0.03378738580180383 (Mean : 42.52108200006278, Variance : 6295.041513119321)
```

## Roadmap

- [x] `IContinuousDistribution` interface
- [x] `NormalDistribution` implementation
- [x] `LogNormalDistribution` implementation
- [x] Unit, integration and functional test suite
- [x] CLI console application
- [x] CI pipeline with lint, static analysis, test, and semantic-release
- [x] Branch protection and PR workflow

## Releases

Versioning is handled automatically by [semantic-release](https://semantic-release.gitbook.io) on every push to `main`. Commit messages must follow [Conventional Commits](https://www.conventionalcommits.org):

| Prefix | Effect |
|---|---|
| `feat:` | minor version bump |
| `fix:` | patch version bump |
| `feat!:` or `BREAKING CHANGE:` | major version bump |
| `chore:`, `docs:`, `test:` | no release |

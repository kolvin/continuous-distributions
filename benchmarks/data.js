window.BENCHMARK_DATA = {
  "lastUpdate": 1782859746389,
  "repoUrl": "https://github.com/kolvin/continuous-distributions",
  "entries": {
    "Benchmark": [
      {
        "commit": {
          "author": {
            "email": "15124052+kolvin@users.noreply.github.com",
            "name": "Calvin Taylor",
            "username": "kolvin"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "5ec18ab9de0e122ca7a6f005208c47b0fb67eb04",
          "message": "fix: reorder plugins so exec updates csproj before git commits it (#16)",
          "timestamp": "2026-06-30T19:30:43-03:00",
          "tree_id": "8cb9f16fd63eb73f818843ba5b7a762911124902",
          "url": "https://github.com/kolvin/continuous-distributions/commit/5ec18ab9de0e122ca7a6f005208c47b0fb67eb04"
        },
        "date": 1782858731541,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.NormalPdf",
            "value": 25.181742290655773,
            "unit": "ns",
            "range": "± 0.021367847794404267"
          },
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.LogNormalPdf",
            "value": 24.560088074633054,
            "unit": "ns",
            "range": "± 0.03290832715711387"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "15124052+kolvin@users.noreply.github.com",
            "name": "Calvin Taylor",
            "username": "kolvin"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "a371a6511fbefe759aa0d1f97b908655cf5d0fd0",
          "message": "feat: make distributions generic over IFloatingPointIeee754<T> (#17)",
          "timestamp": "2026-06-30T19:47:45-03:00",
          "tree_id": "a18fcbf9891dbdd210ec3bd372f9defeab3cbbe5",
          "url": "https://github.com/kolvin/continuous-distributions/commit/a371a6511fbefe759aa0d1f97b908655cf5d0fd0"
        },
        "date": 1782859745814,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.NormalPdf",
            "value": 7.6861235437293844,
            "unit": "ns",
            "range": "± 0.015472977270300907"
          },
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.LogNormalPdf",
            "value": 8.581468279872622,
            "unit": "ns",
            "range": "± 0.02545397187530712"
          }
        ]
      }
    ]
  }
}
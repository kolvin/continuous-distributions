window.BENCHMARK_DATA = {
  "lastUpdate": 1782860885408,
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
          "id": "13b9f197ddefaf49921edcdad8a137b0fc6e7336",
          "message": "feat: implement IEquatable<T> and DebuggerDisplay on distribution classes (#18)",
          "timestamp": "2026-06-30T19:54:18-03:00",
          "tree_id": "0a5f0881e0569bc58be0bf5b590ffbc30ffe0b72",
          "url": "https://github.com/kolvin/continuous-distributions/commit/13b9f197ddefaf49921edcdad8a137b0fc6e7336"
        },
        "date": 1782860135734,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.NormalPdf",
            "value": 7.675469163518685,
            "unit": "ns",
            "range": "± 0.008873782319461159"
          },
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.LogNormalPdf",
            "value": 8.625015921317614,
            "unit": "ns",
            "range": "± 0.03022846892715081"
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
          "id": "3cd4b47b54c5182e4489c5b3bb699980b0dbd0cd",
          "message": "docs: add installation and usage guide to README (#19)",
          "timestamp": "2026-06-30T19:58:46-03:00",
          "tree_id": "b03f3e1dfb2187a4374d41b9ab7c1ad5f82f196b",
          "url": "https://github.com/kolvin/continuous-distributions/commit/3cd4b47b54c5182e4489c5b3bb699980b0dbd0cd"
        },
        "date": 1782860401225,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.NormalPdf",
            "value": 7.571860335194147,
            "unit": "ns",
            "range": "± 0.01306934182724949"
          },
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.LogNormalPdf",
            "value": 7.75386094674468,
            "unit": "ns",
            "range": "± 0.010259127649820059"
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
          "id": "251a8b56f012f2e225443a20031ca387bcecf256",
          "message": "test: cover object equality and wrong-type paths for IEquatable implementations (#20)",
          "timestamp": "2026-06-30T20:06:45-03:00",
          "tree_id": "6117a271dbfdb97ebe2e78328b234d7a7c5f29a5",
          "url": "https://github.com/kolvin/continuous-distributions/commit/251a8b56f012f2e225443a20031ca387bcecf256"
        },
        "date": 1782860885171,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.NormalPdf",
            "value": 7.687554809663977,
            "unit": "ns",
            "range": "± 0.02834363717509068"
          },
          {
            "name": "Distributions.Benchmarks.PdfBenchmarks.LogNormalPdf",
            "value": 8.552674048713275,
            "unit": "ns",
            "range": "± 0.0046669416575935325"
          }
        ]
      }
    ]
  }
}
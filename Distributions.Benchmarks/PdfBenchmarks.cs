using BenchmarkDotNet.Attributes;
using Distributions;

namespace Distributions.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
public class PdfBenchmarks
{
    private readonly NormalDistribution _normal = new(mu: 0, sigmaSquared: 1);
    private readonly LogNormalDistribution _logNormal = new(mu: 0, sigmaSquared: 1);

    [Benchmark]
    public double NormalPdf() => _normal.Pdf(1.5);

    [Benchmark]
    public double LogNormalPdf() => _logNormal.Pdf(1.5);
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Json;
using Distributions;

namespace Distributions.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[JsonExporterAttribute.Full]
public class PdfBenchmarks
{
    private readonly NormalDistribution<double> _normal = new(mu: 0, sigmaSquared: 1);
    private readonly LogNormalDistribution<double> _logNormal = new(mu: 0, sigmaSquared: 1);

    [Benchmark]
    public double NormalPdf() => _normal.Pdf(1.5);

    [Benchmark]
    public double LogNormalPdf() => _logNormal.Pdf(1.5);
}

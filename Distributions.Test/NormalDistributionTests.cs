using Distributions;

namespace Distributions.Test;

public class NormalDistributionTests
{
    private readonly NormalDistribution<double> _dist = new(mu: 3, sigmaSquared: 1.5);

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(double.NegativeInfinity)]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenSigmaSquaredIsInvalid(double sigmaSquared)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new NormalDistribution<double>(mu: 0, sigmaSquared: sigmaSquared));
    }

    [Fact]
    public void Mean_ReturnsExpectedValue()
    {
        Assert.Equal(3.0000, Math.Round(_dist.Mean, 4));
    }

    [Fact]
    public void Variance_ReturnsExpectedValue()
    {
        Assert.Equal(1.5000, Math.Round(_dist.Variance, 4));
    }

    [Theory]
    [InlineData(3.0, 0.3257)]
    [InlineData(3.6, 0.2889)]
    [InlineData(4.5, 0.1539)]
    public void Pdf_ReturnsExpectedValue(double x, double expected)
    {
        Assert.Equal(expected, Math.Round(_dist.Pdf(x), 4));
    }

    [Fact]
    public void ToString_ReturnsExpectedFormat()
    {
        Assert.Equal("Normal(μ=3, σ²=1.5)", _dist.ToString());
    }

    [Fact]
    public void CanBeInstantiated_WithFloatPrecision()
    {
        var dist = new NormalDistribution<float>(mu: 3f, sigmaSquared: 1.5f);
        Assert.True(float.IsFinite(dist.Pdf(3.6f)));
    }

    [Fact]
    public void Equals_ReturnsTrue_ForSameParameters()
    {
        var a = new NormalDistribution<double>(mu: 3, sigmaSquared: 1.5);
        var b = new NormalDistribution<double>(mu: 3, sigmaSquared: 1.5);
        Assert.Equal(a, b);
    }

    [Fact]
    public void Equals_ReturnsFalse_ForDifferentParameters()
    {
        var a = new NormalDistribution<double>(mu: 3, sigmaSquared: 1.5);
        var b = new NormalDistribution<double>(mu: 3, sigmaSquared: 2.0);
        Assert.NotEqual(a, b);
    }

    [Fact]
    public void GetHashCode_IsConsistent_ForEqualInstances()
    {
        var a = new NormalDistribution<double>(mu: 3, sigmaSquared: 1.5);
        var b = new NormalDistribution<double>(mu: 3, sigmaSquared: 1.5);
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }
}

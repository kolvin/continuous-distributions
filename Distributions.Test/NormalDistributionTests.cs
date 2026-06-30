using Distributions;

namespace Distributions.Test;

public class NormalDistributionTests
{
    private readonly NormalDistribution _dist = new(mu: 3, sigmaSquared: 1.5);

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(double.NegativeInfinity)]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenSigmaSquaredIsInvalid(double sigmaSquared)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new NormalDistribution(mu: 0, sigmaSquared: sigmaSquared));
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
}

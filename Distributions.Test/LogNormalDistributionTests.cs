using Distributions;

namespace Distributions.Test;

public class LogNormalDistributionTests
{
    private readonly LogNormalDistribution _dist = new(mu: 3, sigmaSquared: 1.5);

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(double.NegativeInfinity)]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenSigmaSquaredIsInvalid(double sigmaSquared)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new LogNormalDistribution(mu: 0, sigmaSquared: sigmaSquared));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(double.NegativeInfinity)]
    public void Pdf_ThrowsArgumentOutOfRangeException_WhenXIsInvalid(double x)
    {
        var d = new LogNormalDistribution(mu: 0, sigmaSquared: 1);
        Assert.Throws<ArgumentOutOfRangeException>(() => d.Pdf(x));
    }

    [Fact]
    public void Mean_ReturnsExpectedValue()
    {
        Assert.Equal(42.5211, Math.Round(_dist.Mean, 4));
    }

    [Fact]
    public void Variance_ReturnsExpectedValue()
    {
        Assert.Equal(6295.0415, Math.Round(_dist.Variance, 4));
    }

    [Theory]
    [InlineData(1.0, 0.0162)]
    [InlineData(3.6, 0.0338)]
    [InlineData(10.0, 0.0277)]
    public void Pdf_ReturnsExpectedValue(double x, double expected)
    {
        Assert.Equal(expected, Math.Round(_dist.Pdf(x), 4));
    }

    [Fact]
    public void ToString_ReturnsExpectedFormat()
    {
        Assert.Equal("Log-normal(μ=3, σ²=1.5)", _dist.ToString());
    }
}

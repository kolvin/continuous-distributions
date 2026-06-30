using Distributions;

namespace Distributions.Test;

public class LogNormalDistributionTests
{
    private readonly LogNormalDistribution _dist = new(mu: 3, sigmaSquared: 1.5);

    [Fact]
    public void Constructor_ThrowsArgumentException_WhenSigmaSquaredIsZero()
    {
        Assert.Throws<ArgumentException>(() => new LogNormalDistribution(mu: 0, sigmaSquared: 0));
    }

    [Fact]
    public void Constructor_ThrowsArgumentException_WhenSigmaSquaredIsNegative()
    {
        Assert.Throws<ArgumentException>(() => new LogNormalDistribution(mu: 0, sigmaSquared: -1));
    }

    [Fact]
    public void Pdf_ThrowsArgumentException_WhenXIsZero()
    {
        var d = new LogNormalDistribution(mu: 0, sigmaSquared: 1);
        Assert.Throws<ArgumentException>(() => d.Pdf(0));
    }

    [Fact]
    public void Pdf_ThrowsArgumentException_WhenXIsNegative()
    {
        var d = new LogNormalDistribution(mu: 0, sigmaSquared: 1);
        Assert.Throws<ArgumentException>(() => d.Pdf(-1));
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

    [Fact]
    public void Pdf_ReturnsExpectedValue_AtX3Point6()
    {
        Assert.Equal(0.0338, Math.Round(_dist.Pdf(3.6), 4));
    }
}

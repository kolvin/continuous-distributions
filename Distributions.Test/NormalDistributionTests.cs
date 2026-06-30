using Distributions;

namespace Distributions.Test;

public class NormalDistributionTests
{
    private readonly NormalDistribution _dist = new(mu: 3, sigmaSquared: 1.5);

    [Fact]
    public void Constructor_ThrowsArgumentException_WhenSigmaSquaredIsZero()
    {
        Assert.Throws<ArgumentException>(() => new NormalDistribution(mu: 0, sigmaSquared: 0));
    }

    [Fact]
    public void Constructor_ThrowsArgumentException_WhenSigmaSquaredIsNegative()
    {
        Assert.Throws<ArgumentException>(() => new NormalDistribution(mu: 0, sigmaSquared: -1));
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

    [Fact]
    public void Pdf_ReturnsExpectedValue_AtX3Point6()
    {
        Assert.Equal(0.2889, Math.Round(_dist.Pdf(3.6), 4));
    }
}

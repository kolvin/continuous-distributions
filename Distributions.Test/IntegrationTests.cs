using Distributions;

namespace Distributions.Test;

// Exercises both distributions polymorphically through the interface.
public class IntegrationTests
{
    private static readonly IContinuousDistribution[] _distributions =
    [
        new NormalDistribution(mu: 0, sigmaSquared: 1),
        new LogNormalDistribution(mu: 0, sigmaSquared: 1),
    ];

    [Fact]
    public void BothDistributions_ImplementInterface_AndReturnFiniteDoubles()
    {
        foreach (var dist in _distributions)
        {
            Assert.True(double.IsFinite(dist.Mean), $"{dist.GetType().Name}.Mean is not finite");
            Assert.True(double.IsFinite(dist.Variance), $"{dist.GetType().Name}.Variance is not finite");
            Assert.True(double.IsFinite(dist.Pdf(1.0)), $"{dist.GetType().Name}.Pdf(1) is not finite");
        }
    }

    [Fact]
    public void BothDistributions_Pdf_DoesNotThrow_ForValidX()
    {
        foreach (var dist in _distributions)
        {
            var ex = Record.Exception(() => dist.Pdf(2.5));
            Assert.Null(ex);
        }
    }

    [Fact]
    public void BothDistributions_AreAssignableToInterface()
    {
        Assert.IsAssignableFrom<IContinuousDistribution>(new NormalDistribution(1, 1));
        Assert.IsAssignableFrom<IContinuousDistribution>(new LogNormalDistribution(1, 1));
    }
}

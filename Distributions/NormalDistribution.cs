namespace Distributions;

/// <summary>
/// Normal (Gaussian) distribution parameterised by mean μ and variance σ².
/// </summary>
public sealed class NormalDistribution : IContinuousDistribution
{
    // cached so we don't recompute sqrt on every Pdf call
    private readonly double _sigma;

    public NormalDistribution(double mu, double sigmaSquared)
    {
        if (sigmaSquared <= 0)
        {
            throw new ArgumentException("sigmaSquared must be greater than 0.", nameof(sigmaSquared));
        }

        Mean = mu;
        Variance = sigmaSquared;
        _sigma = Math.Sqrt(sigmaSquared);
    }

    /// <inheritdoc/>
    public double Mean { get; }

    /// <inheritdoc/>
    public double Variance { get; }

    /// <inheritdoc/>
    public double Pdf(double x)
    {
        double coefficient = 1.0 / (_sigma * Math.Sqrt(2.0 * Math.PI));
        double exponent = -(Math.Pow(x - Mean, 2) / (2.0 * Variance));
        return coefficient * Math.Exp(exponent);
    }
}

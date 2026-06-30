namespace Distributions;

/// <summary>
/// Log-normal distribution parameterised by μ and σ² of the underlying normal.
/// </summary>
public sealed class LogNormalDistribution : IContinuousDistribution
{
    private readonly double _mu;

    private readonly double _sigmaSquared;

    public LogNormalDistribution(double mu, double sigmaSquared)
    {
        if (sigmaSquared <= 0)
        {
            throw new ArgumentException("sigmaSquared must be greater than 0.", nameof(sigmaSquared));
        }

        _mu = mu;
        _sigmaSquared = sigmaSquared;

        Mean = Math.Exp(mu + (sigmaSquared / 2.0));
        Variance = (Math.Exp(sigmaSquared) - 1.0) * Math.Exp((2.0 * mu) + sigmaSquared);
    }

    /// <inheritdoc/>
    public double Mean { get; }

    /// <inheritdoc/>
    public double Variance { get; }

    /// <inheritdoc/>
    public double Pdf(double x)
    {
        if (x <= 0)
        {
            throw new ArgumentException("x must be greater than 0 for the log-normal PDF.", nameof(x));
        }

        double lnX = Math.Log(x);
        double coefficient = 1.0 / (x * Math.Sqrt(2.0 * Math.PI * _sigmaSquared));
        double exponent = -(Math.Pow(lnX - _mu, 2) / (2.0 * _sigmaSquared));
        return coefficient * Math.Exp(exponent);
    }
}

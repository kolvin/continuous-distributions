namespace Distributions;

/// <summary>Log-normal distribution parameterised by μ and σ² of the underlying normal.</summary>
public sealed class LogNormalDistribution : IContinuousDistribution
{
    private readonly double _mu;

    private readonly double _sigmaSquared;

    /// <summary>Initializes a new instance of the <see cref="LogNormalDistribution"/> class.</summary>
    /// <param name="mu">μ parameter of the underlying normal distribution.</param>
    /// <param name="sigmaSquared">σ² parameter; must be strictly positive.</param>
    public LogNormalDistribution(double mu, double sigmaSquared)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sigmaSquared);

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
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(x);

        double lnX = Math.Log(x);
        double coefficient = 1.0 / (x * Math.Sqrt(Math.Tau * _sigmaSquared));
        double exponent = -(Math.Pow(lnX - _mu, 2) / (2.0 * _sigmaSquared));
        return coefficient * Math.Exp(exponent);
    }

    /// <inheritdoc/>
    public override string ToString() => $"Log-normal(μ={_mu}, σ²={_sigmaSquared})";
}

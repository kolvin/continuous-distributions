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
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sigmaSquared);

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
        double coefficient = 1.0 / (_sigma * Math.Sqrt(Math.Tau));
        double exponent = -(Math.Pow(x - Mean, 2) / (2.0 * Variance));
        return coefficient * Math.Exp(exponent);
    }

    /// <inheritdoc/>
    public override string ToString() => $"Normal(μ={Mean}, σ²={Variance})";
}

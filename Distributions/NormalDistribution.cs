using System.Numerics;

namespace Distributions;

/// <summary>Normal (Gaussian) distribution parameterised by mean μ and variance σ².</summary>
/// <typeparam name="T">The floating-point type used for all values.</typeparam>
public sealed class NormalDistribution<T> : IContinuousDistribution<T>
    where T : IFloatingPointIeee754<T>
{
    // cached so we don't recompute sqrt on every Pdf call
    private readonly T _sigma;

    /// <summary>Initializes a new instance of the <see cref="NormalDistribution{T}"/> class.</summary>
    /// <param name="mu">Mean (μ) of the distribution.</param>
    /// <param name="sigmaSquared">Variance (σ²); must be strictly positive.</param>
    public NormalDistribution(T mu, T sigmaSquared)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sigmaSquared);

        Mean = mu;
        Variance = sigmaSquared;
        _sigma = T.Sqrt(sigmaSquared);
    }

    /// <inheritdoc/>
    public T Mean { get; }

    /// <inheritdoc/>
    public T Variance { get; }

    /// <inheritdoc/>
    public T Pdf(T x)
    {
        T two = T.CreateChecked(2);
        T coefficient = T.One / (_sigma * T.Sqrt(T.Tau));
        T exponent = -((x - Mean) * (x - Mean) / (two * Variance));
        return coefficient * T.Exp(exponent);
    }

    /// <inheritdoc/>
    public override string ToString() => $"Normal(μ={Mean}, σ²={Variance})";
}

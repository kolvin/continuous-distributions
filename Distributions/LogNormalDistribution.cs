using System.Diagnostics;
using System.Numerics;

namespace Distributions;

/// <summary>Log-normal distribution parameterised by μ and σ² of the underlying normal.</summary>
/// <typeparam name="T">The floating-point type used for all values.</typeparam>
[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogNormalDistribution<T> : IContinuousDistribution<T>, IEquatable<LogNormalDistribution<T>>
    where T : IFloatingPointIeee754<T>
{
    private readonly T _mu;

    private readonly T _sigmaSquared;

    /// <summary>Initializes a new instance of the <see cref="LogNormalDistribution{T}"/> class.</summary>
    /// <param name="mu">μ parameter of the underlying normal distribution.</param>
    /// <param name="sigmaSquared">σ² parameter; must be strictly positive.</param>
    public LogNormalDistribution(T mu, T sigmaSquared)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sigmaSquared);

        _mu = mu;
        _sigmaSquared = sigmaSquared;

        T two = T.CreateChecked(2);
        Mean = T.Exp(mu + (sigmaSquared / two));
        Variance = (T.Exp(sigmaSquared) - T.One) * T.Exp((two * mu) + sigmaSquared);
    }

    /// <inheritdoc/>
    public T Mean { get; }

    /// <inheritdoc/>
    public T Variance { get; }

    /// <inheritdoc/>
    public T Pdf(T x)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(x);

        T two = T.CreateChecked(2);
        T lnX = T.Log(x);
        T coefficient = T.One / (x * T.Sqrt(T.Tau * _sigmaSquared));
        T exponent = -((lnX - _mu) * (lnX - _mu) / (two * _sigmaSquared));
        return coefficient * T.Exp(exponent);
    }

    /// <inheritdoc/>
    public bool Equals(LogNormalDistribution<T>? other) =>
        other is not null && _mu == other._mu && _sigmaSquared == other._sigmaSquared;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as LogNormalDistribution<T>);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(_mu, _sigmaSquared);

    /// <inheritdoc/>
    public override string ToString() => $"Log-normal(μ={_mu}, σ²={_sigmaSquared})";
}

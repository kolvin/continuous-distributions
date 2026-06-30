using System.Numerics;

namespace Distributions;

/// <summary>Contract that every continuous probability distribution must satisfy.</summary>
/// <typeparam name="T">The floating-point type used for all values.</typeparam>
public interface IContinuousDistribution<T>
    where T : IFloatingPointIeee754<T>
{
    /// <summary>Gets the expected value of the distribution.</summary>
    T Mean { get; }

    /// <summary>Gets the variance of the distribution.</summary>
    T Variance { get; }

    /// <summary>Returns the probability density at <paramref name="x"/>.</summary>
    /// <param name="x">The point at which to evaluate the density.</param>
    /// <returns>The probability density at <paramref name="x"/>.</returns>
    T Pdf(T x);
}

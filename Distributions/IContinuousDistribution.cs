namespace Distributions;

// Interface here defines the rules for all consuming classes
public interface IContinuousDistribution
{
    /// <summary>Gets the expected value of the distribution.</summary>
    double Mean { get; }

    /// <summary>Gets the variance of the distribution.</summary>
    double Variance { get; }

    /// <summary>Returns the probability density at <paramref name="x"/>.</summary>
    /// <param name="x">The point at which to evaluate the density.</param>
    /// <returns>The probability density at <paramref name="x"/>.</returns>
    double Pdf(double x);
}

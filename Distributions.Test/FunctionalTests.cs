using Distributions;

namespace Distributions.Test;

// Mirrors the console app's output flow in memory, no process spawning needed.
public class FunctionalTests
{
    [Fact]
    public void ConsoleOutput_Normal_MatchesExpectedPattern()
    {
        double mu = 3, s2 = 1.5, x = 3.6;
        var dist = new NormalDistribution<double>(mu, s2);
        string line = FormatLine("Normal", x, mu, s2, dist);

        Assert.StartsWith("Normal(", line, StringComparison.Ordinal);
        Assert.Contains("Mean :", line, StringComparison.Ordinal);
        Assert.Contains("Variance :", line, StringComparison.Ordinal);
    }

    [Fact]
    public void ConsoleOutput_LogNormal_MatchesExpectedPattern()
    {
        double mu = 3, s2 = 1.5, x = 3.6;
        var dist = new LogNormalDistribution<double>(mu, s2);
        string line = FormatLine("Log-normal", x, mu, s2, dist);

        Assert.StartsWith("Log-normal(", line, StringComparison.Ordinal);
        Assert.Contains("Mean :", line, StringComparison.Ordinal);
        Assert.Contains("Variance :", line, StringComparison.Ordinal);
    }

    [Fact]
    public void InvalidSigmaSquared_ProducesArgumentException_NotCrash()
    {
        string errorMessage = string.Empty;
        try
        {
            _ = new NormalDistribution<double>(mu: 1, sigmaSquared: -1);
        }
        catch (ArgumentException ex)
        {
            errorMessage = $"Error: {ex.Message}";
        }

        Assert.StartsWith("Error:", errorMessage, StringComparison.Ordinal);
        Assert.NotEmpty(errorMessage);
    }

    [Fact]
    public void LogNormal_InvalidX_ProducesArgumentException_NotCrash()
    {
        string errorMessage = string.Empty;
        try
        {
            var dist = new LogNormalDistribution<double>(mu: 1, sigmaSquared: 1);
            _ = dist.Pdf(-5);
        }
        catch (ArgumentException ex)
        {
            errorMessage = $"Error: {ex.Message}";
        }

        Assert.StartsWith("Error:", errorMessage, StringComparison.Ordinal);
    }

    [Fact]
    public void BothDistributions_ProduceIndependentOutput_WhenLogNormalFails()
    {
        double mu = 0, s2 = 1, x = -1;
        string normalLine = string.Empty;
        string logNormalError = string.Empty;

        try
        {
            normalLine = FormatLine("Normal", x, mu, s2, new NormalDistribution<double>(mu, s2));
        }
        catch (ArgumentException ex)
        {
            normalLine = $"Error: {ex.Message}";
        }

        try
        {
            logNormalError = FormatLine("Log-normal", x, mu, s2, new LogNormalDistribution<double>(mu, s2));
        }
        catch (ArgumentException ex)
        {
            logNormalError = $"Error: {ex.Message}";
        }

        Assert.StartsWith("Normal(", normalLine, StringComparison.Ordinal);
        Assert.StartsWith("Error:", logNormalError, StringComparison.Ordinal);
    }

    private static string FormatLine(
        string name,
        double x,
        double mu,
        double sigmaSquared,
        IContinuousDistribution<double> dist)
        => $"{name}({x};{mu},{sigmaSquared}) = {dist.Pdf(x)} (Mean : {dist.Mean}, Variance : {dist.Variance})";
}

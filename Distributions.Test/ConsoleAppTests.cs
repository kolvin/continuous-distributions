using System.Diagnostics;

namespace Distributions.Test;

// Spawns the real console binary to test arg parsing, exit codes, and stdout.
public class ConsoleAppTests
{
    [Fact]
    public void ValidArgs_PrintsBothDistributions_AndReturnsZero()
    {
        var (output, exitCode) = Run("3", "1.5", "3.6");
        Assert.Equal(0, exitCode);
        Assert.Contains("Normal(", output, StringComparison.Ordinal);
        Assert.Contains("Log-normal(", output, StringComparison.Ordinal);
    }

    [Fact]
    public void WrongArgCount_PrintsUsage_AndReturnsOne()
    {
        var (output, exitCode) = Run("3", "1.5");
        Assert.Equal(1, exitCode);
        Assert.StartsWith("Usage:", output, StringComparison.Ordinal);
    }

    [Fact]
    public void NonNumericArg_PrintsError_AndReturnsOne()
    {
        var (output, exitCode) = Run("foo", "1.5", "3.6");
        Assert.Equal(1, exitCode);
        Assert.StartsWith("Error:", output, StringComparison.Ordinal);
    }

    [Fact]
    public void NegativeX_LogNormalFails_NormalSucceeds()
    {
        var (output, exitCode) = Run("0", "1", "-1");
        Assert.Equal(0, exitCode);
        Assert.Contains("Normal(", output, StringComparison.Ordinal);
        Assert.Contains("Log-normal: Error", output, StringComparison.Ordinal);
    }

    private static (string Output, int ExitCode) Run(params string[] args)
    {
        string repoRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
        string binary = Path.Combine(repoRoot, "Distributions.Console", "bin", "Debug", "net10.0", "Distributions.Console");

        var psi = new ProcessStartInfo(binary, args)
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
        };

        using var proc = Process.Start(psi)!;
        string output = proc.StandardOutput.ReadToEnd().Trim();
        proc.WaitForExit();
        return (output, proc.ExitCode);
    }
}

using Distributions;

if (args.Length != 3)
{
    Console.WriteLine("Usage: Distributions.Console <mu> <sigmaSquared> <x>");
    return 1;
}

if (!double.TryParse(args[0], out double mu) ||
    !double.TryParse(args[1], out double sigmaSquared) ||
    !double.TryParse(args[2], out double x))
{
    Console.WriteLine("Error: all arguments must be valid numbers.");
    return 1;
}

// each distribution is handled independently so one failure doesn't suppress the other
try
{
    var normal = new NormalDistribution(mu, sigmaSquared);
    Console.WriteLine(
        $"Normal({x};{mu},{sigmaSquared}) = {normal.Pdf(x)} " +
        $"(Mean : {normal.Mean}, Variance : {normal.Variance})");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Normal: Error — {ex.Message}");
}

try
{
    var logNormal = new LogNormalDistribution(mu, sigmaSquared);
    Console.WriteLine(
        $"Log-normal({x};{mu},{sigmaSquared}) = {logNormal.Pdf(x)} " +
        $"(Mean : {logNormal.Mean}, Variance : {logNormal.Variance})");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Log-normal: Error — {ex.Message}");
}

return 0;

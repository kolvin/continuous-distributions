// xUnit convention is Method_Condition_Result, which needs underscores.
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Naming",
    "CA1707:Identifiers should not contain underscores",
    Justification = "xUnit test method naming convention: Method_Condition_Result.")]

// CA1303: CLI app with no localisation requirement — resource tables are not warranted.
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Globalization",
    "CA1303:Do not pass literals as localized parameters",
    Justification = "CLI app with no localisation requirement — resource tables are not warranted.")]

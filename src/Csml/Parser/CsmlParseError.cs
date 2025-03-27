namespace Csml.Parser;

/// <summary>
/// Describes a C♯ML parsing error.
/// </summary>
/// <param name="Descriptor"></param>
/// <param name="LineNumber"></param>
/// <param name="Arguments"></param>
public record CsmlParseError(DiagnosticDescriptor Descriptor, int? LineNumber, params string[] Arguments);

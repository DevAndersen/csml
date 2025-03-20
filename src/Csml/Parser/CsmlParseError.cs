namespace Csml.Parser;

public record CsmlParseError(DiagnosticDescriptor Descriptor, int? LineNumber, params string[] Arguments);

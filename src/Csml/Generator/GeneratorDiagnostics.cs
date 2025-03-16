using Microsoft.CodeAnalysis;

namespace Csml.Generator;

internal static class GeneratorDiagnostics
{
    public static readonly DiagnosticDescriptor HastagFileExtension = new DiagnosticDescriptor(
        id: "CSML0001",
        title: "Hashtag as file extension title",
        messageFormat: "Hashtag as file extension message",
        category: "CSML",
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor ParseError = new DiagnosticDescriptor(
        id: "CSML0002",
        title: "Parse error title",
        messageFormat: "Parse error message",
        category: "CSML",
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);
}

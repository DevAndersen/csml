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
}

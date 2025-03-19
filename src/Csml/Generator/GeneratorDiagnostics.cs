namespace Csml.Generator;

internal static class GeneratorDiagnostics
{
    public const string NotPreferredFileExtensionId = "CSML0001";
    public const string ParseErrorId = "CSML0002";

    public static readonly DiagnosticDescriptor NotPreferredFileExtension = new DiagnosticDescriptor(
        id: NotPreferredFileExtensionId,
        title: "Hashtag as file extension title",
        messageFormat: "Hashtag as file extension message",
        category: "CSML",
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor ParseError = new DiagnosticDescriptor(
        id: ParseErrorId,
        title: "Parse error title",
        messageFormat: "Parse error: {0}",
        category: "CSML",
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);
}

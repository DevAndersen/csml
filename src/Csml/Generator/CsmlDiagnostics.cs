namespace Csml.Generator;

/// <summary>
/// Contains definitions of C♯ML diagnostics.
/// </summary>
internal static class CsmlDiagnostics
{
    private const string _category = "CSML";

    public const string NotPreferredFileExtensionId = "CSML0001";
    public const string ParseErrorId = "CSML0002";
    public const string MissingRequiredPropertyId = "CSML0003";
    public const string XmlParseExceptionId = "CSML0004";
    public const string UnexpectedParseExceptionId = "CSML0005";
    public const string UnexpectedPermutationId = "CSML0006";
    public const string UnexpectedAttributeId = "CSML0007";
    public const string UnexpectedElementId = "CSML0008";
    public const string InvalidAccessorId = "CSML0009";

    public static readonly DiagnosticDescriptor NotPreferredFileExtension = new DiagnosticDescriptor(
        id: NotPreferredFileExtensionId,
        title: "Hashtag as file extension title",
        messageFormat: "Hashtag as file extension message",
        category: _category,
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor ParseError = new DiagnosticDescriptor(
        id: ParseErrorId,
        title: "Parse error title",
        messageFormat: "Parse error: {0}",
        category: _category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor MissingRequiredProperty = new DiagnosticDescriptor(
        id: MissingRequiredPropertyId,
        title: "Missing required property",
        messageFormat: "Required property '{0}' is null",
        category: _category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor XmlParseException = new DiagnosticDescriptor(
        id: XmlParseExceptionId,
        title: "XML parse exception",
        messageFormat: "XML parse exception thrown during parsing, message: {0}",
        category: _category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor UnexpectedParseException = new DiagnosticDescriptor(
        id: UnexpectedParseExceptionId,
        title: "Unexpected parse exception",
        messageFormat: "Unexpected {0} thrown during parsing, message: {1}",
        category: _category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor UnexpectedPermutation = new DiagnosticDescriptor(
        id: UnexpectedPermutationId,
        title: "Unexpected permutation",
        messageFormat: "Unexpected permutation '{0}' of '{1}'",
        category: _category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor UnexpectedAttribute = new DiagnosticDescriptor(
        id: UnexpectedAttributeId,
        title: "Unexpected attribute",
        messageFormat: "Unexpected attribute '{0}'",
        category: _category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor UnexpectedElement = new DiagnosticDescriptor(
        id: UnexpectedElementId,
        title: "Unexpected element",
        messageFormat: "Unexpected element '{0}'",
        category: _category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor InvalidAccessor = new DiagnosticDescriptor(
        id: InvalidAccessorId,
        title: "Invalid accessor",
        messageFormat: "'{0}' is not a valid access modifier for {1}",
        category: _category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);
}

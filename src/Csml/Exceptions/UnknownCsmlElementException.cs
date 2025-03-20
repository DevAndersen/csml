
namespace Csml.Exceptions;

public class UnknownCsmlElementException : CsmlParseException
{
    public UnknownCsmlElementException(DiagnosticDescriptor Descriptor, int? LineNumber, string ElementName)
        : base(CsmlDiagnostics.UnexpectedElement, LineNumber, [ElementName])
    {
    }
}

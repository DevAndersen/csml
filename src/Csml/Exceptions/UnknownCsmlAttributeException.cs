
namespace Csml.Exceptions;

public class UnknownCsmlAttributeException : CsmlParseException
{
    public UnknownCsmlAttributeException(DiagnosticDescriptor Descriptor, int? LineNumber, string AttributeName)
        : base(CsmlDiagnostics.UnexpectedAttribute, LineNumber, [AttributeName])
    {
    }
}

namespace Csml.Exceptions;

public class UnknownCsmlElementException : CsmlParseException
{
    public UnknownCsmlElementException(int? LineNumber, string ElementName)
        : base(CsmlDiagnostics.UnexpectedElement, LineNumber, [ElementName])
    {
    }
}

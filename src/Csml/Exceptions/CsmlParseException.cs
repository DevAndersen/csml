using Csml.Parser;

namespace Csml.Exceptions;

public class CsmlParseException : Exception
{
    public CsmlParseError ParseError { get; }

    public CsmlParseException(DiagnosticDescriptor Descriptor, int? LineNumber, string[] Arguments)
    {
        ParseError = new CsmlParseError(Descriptor, LineNumber, Arguments);
    }
}

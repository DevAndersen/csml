namespace Csml.Exceptions;

public class UnexpectedCsmlPermutationException : CsmlParseException
{
    public UnexpectedCsmlPermutationException(int? LineNumber, string unexpectedTypeName, string baseTypeName)
        : base(CsmlDiagnostics.UnexpectedPermutation, LineNumber, [unexpectedTypeName, baseTypeName])
    {
    }
}

namespace Csml.Parser;

/// <summary>
/// DTO which contains the C♯ML parse result, as well as any potential errors.
/// </summary>
/// <param name="Result"></param>
/// <param name="Errors"></param>
public record CsmlParseResult(CsmlNode? Result, List<CsmlParseError> Errors);

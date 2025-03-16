using Csml.Parser.Nodes;

namespace Csml.Parser;

public record CsmlParseResult(CsmlNode? Result, IEnumerable<CsmlParseError>? Errors);

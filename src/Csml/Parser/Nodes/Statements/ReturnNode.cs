namespace Csml.Parser.Nodes.Statements;

/// <summary>
/// Represents a <c>return</c> statement.
/// </summary>
public class ReturnNode : BaseNode
{
    [XmlAttribute("Value")]
    public string? Value { get; init; }
}

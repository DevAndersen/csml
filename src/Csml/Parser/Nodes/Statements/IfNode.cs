namespace Csml.Parser.Nodes.Statements;

/// <summary>
/// Represents an <c>if</c> statement.
/// </summary>
public class IfNode : BaseNode
{
    [XmlElement("Expression")]
    public required ExpressionStatementNode Expression { get; init; }

    [XmlElement("Statements")]
    public required BlockNode Statements { get; init; }
}

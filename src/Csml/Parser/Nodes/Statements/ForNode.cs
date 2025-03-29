namespace Csml.Parser.Nodes.Statements;

/// <summary>
/// Represents a <c>for</c> statement.
/// </summary>
public class ForNode : BaseNode
{
    [XmlElement("Variable", typeof(VariableNode))]
    public required VariableNode Variable { get; init; }

    [XmlElement("Condition", typeof(ExpressionStatementNode))]
    public required ExpressionStatementNode Condition { get; init; }

    [XmlElement("Iterator", typeof(ExpressionStatementNode))]
    public required ExpressionStatementNode Iterator { get; init; }

    [XmlElement("Statements")]
    public required BlockNode Statements { get; init; }
}

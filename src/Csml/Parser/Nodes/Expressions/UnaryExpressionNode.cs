namespace Csml.Parser.Nodes.Expressions;

public abstract class UnaryExpressionNode : ExpressionNode
{
    [XmlElement("Expression")]
    public required ExpressionStatementNode Expression { get; init; }
}

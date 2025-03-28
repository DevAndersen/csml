namespace Csml.Parser.Nodes.Expressions;

public abstract class UnaryExpressionNode : ExpressionNode
{
    [XmlAttribute("Target")]
    public required string Target { get; init; }
}

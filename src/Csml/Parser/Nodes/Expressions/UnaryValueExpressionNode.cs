namespace Csml.Parser.Nodes.Expressions;

public abstract class UnaryValueExpressionNode : ExpressionNode
{
    [XmlAttribute("Target")]
    public required string Target { get; init; }
}

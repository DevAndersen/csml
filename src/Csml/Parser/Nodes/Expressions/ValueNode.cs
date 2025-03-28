namespace Csml.Parser.Nodes.Expressions;

public class ValueNode : ExpressionNode
{
    [XmlAttribute("Value")]
    public required string Value { get; init; }
}

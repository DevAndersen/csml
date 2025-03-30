namespace Csml.Parser.Nodes.Expressions;

public class AwaitNode : ExpressionNode
{
    [XmlElement("Expression")]
    public required ExpressionStatementNode Expression { get; init; }
}

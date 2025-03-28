namespace Csml.Parser.Nodes.Expressions;

public abstract class BinaryExpressionNode : ExpressionNode
{
    [XmlElement("Left")]
    public required ExpressionStatementNode Left { get; init; }

    [XmlElement("Right")]
    public required ExpressionStatementNode Right { get; init; }
}

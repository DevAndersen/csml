namespace Csml.Parser.Nodes.Statements;

public class WhileNode : BaseNode
{
    [XmlElement("Condition", typeof(ExpressionStatementNode))]
    public required ExpressionStatementNode Condition { get; init; }

    [XmlElement("Statements")]
    public required BlockNode Statements { get; init; }
}

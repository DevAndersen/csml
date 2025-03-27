namespace Csml.Parser.Nodes.Statements;

public abstract class StatementContainerNode : BaseNode
{
    [XmlElement("Return", typeof(ReturnNode))]
    [XmlElement("Variable", typeof(VariableNode))]
    [XmlElement("Call", typeof(CallNode))]
    [XmlElement("Break", typeof(BreakNode))]
    [XmlElement("Continue", typeof(ContinueNode))]
    [XmlElement("If", typeof(IfNode))]
    [XmlElement("ElseIf", typeof(ElseIfNode))]
    [XmlElement("Else", typeof(ElseNode))]
    public BaseNode[]? Statements { get; init; }
}

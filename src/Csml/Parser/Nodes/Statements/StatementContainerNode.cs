namespace Csml.Parser.Nodes.Statements;

/// <summary>
/// Base class representing a node that can contain statements as child nodes.
/// </summary>
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
    [XmlElement("ForEach", typeof(ForEachNode))]
    public BaseNode[]? Statements { get; init; }
}

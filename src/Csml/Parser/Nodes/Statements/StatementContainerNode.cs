using Csml.Parser.Nodes.Expressions;

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
    [XmlElement("For", typeof(ForNode))]
    [XmlElement("ForEach", typeof(ForEachNode))]
    [XmlElement("Increment", typeof(IncrementNode))]
    [XmlElement("Decrement", typeof(DecrementNode))]
    public BaseNode[]? Statements { get; init; }
}

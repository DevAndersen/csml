using Csml.Parser.Nodes.Expressions;

namespace Csml.Parser.Nodes.Statements;

/// <summary>
/// Base class representing a node that can contain statements as child nodes.
/// </summary>
public abstract class StatementContainerNode : BaseNode
{
    [XmlElement("Assignment", typeof(AssignmentNode))]
    [XmlElement("Await", typeof(AwaitNode))]
    [XmlElement("Break", typeof(BreakNode))]
    [XmlElement("Call", typeof(CallNode))]
    [XmlElement("Catch", typeof(CatchNode))]
    [XmlElement("Continue", typeof(ContinueNode))]
    [XmlElement("Decrement", typeof(DecrementNode))]
    [XmlElement("Else", typeof(ElseNode))]
    [XmlElement("ElseIf", typeof(ElseIfNode))]
    [XmlElement("For", typeof(ForNode))]
    [XmlElement("ForEach", typeof(ForEachNode))]
    [XmlElement("Finally", typeof(FinallyNode))]
    [XmlElement("If", typeof(IfNode))]
    [XmlElement("Increment", typeof(IncrementNode))]
    [XmlElement("New", typeof(NewNode))]
    [XmlElement("PrefixDecrement", typeof(PrefixDecrementNode))]
    [XmlElement("PrefixIncrement", typeof(PrefixIncrementNode))]
    [XmlElement("Return", typeof(ReturnNode))]
    [XmlElement("Throw", typeof(ThrowNode))]
    [XmlElement("Try", typeof(TryNode))]
    [XmlElement("Variable", typeof(VariableNode))]
    [XmlElement("Switch", typeof(SwitchNode))]
    [XmlElement("While", typeof(WhileNode))]
    public BaseNode[]? Statements { get; init; }
}

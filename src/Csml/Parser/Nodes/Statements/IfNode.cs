using Csml.Parser.Nodes.Expressions;

namespace Csml.Parser.Nodes.Statements;

/// <summary>
/// Represents an <c>if</c> statement.
/// </summary>
public class IfNode : BaseNode
{
    [XmlElement("Expression")]
    public required ExpressionStatementNode Expression { get; init; }

    [XmlElement("Statements")]
    public required BlockNode Statements { get; init; }
}

public class ExpressionStatementNode : BaseNode
{
    [XmlElement("Equals", typeof(EqualsNode))]
    [XmlElement("NotEquals", typeof(NotEqualsNode))]
    [XmlElement("LessThan", typeof(LessThanNode))]
    [XmlElement("LessThanOrEqual", typeof(LessThanOrEqualNode))]
    [XmlElement("GreaterThan", typeof(GreaterThanNode))]
    [XmlElement("GreaterThanOrEqual", typeof(GreaterThanOrEqualNode))]
    [XmlElement("Value", typeof(ValueNode))]
    [XmlElement("Increment", typeof(IncrementNode))]
    [XmlElement("PrefixIncrement", typeof(PrefixIncrementNode))]
    [XmlElement("Decrement", typeof(DecrementNode))]
    [XmlElement("Assignment", typeof(AssignmentNode))]
    [XmlElement("Add", typeof(AddNode))]
    [XmlElement("Subtract", typeof(SubtractNode))]
    [XmlElement("Multiply", typeof(MultiplyNode))]
    [XmlElement("Divide", typeof(DivideNode))]
    [XmlElement("Remainder", typeof(RemainderNode))]
    [XmlElement("Call", typeof(CallNode))]
    public required ExpressionNode Expression { get; init; }
}

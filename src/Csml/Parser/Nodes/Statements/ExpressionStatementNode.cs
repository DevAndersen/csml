using Csml.Parser.Nodes.Expressions;

namespace Csml.Parser.Nodes.Statements;

public class ExpressionStatementNode : BaseNode
{
    [XmlElement("Add", typeof(AddNode))]
    [XmlElement("And", typeof(AndNode))]
    [XmlElement("Assignment", typeof(AssignmentNode))]
    [XmlElement("Await", typeof(AwaitNode))]
    [XmlElement("BitwiseAnd", typeof(BitwiseAndNode))]
    [XmlElement("BitwiseNot", typeof(BitwiseNotNode))]
    [XmlElement("BitwiseOr", typeof(BitwiseOrNode))]
    [XmlElement("Call", typeof(CallNode))]
    [XmlElement("Decrement", typeof(DecrementNode))]
    [XmlElement("Divide", typeof(DivideNode))]
    [XmlElement("Equals", typeof(EqualsNode))]
    [XmlElement("GreaterThan", typeof(GreaterThanNode))]
    [XmlElement("GreaterThanOrEqual", typeof(GreaterThanOrEqualNode))]
    [XmlElement("Increment", typeof(IncrementNode))]
    [XmlElement("LeftShift", typeof(LeftShiftNode))]
    [XmlElement("LessThan", typeof(LessThanNode))]
    [XmlElement("LessThanOrEqual", typeof(LessThanOrEqualNode))]
    [XmlElement("Multiply", typeof(MultiplyNode))]
    [XmlElement("New", typeof(NewNode))]
    [XmlElement("Not", typeof(NotNode))]
    [XmlElement("NotEquals", typeof(NotEqualsNode))]
    [XmlElement("Or", typeof(OrNode))]
    [XmlElement("PrefixDecrement", typeof(PrefixDecrementNode))]
    [XmlElement("PrefixIncrement", typeof(PrefixIncrementNode))]
    [XmlElement("Remainder", typeof(RemainderNode))]
    [XmlElement("RightShift", typeof(RightShiftNode))]
    [XmlElement("Subtract", typeof(SubtractNode))]
    [XmlElement("UnsignedRightShift", typeof(UnsignedRightShiftNode))]
    [XmlElement("Value", typeof(ValueNode))]
    [XmlElement("Xor", typeof(XorNode))]
    public required ExpressionNode Expression { get; init; }
}

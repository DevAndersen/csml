using Csml.Parser.Nodes.Expressions;

namespace Csml.Parser.Nodes.Statements;

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
    [XmlElement("And", typeof(AndNode))]
    [XmlElement("BitwiseAnd", typeof(BitwiseAndNode))]
    [XmlElement("BitwiseOr", typeof(BitwiseOrNode))]
    [XmlElement("LeftShift", typeof(LeftShiftNode))]
    [XmlElement("Or", typeof(OrNode))]
    [XmlElement("RightShift", typeof(RightShiftNode))]
    [XmlElement("UnsignedRightShift", typeof(UnsignedRightShiftNode))]
    [XmlElement("Xor", typeof(XorNode))]
    public required ExpressionNode Expression { get; init; }
}

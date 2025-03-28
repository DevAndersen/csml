using Csml.Parser.Nodes.Expressions;

namespace Csml.Parser.Nodes.Members;

/// <summary>
/// Represents a method.
/// </summary>
public class MethodNode : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Access")]
    public AccessModifier Access { get; init; }

    [XmlAttribute("Return")]
    public required string Return { get; init; }

    [XmlAttribute("Static")]
    public bool Static { get; init; }

    [XmlAttribute("Async")]
    public bool Async { get; init; }

    [XmlAttribute("Abstract")]
    public bool Abstract { get; init; }

    [XmlAttribute("Virtual")]
    public bool Virtual { get; init; }

    [XmlAttribute("Override")]
    public bool Override { get; init; }

    [XmlElement("Return", typeof(ReturnNode))]
    [XmlElement("Variable", typeof(VariableNode))]
    [XmlElement("Call", typeof(CallNode))]
    [XmlElement("Break", typeof(BreakNode))]
    [XmlElement("Continue", typeof(ContinueNode))]
    [XmlElement("If", typeof(IfNode))]
    [XmlElement("ElseIf", typeof(ElseIfNode))]
    [XmlElement("Else", typeof(ElseNode))]
    [XmlElement("ForEach", typeof(ForEachNode))]
    [XmlElement("Increment", typeof(IncrementNode))]
    [XmlElement("Decrement", typeof(DecrementNode))]
    public BaseNode[]? Statements { get; init; }
}

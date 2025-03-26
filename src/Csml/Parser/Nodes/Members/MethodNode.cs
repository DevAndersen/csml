using Csml.Parser.Nodes.Statements;

namespace Csml.Parser.Nodes.Members;

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

    [XmlElement("Return", typeof(ReturnNode))]
    [XmlElement("Variable", typeof(VariableNode))]
    [XmlElement("Call", typeof(CallNode))]
    public BaseNode[]? Statements { get; init; }
}

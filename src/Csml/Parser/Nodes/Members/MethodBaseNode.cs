namespace Csml.Parser.Nodes.Members;

public abstract class MethodBaseNode : BaseNode
{
    [XmlAttribute("Access")]
    public AccessModifier Access { get; init; }

    [XmlAttribute("Static")]
    public bool Static { get; init; }

    [XmlElement("Parameter")]
    public ParameterNode[]? Parameters { get; init; }

    [XmlElement("Statements")]
    public BlockNode? Statements { get; init; }
}

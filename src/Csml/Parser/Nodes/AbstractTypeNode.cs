namespace Csml.Parser.Nodes;

public abstract class AbstractTypeNode : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Access")]
    public string? Access { get; init; }

    [XmlElement("Field", typeof(FieldNode))]
    [XmlElement("Property", typeof(PropertyNode))]
    public AbstractMemberNode[]? Members { get; init; }
}

namespace Csml.Parser.Nodes;

public abstract class TypeNode : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Access")]
    public AccessModifier Access { get; init; }

    [XmlElement("Field", typeof(FieldNode))]
    [XmlElement("Property", typeof(PropertyNode))]
    public AbstractMemberNode[]? Members { get; init; }
}

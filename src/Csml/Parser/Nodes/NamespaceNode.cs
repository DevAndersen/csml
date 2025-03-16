namespace Csml.Parser.Nodes;

public class NamespaceNode : BaseNode
{
    [XmlElement("Class", typeof(ClassNode))]
    [XmlElement("Struct", typeof(StructNode))]
    [XmlElement("Interface", typeof(InterfaceNode))]
    public AbstractTypeNode[]? Types { get; init; }

    [XmlAttribute("Name")]
    public required string Name { get; init; }
}

namespace Csml.Parser.Nodes.Types;

public class NamespaceNode : BaseNode
{
    [XmlElement("Class", typeof(ClassNode))]
    [XmlElement("Struct", typeof(StructNode))]
    [XmlElement("Interface", typeof(InterfaceNode))]
    public TypeNode[]? Types { get; init; }

    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlElement("UsingDirective")]
    public UsingDirectiveNode[]? UsingDirectives { get; init; }

    [XmlElement("Namespace")]
    public NamespaceNode[]? Namespaces { get; init; }

    [XmlElement("Enum", typeof(EnumNode))]
    public EnumNode[]? Enums { get; init; }
}

using Csml.Parser.Nodes.Members;

namespace Csml.Parser.Nodes.Types;

public abstract class TypeNode : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Access")]
    public AccessModifier Access { get; init; }

    [XmlElement("Field", typeof(FieldNode))]
    [XmlElement("Property", typeof(PropertyNode))]
    public MemberNode[]? Members { get; init; }

    [XmlElement("Class", typeof(ClassNode))]
    [XmlElement("Struct", typeof(StructNode))]
    [XmlElement("Interface", typeof(InterfaceNode))]
    public TypeNode[]? Types { get; init; }

    [XmlElement("Enum", typeof(EnumNode))]
    public EnumNode[]? Enums { get; init; }

    [XmlElement("Method")]
    public MethodNode[]? Methods { get; init; }
}

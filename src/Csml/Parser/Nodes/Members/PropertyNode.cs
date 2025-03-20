namespace Csml.Parser.Nodes.Members;

[XmlType("Property")]
public class PropertyNode : MemberNode
{
    [XmlAttribute("Getter")]
    public PropertyGetterAccessor Getter { get; init; }

    [XmlAttribute("Setter")]
    public PropertySetterAccessor Setter { get; init; }

    [XmlAttribute("GetterAccess")]
    public AccessModifier GetterAccess { get; init; }

    [XmlAttribute("SetterAccess")]
    public AccessModifier SetterAccess { get; init; }
}

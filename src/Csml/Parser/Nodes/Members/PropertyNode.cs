namespace Csml.Parser.Nodes.Members;

[XmlType("Property")]
public class PropertyNode : MemberNode
{
    [XmlAttribute("Accessors")]
    public required PropertyAccessor Accessors { get; init; }
}

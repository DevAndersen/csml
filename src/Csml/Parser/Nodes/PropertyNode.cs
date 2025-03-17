namespace Csml.Parser.Nodes;

[XmlType("Property")]
public class PropertyNode : AbstractMemberNode
{
    [XmlAttribute("Accessors")]
    public required PropertyAccessor Accessors { get; init; }
}

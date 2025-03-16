namespace Csml.Parser.Nodes;

[XmlType("Property")]
public class PropertyNode : AbstractMemberNode
{
    [XmlAttribute("Accessors")]
    public required string Accessors { get; init; }
}

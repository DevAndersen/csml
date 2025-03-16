namespace Csml.Parser.Nodes;

[XmlType("Property")]
public class PropertyNode : AbstractMemberNode
{
    [XmlAttribute("Accessors")]
    public string? Accessors { get; init; }
}

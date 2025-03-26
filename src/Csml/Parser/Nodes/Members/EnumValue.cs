namespace Csml.Parser.Nodes.Members;

[XmlType("EnumValue")]
public class EnumValue : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Value")]
    public string? Value { get; init; }
}

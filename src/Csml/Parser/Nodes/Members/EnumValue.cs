namespace Csml.Parser.Nodes.Members;

/// <summary>
/// Represents a value of an <c>enum</c>.
/// </summary>
[XmlType("EnumValue")]
public class EnumValue : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Value")]
    public string? Value { get; init; }
}

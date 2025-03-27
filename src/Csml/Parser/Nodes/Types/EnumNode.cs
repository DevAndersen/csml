namespace Csml.Parser.Nodes.Types;

/// <summary>
/// Represents an <c>enum</c> declaration.
/// </summary>
[XmlType("Enum")]
public class EnumNode : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Access")]
    public AccessModifier Access { get; init; }

    [XmlElement("EnumValue")]
    public EnumValue[]? Values { get; init; }
}

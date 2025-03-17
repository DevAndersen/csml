namespace Csml.Parser.Nodes.Members;

public abstract class AbstractMemberNode : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Type")]
    public required string Type { get; init; }

    [XmlAttribute("Value")]
    public string? Value { get; init; }

    [XmlAttribute("Access")]
    public AccessModifier Access { get; init; }
}

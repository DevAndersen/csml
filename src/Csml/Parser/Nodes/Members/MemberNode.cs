namespace Csml.Parser.Nodes.Members;

/// <summary>
/// Base class representing an type member.
/// </summary>
public abstract class MemberNode : BaseNode
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

namespace Csml.Parser.Nodes;

public abstract class AbstractMemberNode : BaseNode
{
    [XmlAttribute("Name")]
    public string? Name { get; init; }

    [XmlAttribute("Type")]
    public string? Type { get; init; }

    [XmlAttribute("Value")]
    public string? Value { get; init; }
}

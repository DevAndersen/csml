namespace Csml.Parser.Nodes.Members;

public class ParameterNode : BaseNode
{
    [XmlAttribute("Type")]
    public required string Type { get; init; }

    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Default")]
    public string? Default { get; init; }

    [XmlAttribute("Modifier")]
    public ParameterModifier Modifier { get; init; }
}

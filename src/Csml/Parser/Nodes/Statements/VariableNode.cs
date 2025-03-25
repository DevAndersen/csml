namespace Csml.Parser.Nodes.Statements;

public class VariableNode : BaseNode
{
    [XmlAttribute("Const")]
    public bool Const { get; init; }

    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Type")]
    public required string Type { get; init; }

    [XmlAttribute("Value")]
    public string? Value { get; init; }
}

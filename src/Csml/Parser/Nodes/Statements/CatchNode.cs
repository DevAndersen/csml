namespace Csml.Parser.Nodes.Statements;

public class CatchNode : BaseNode
{
    [XmlAttribute("Type")]
    public string? Type { get; init; }

    [XmlAttribute("Name")]
    public string? Name { get; init; }

    [XmlElement("Statements")]
    public required BlockNode Statements { get; init; }
}

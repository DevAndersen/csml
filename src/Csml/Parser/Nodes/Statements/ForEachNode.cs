namespace Csml.Parser.Nodes.Statements;

public class ForEachNode : StatementContainerNode
{
    [XmlAttribute("Type")]
    public required string Type { get; init; }

    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Collection")]
    public required string Collection { get; init; }
}

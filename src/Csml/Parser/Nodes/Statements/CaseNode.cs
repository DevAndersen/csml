namespace Csml.Parser.Nodes.Statements;

public class CaseNode : StatementContainerNode
{
    [XmlAttribute("Value")]
    public required string Value { get; init; }
}

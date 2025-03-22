namespace Csml.Parser.Nodes.Statements;

public class ReturnNode : BaseNode
{
    [XmlAttribute("Value")]
    public string? Value { get; init; }
}

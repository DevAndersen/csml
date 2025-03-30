namespace Csml.Parser.Nodes.Statements;

public class SwitchNode : BaseNode
{
    [XmlAttribute("Value")]
    public required string Value { get; init; }

    [XmlElement("Case", typeof(CaseNode))]
    [XmlElement("Default", typeof(DefaultNode))]
    public StatementContainerNode[]? Cases { get; init; }
}

namespace Csml.Parser.Nodes.Members;

public class ArgumentNode : BaseNode
{
    [XmlAttribute("Value")]
    public required string Value { get; init; }
}

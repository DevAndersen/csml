namespace Csml.Parser.Nodes;

public class UsingDirectiveNode : BaseNode
{
    [XmlAttribute("Namespace")]
    public required string Namespace { get; init; }
}

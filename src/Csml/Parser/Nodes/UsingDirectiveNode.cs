namespace Csml.Parser.Nodes;

public class UsingDirectiveNode : BaseNode
{
    [XmlAttribute("Namespace")]
    public string? Namespace { get; init; }
}

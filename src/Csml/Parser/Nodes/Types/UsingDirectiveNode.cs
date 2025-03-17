namespace Csml.Parser.Nodes.Types;

public class UsingDirectiveNode : BaseNode
{
    [XmlAttribute("Namespace")]
    public required string Namespace { get; init; }
}

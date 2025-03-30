namespace Csml.Parser.Nodes.Types;

public class InheritanceNode : BaseNode
{
    [XmlAttribute("Type")]
    public required string Type { get; set; }
}

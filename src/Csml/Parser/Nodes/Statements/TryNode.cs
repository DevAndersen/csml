namespace Csml.Parser.Nodes.Statements;

public class TryNode : BaseNode
{
    [XmlElement("Statements")]
    public required BlockNode Statements { get; init; }
}

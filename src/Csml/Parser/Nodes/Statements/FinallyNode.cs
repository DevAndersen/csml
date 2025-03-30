namespace Csml.Parser.Nodes.Statements;

public class FinallyNode : BaseNode
{
    [XmlElement("Statements")]
    public required BlockNode Statements { get; init; }
}

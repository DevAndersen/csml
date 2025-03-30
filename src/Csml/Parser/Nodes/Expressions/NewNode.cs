namespace Csml.Parser.Nodes.Expressions;

public class NewNode : ExpressionNode
{
    [XmlAttribute("Type")]
    public required string Type { get; init; }

    [XmlElement("Argument")]
    public ArgumentNode[]? Arguments { get; init; }
}

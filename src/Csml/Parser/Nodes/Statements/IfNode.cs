namespace Csml.Parser.Nodes.Statements;

public class IfNode : StatementContainerNode
{
    [XmlAttribute("Left")]
    public required string Left { get; init; }

    [XmlAttribute("Comparison")]
    public required ComparisonOperator Comparison { get; init; }

    [XmlAttribute("Right")]
    public required string Right { get; init; }
}

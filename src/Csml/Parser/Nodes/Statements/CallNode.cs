using Csml.Parser.Nodes.Expressions;

namespace Csml.Parser.Nodes.Statements;

/// <summary>
/// Represents a method invocation statement.
/// </summary>
public class CallNode : ExpressionNode
{
    [XmlAttribute("Target")]
    public string? Target { get; init; }

    [XmlAttribute("Method")]
    public required string Method { get; init; }

    [XmlElement("Argument")]
    public ArgumentNode[]? Arguments { get; init; }
}

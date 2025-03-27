using Csml.Parser.Nodes.Members;

namespace Csml.Parser.Nodes.Statements;

/// <summary>
/// Represents a method invocation statement.
/// </summary>
public class CallNode : BaseNode
{
    [XmlAttribute("Target")]
    public required string Target { get; init; }

    [XmlAttribute("Method")]
    public required string Method { get; init; }

    [XmlElement("Argument")]
    public ArgumentNode[]? Arguments { get; init; }
}

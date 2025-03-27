namespace Csml.Parser.Nodes.Members;

/// <summary>
/// Represents an argument provided to a method invocation.
/// </summary>
public class ArgumentNode : BaseNode
{
    [XmlAttribute("Value")]
    public required string Value { get; init; }
}

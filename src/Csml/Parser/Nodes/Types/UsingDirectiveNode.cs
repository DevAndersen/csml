namespace Csml.Parser.Nodes.Types;

/// <summary>
/// Represents a <c>using</c> directive.
/// </summary>
public class UsingDirectiveNode : BaseNode
{
    [XmlAttribute("Namespace")]
    public required string Namespace { get; init; }
}

namespace Csml.Parser.Nodes.Members;

/// <summary>
/// Represents a method.
/// </summary>
public class MethodNode : MethodBaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Return")]
    public required string Return { get; init; }

    [XmlAttribute("Async")]
    public bool Async { get; init; }

    [XmlAttribute("Abstract")]
    public bool Abstract { get; init; }

    [XmlAttribute("Virtual")]
    public bool Virtual { get; init; }

    [XmlAttribute("Override")]
    public bool Override { get; init; }
}

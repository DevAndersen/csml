namespace Csml.Parser.Nodes.Types;

/// <summary>
/// Represents a <c>class</c> declaration.
/// </summary>
[XmlType("Class")]
public class ClassNode : TypeNode
{
    [XmlAttribute("Static")]
    public bool Static { get; init; }
}

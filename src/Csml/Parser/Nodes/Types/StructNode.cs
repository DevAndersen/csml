namespace Csml.Parser.Nodes.Types;

/// <summary>
/// Represents a <c>struct</c> declaration.
/// </summary>
[XmlType("Struct")]
public class StructNode : TypeNode
{
    [XmlAttribute("ReadOnly")]
    public bool ReadOnly { get; set; }

    [XmlAttribute("Ref")]
    public bool Ref { get; set; }
}

namespace Csml.Parser.Nodes.Types;

[XmlType("Struct")]
public class StructNode : TypeNode
{
    [XmlAttribute("ReadOnly")]
    public bool ReadOnly { get; set; }

    [XmlAttribute("Ref")]
    public bool Ref { get; set; }
}

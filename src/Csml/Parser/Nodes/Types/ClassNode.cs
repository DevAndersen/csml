namespace Csml.Parser.Nodes.Types;

[XmlType("Class")]
public class ClassNode : TypeNode
{
    [XmlAttribute("Static")]
    public bool Static { get; init; }
}

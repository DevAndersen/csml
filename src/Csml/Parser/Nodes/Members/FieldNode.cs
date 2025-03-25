namespace Csml.Parser.Nodes.Members;

[XmlType("Field")]
public class FieldNode : MemberNode
{
    [XmlAttribute("Const")]
    public bool Const { get; set; }

    [XmlAttribute("ReadOnly")]
    public bool ReadOnly { get; set; }

    [XmlAttribute("Ref")]
    public bool Ref { get; set; }

    [XmlAttribute("Static")]
    public bool Static { get; set; }
}

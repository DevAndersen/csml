using Csml.Parser.Nodes.Types;

namespace Csml.Parser.Nodes;

[XmlRoot(ElementName = "Csml", IsNullable = false)]
public class CsmlNode : BaseNode
{
    [XmlElement("UsingDirective")]
    public UsingDirectiveNode[]? UsingDirectives { get; init; }

    [XmlElement("Namespace")]
    public NamespaceNode[]? Namespaces { get; init; }
}

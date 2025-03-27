namespace Csml.Parser.Nodes;

/// <summary>
/// The root node of a C♯ML source file.
/// </summary>
[XmlRoot(ElementName = "Csml", IsNullable = false)]
public class CsmlNode : BaseNode
{
    [XmlElement("UsingDirective")]
    public UsingDirectiveNode[]? UsingDirectives { get; init; }

    [XmlElement("Namespace")]
    public NamespaceNode[]? Namespaces { get; init; }
}

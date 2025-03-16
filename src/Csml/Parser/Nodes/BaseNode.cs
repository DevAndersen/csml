namespace Csml.Parser.Nodes;

public abstract class BaseNode
{
    [XmlAttribute(CsmlConstants.LineNumberMetadataAttribute)]
    public int LineNumber { get; init; }
}

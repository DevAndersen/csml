namespace Csml.Parser.Nodes;

/// <summary>
/// The base CSML node type which all other node types inherit from.
/// </summary>
public abstract class BaseNode
{
    [XmlAttribute(CsmlConstants.LineNumberMetadataAttribute)]
    public int LineNumber { get; init; }
}

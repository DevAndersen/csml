namespace Csml.Parser.Nodes;

/// <summary>
/// The base CSML node type which all other node types inherit from.
/// </summary>
public abstract class BaseNode
{
    /// <summary>
    /// Metadata field specifying the line number corresponding to the current node.
    /// Used to allow diagnostics to specify a concrete line number.
    /// </summary>
    [XmlAttribute(CsmlConstants.LineNumberMetadataAttribute)]
    public int LineNumber { get; init; }
}

namespace Csml.Parser.Nodes.Members;

/// <summary>
/// Defines the valid values of a property setter.
/// </summary>
public enum PropertySetterAccessor
{
    Unset,

    [XmlEnum("Set")]
    Set,

    [XmlEnum("Init")]
    Init
}

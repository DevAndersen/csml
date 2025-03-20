namespace Csml.Parser.Nodes.Members;

public enum PropertySetterAccessor
{
    Unset,

    [XmlEnum("Set")]
    Set,

    [XmlEnum("Init")]
    Init
}

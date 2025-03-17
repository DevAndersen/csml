namespace Csml.Parser.Nodes;

public enum PropertyAccessor
{
    Unset,

    [XmlEnum("GetSet")]
    GetSet,

    [XmlEnum("Get")]
    Get,

    [XmlEnum("GetInit")]
    GetInit
}

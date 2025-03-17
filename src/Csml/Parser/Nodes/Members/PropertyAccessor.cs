namespace Csml.Parser.Nodes.Members;

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

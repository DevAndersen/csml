namespace Csml.Parser.Nodes;

public enum AccessModifier
{
    [XmlEnum("Public")]
    Public,

    [XmlEnum("Private")]
    Private,

    [XmlEnum("Protected")]
    Protected,

    [XmlEnum("Internal")]
    Internal,

    [XmlEnum("ProtectedInternal")]
    ProtectedInternal,

    [XmlEnum("PrivateProtected")]
    PrivateProtected,

    [XmlEnum("File")]
    File
}

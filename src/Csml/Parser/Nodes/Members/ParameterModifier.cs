namespace Csml.Parser.Nodes.Members;

/// <summary>
/// Defines the valid values of a reference parameter.
/// </summary>
public enum ParameterModifier
{
    Unset,

    [XmlEnum("Ref")]
    Ref,

    [XmlEnum("Out")]
    Out,

    [XmlEnum("RefReadonly")]
    RefReadonly,

    [XmlEnum("In")]
    In,

    [XmlEnum("Params")]
    Params
}

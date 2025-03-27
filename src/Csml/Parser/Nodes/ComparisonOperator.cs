namespace Csml.Parser.Nodes;

/// <summary>
/// Defines the valid values of a comparison operator.
/// </summary>
public enum ComparisonOperator
{
    Unset,

    [XmlEnum("Equal")]
    Equal,

    [XmlEnum("NotEqual")]
    NotEqual,

    [XmlEnum("LessThan")]
    LessThan,

    [XmlEnum("LessThanOrEqual")]
    LessThanOrEqual,

    [XmlEnum("GreaterThan")]
    GreaterThan,

    [XmlEnum("GreaterThanOrEqual")]
    GreaterThanOrEqual
}

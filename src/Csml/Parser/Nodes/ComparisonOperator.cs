namespace Csml.Parser.Nodes;

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

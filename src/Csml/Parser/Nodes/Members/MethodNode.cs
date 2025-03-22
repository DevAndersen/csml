﻿using Csml.Parser.Nodes.Statements;
using Csml.Parser.Nodes.Types;

namespace Csml.Parser.Nodes.Members;

public class MethodNode : BaseNode
{
    [XmlAttribute("Name")]
    public required string Name { get; init; }

    [XmlAttribute("Access")]
    public AccessModifier Access { get; init; }

    [XmlAttribute("Return")]
    public required string Return { get; init; }

    [XmlElement("Return", typeof(ReturnNode))]
    public BaseNode[]? Statements { get; init; }
}

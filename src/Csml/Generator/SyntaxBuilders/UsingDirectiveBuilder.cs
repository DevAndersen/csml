﻿using Csml.Parser.Nodes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Csml.Generator.SyntaxBuilders;

internal static class UsingDirectiveBuilder
{
    public static UsingDirectiveSyntax Build(UsingDirectiveNode node)
    {
        return SF.UsingDirective(SF.IdentifierName(node.Namespace));
    }
}

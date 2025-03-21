﻿using Csml.Parser.Nodes.Types;

namespace Csml.Generator.SyntaxBuilders;

internal static class UsingDirectiveBuilder
{
    public static SyntaxList<UsingDirectiveSyntax> BuildMultiple(UsingDirectiveNode[]? nodes, NamespaceNode? parentNamespace)
    {
        SyntaxList<UsingDirectiveSyntax> usingList = SF.List<UsingDirectiveSyntax>();

        if (nodes != null)
        {
            foreach (UsingDirectiveNode item in nodes)
            {
                usingList = usingList.Add(Build(item, parentNamespace));
            }
        }

        return usingList;
    }

    public static UsingDirectiveSyntax Build(UsingDirectiveNode node, NamespaceNode? parentNamespace)
    {
        return SF.UsingDirective(SF.IdentifierName(node.Namespace));
    }
}

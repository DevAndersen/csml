﻿namespace Csml.Generator.SyntaxBuilders;

internal static class CsmlBuilder
{
    public static CompilationUnitSyntax Build(CsmlNode node)
    {
        CompilationUnitSyntax comp = SF.CompilationUnit();

        SyntaxList<UsingDirectiveSyntax> usingList = UsingDirectiveBuilder.BuildMultiple(node.UsingDirectives, null);
        SyntaxList<MemberDeclarationSyntax> namespaceList = NamespaceBuilder.BuildMultiple(node.Namespaces, null);

        return comp
            .WithUsings(usingList)
            .WithMembers(namespaceList)
            .NormalizeWhitespace();
    }
}

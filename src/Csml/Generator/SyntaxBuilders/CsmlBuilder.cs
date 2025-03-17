using Csml.Parser.Nodes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Csml.Generator.SyntaxBuilders;

internal static class CsmlBuilder
{
    public static CompilationUnitSyntax Build(CsmlNode node)
    {
        CompilationUnitSyntax comp = SF.CompilationUnit();

        SyntaxList<UsingDirectiveSyntax> usingList = SF.List<UsingDirectiveSyntax>();
        if (node.UsingDirectives != null)
        {
            foreach (UsingDirectiveNode item in node.UsingDirectives)
            {
                usingList = usingList.Add(UsingDirectiveBuilder.Build(item, null));
            }
        }

        SyntaxList<MemberDeclarationSyntax> namespaceList = SF.List<MemberDeclarationSyntax>();

        if (node.Namespaces != null)
        {
            foreach (NamespaceNode item in node.Namespaces)
            {
                namespaceList = namespaceList.Add(NamespaceBuilder.Build(item, null));
            }
        }

        return comp
            .WithUsings(usingList)
            .WithMembers(namespaceList)
            .NormalizeWhitespace();
    }
}

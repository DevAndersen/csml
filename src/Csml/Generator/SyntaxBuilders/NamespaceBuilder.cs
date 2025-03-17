using Csml.Parser.Nodes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Csml.Generator.SyntaxBuilders;

internal static class NamespaceBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(NamespaceNode[]? nodes, NamespaceNode? parentNamespace)
    {
        SyntaxList<MemberDeclarationSyntax> namespaceList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (NamespaceNode item in nodes)
            {
                namespaceList = namespaceList.Add(Build(item, parentNamespace));
            }
        }

        return namespaceList;
    }

    public static NamespaceDeclarationSyntax Build(NamespaceNode node, NamespaceNode? parentNamespace)
    {
        NamespaceDeclarationSyntax syntax = SF.NamespaceDeclaration(SF.IdentifierName(node.Name));
        SyntaxList<MemberDeclarationSyntax> list = SF.List<MemberDeclarationSyntax>();

        SyntaxList<UsingDirectiveSyntax> usingList = UsingDirectiveBuilder.BuildMultiple(node.UsingDirectives, node);

        SyntaxList<MemberDeclarationSyntax> namespaceList = BuildMultiple(node.Namespaces, node);
        list = list.AddRange(namespaceList);

        if (node.Types != null)
        {
            foreach (TypeNode typeNode in node.Types)
            {
                list = typeNode switch
                {
                    ClassNode classNode => list.Add(TypeBuilder.Build(SyntaxKind.ClassDeclaration, classNode, node)),
                    StructNode structNode => list.Add(TypeBuilder.Build(SyntaxKind.StructDeclaration, structNode, node)),
                    InterfaceNode interfaceNode => list.Add(TypeBuilder.Build(SyntaxKind.InterfaceDeclaration, interfaceNode, node)),
                    _ => throw new NotImplementedException($"BAD TYPE NODE TYPE {typeNode.GetType()}"), // Todo: Throw appropriate exception.
                };
            }
        }

        return syntax
            .WithUsings(usingList)
            .WithMembers(list);
    }
}

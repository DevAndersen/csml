using Csml.Parser.Nodes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Csml.Generator.SyntaxBuilders;

internal static class NamespaceBuilder
{
    public static NamespaceDeclarationSyntax Build(NamespaceNode node, NamespaceNode? parentNamespace)
    {
        NamespaceDeclarationSyntax syntax = SF.NamespaceDeclaration(SF.IdentifierName(node.Name));
        SyntaxList<MemberDeclarationSyntax> list = SF.List<MemberDeclarationSyntax>();

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

        return syntax.WithMembers(list);
    }
}

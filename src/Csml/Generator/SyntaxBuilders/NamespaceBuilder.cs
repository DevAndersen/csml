using Csml.Parser.Nodes.Types;

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
        SyntaxList<MemberDeclarationSyntax> typeList = TypeBuilder.BuildMultiple(node.Types, node);

        SyntaxList<MemberDeclarationSyntax> namespaceList = BuildMultiple(node.Namespaces, node);
        list = list
            .AddRange(namespaceList)
            .AddRange(typeList);

        return syntax
            .WithUsings(usingList)
            .WithMembers(list);
    }
}

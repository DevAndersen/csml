using Csml.Parser.Nodes.Types;

namespace Csml.Generator.SyntaxBuilders;

internal static class NamespaceBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(NamespaceNode[]? nodes)
    {
        SyntaxList<MemberDeclarationSyntax> namespaceList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (NamespaceNode item in nodes)
            {
                namespaceList = namespaceList.Add(Build(item));
            }
        }

        return namespaceList;
    }

    public static NamespaceDeclarationSyntax Build(NamespaceNode node)
    {
        NamespaceDeclarationSyntax syntax = SF.NamespaceDeclaration(SF.IdentifierName(node.Name));
        SyntaxList<MemberDeclarationSyntax> list = SF.List<MemberDeclarationSyntax>();

        SyntaxList<UsingDirectiveSyntax> usingList = UsingDirectiveBuilder.BuildMultiple(node.UsingDirectives);
        SyntaxList<MemberDeclarationSyntax> typeList = TypeBuilder.BuildMultiple(node.Types, node);
        SyntaxList<MemberDeclarationSyntax> enumList = EnumBuilder.BuildMultiple(node.Enums, node);

        SyntaxList<MemberDeclarationSyntax> namespaceList = BuildMultiple(node.Namespaces);
        list = list
            .AddRange(namespaceList)
            .AddRange(typeList)
            .AddRange(enumList);

        return syntax
            .WithUsings(usingList)
            .WithMembers(list);
    }
}

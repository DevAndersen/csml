using Csml.Exceptions;
using Csml.Parser.Nodes.Members;
using Csml.Parser.Nodes.Types;

namespace Csml.Generator.SyntaxBuilders;

internal static class TypeBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(TypeNode[]? nodes, BaseNode parentNode)
    {
        SyntaxList<MemberDeclarationSyntax> typeList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (TypeNode item in nodes)
            {
                typeList = typeList.Add(Build(item, parentNode));
            }
        }

        return typeList;
    }

    public static TypeDeclarationSyntax Build(TypeNode typeNode, BaseNode parentNode)
    {
        SyntaxKind kind = typeNode switch
        {
            ClassNode => SyntaxKind.ClassDeclaration,
            StructNode => SyntaxKind.StructDeclaration,
            InterfaceNode => SyntaxKind.InterfaceDeclaration,
            _ => throw new UnexpectedCsmlPermutationException(typeNode.LineNumber, typeNode.GetType().FullName, "type")
        };

        TypeDeclarationSyntax syntax = SF.TypeDeclaration(kind, typeNode.Name);

        SyntaxKind[] accessModifiers = typeNode.Access switch
        {
            AccessModifier.Public => [SyntaxKind.PublicKeyword],
            AccessModifier.Private => [SyntaxKind.PrivateKeyword],
            AccessModifier.Protected => [SyntaxKind.ProtectedKeyword],
            AccessModifier.Internal => [SyntaxKind.InternalKeyword],
            AccessModifier.ProtectedInternal => [SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword],
            AccessModifier.PrivateProtected => [SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword],
            AccessModifier.File => [SyntaxKind.FileKeyword],
            _ when parentNode is InterfaceNode => [SyntaxKind.PublicKeyword],
            _ when parentNode is TypeNode => [SyntaxKind.PrivateKeyword],
            _ => [SyntaxKind.InternalKeyword]
        };

        SyntaxTokenList tokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in accessModifiers)
        {
            tokenList = tokenList.Add(SF.Token(accessModifier));
        }

        if (typeNode is ClassNode { Static: true })
        {
            tokenList = tokenList.Add(SF.Token(SyntaxKind.StaticKeyword));
        }

        if (typeNode is StructNode structNode)
        {
            if (structNode.ReadOnly)
            {
                tokenList = tokenList.Add(SF.Token(SyntaxKind.ReadOnlyKeyword));
            }

            if (structNode.Ref)
            {
                tokenList = tokenList.Add(SF.Token(SyntaxKind.RefKeyword));
            }
        }

        SyntaxList<MemberDeclarationSyntax> memberList = SF.List<MemberDeclarationSyntax>();
        SyntaxList<MemberDeclarationSyntax> typeList = BuildMultiple(typeNode.Types, typeNode);
        SyntaxList<MemberDeclarationSyntax> enumList = EnumBuilder.BuildMultiple(typeNode.Enums, typeNode);

        memberList = memberList
            .AddRange(typeList)
            .AddRange(enumList);

        if (typeNode.Members != null)
        {
            foreach (MemberNode member in typeNode.Members)
            {
                memberList = member switch
                {
                    PropertyNode propertyNode => memberList.Add(PropertyBuilder.Build(propertyNode, typeNode)),
                    FieldNode fieldNode => memberList.Add(FieldBuilder.Build(fieldNode, typeNode)),
                    _ => throw new UnexpectedCsmlPermutationException(typeNode.LineNumber, member.GetType().FullName, "member")
                };
            }
        }

        if (typeNode.Methods != null)
        {
            memberList = memberList.AddRange(MethodBuilder.BuildMultiple(typeNode.Methods, typeNode));
        }

        return syntax
            .WithModifiers(tokenList)
            .WithMembers(memberList);
    }
}

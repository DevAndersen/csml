using Csml.Parser.Nodes.Members;
using Csml.Parser.Nodes.Types;

namespace Csml.Generator.SyntaxBuilders;

internal static class TypeBuilder
{
    public static TypeDeclarationSyntax Build(SyntaxKind kind, TypeNode typeNode, BaseNode parentNode)
    {
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
            _ => [SyntaxKind.InternalKeyword]
        };

        SyntaxTokenList tokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in accessModifiers)
        {
            tokenList = tokenList.Add(SF.Token(accessModifier));
        }

        SyntaxList<MemberDeclarationSyntax> memberList = SF.List<MemberDeclarationSyntax>();
        if (typeNode.Members != null)
        {
            foreach (AbstractMemberNode member in typeNode.Members)
            {
                memberList = member switch
                {
                    PropertyNode propertyNode => memberList.Add(PropertyBuilder.Build(propertyNode, typeNode)),
                    _ => throw new NotImplementedException($"BAD MEMBER NODE TYPE {member.GetType()}"), // Todo: Throw appropriate exception.
                };
            }
        }

        return syntax
            .WithModifiers(tokenList)
            .WithMembers(memberList);
    }
}

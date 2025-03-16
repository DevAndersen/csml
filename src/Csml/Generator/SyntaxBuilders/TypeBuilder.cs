using Csml.Parser.Nodes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Csml.Generator.SyntaxBuilders;

internal static class TypeBuilder
{
    public static TypeDeclarationSyntax Build(SyntaxKind kind, AbstractTypeNode typeNode)
    {
        TypeDeclarationSyntax syntax = SF.TypeDeclaration(kind, typeNode.Name);

        Microsoft.CodeAnalysis.SyntaxTokenList tokenList = SF.TokenList(
        [
            SF.Token(SyntaxKind.PublicKeyword),
        ]);

        Microsoft.CodeAnalysis.SyntaxList<MemberDeclarationSyntax> memberList = SF.List<MemberDeclarationSyntax>();
        if (typeNode.Members != null)
        {
            foreach (AbstractMemberNode member in typeNode.Members)
            {
                memberList = member switch
                {
                    PropertyNode propertyNode => memberList.Add(PropertyBuilder.Build(propertyNode)),
                    _ => throw new NotImplementedException($"BAD MEMBER NODE TYPE {member.GetType()}"), // Todo: Throw appropriate exception.
                };
            }
        }

        return syntax
            .WithModifiers(tokenList)
            .WithMembers(memberList);
    }
}

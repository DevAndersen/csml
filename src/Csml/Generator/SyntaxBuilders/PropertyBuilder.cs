using Csml.Parser.Nodes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Csml.Generator.SyntaxBuilders;

internal class PropertyBuilder
{
    public static PropertyDeclarationSyntax Build(PropertyNode propertyNode)
    {
        PredefinedTypeSyntax type = SF.PredefinedType(SF.Token(SyntaxKind.IntKeyword));
        PropertyDeclarationSyntax syntax = SF.PropertyDeclaration(type, propertyNode.Name);

        Microsoft.CodeAnalysis.SyntaxTokenList tokenList = SF.TokenList(
        [
            SF.Token(SyntaxKind.PublicKeyword),
        ]);

        AccessorListSyntax accessors = SF.AccessorList(SF.List(
        [
            SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)),
            SF.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken))
        ]));

        return syntax
            .WithModifiers(tokenList)
            .WithAccessorList(accessors);
    }
}

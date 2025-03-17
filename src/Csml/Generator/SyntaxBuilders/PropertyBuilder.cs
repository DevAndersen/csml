using Csml.Parser.Nodes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Csml.Generator.SyntaxBuilders;

internal class PropertyBuilder
{
    public static PropertyDeclarationSyntax Build(PropertyNode propertyNode, TypeNode parentType)
    {
        PredefinedTypeSyntax type = SF.PredefinedType(SF.Token(SyntaxKind.IntKeyword));
        PropertyDeclarationSyntax syntax = SF.PropertyDeclaration(type, propertyNode.Name);

        SyntaxKind[] accessModifiers = propertyNode.Access switch
        {
            AccessModifier.Public => [SyntaxKind.PublicKeyword],
            AccessModifier.Private => [SyntaxKind.PrivateKeyword],
            AccessModifier.Protected => [SyntaxKind.ProtectedKeyword],
            AccessModifier.Internal => [SyntaxKind.InternalKeyword],
            AccessModifier.ProtectedInternal => [SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword],
            AccessModifier.PrivateProtected => [SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword],
            AccessModifier.File => [SyntaxKind.FileKeyword],
            _ when parentType is InterfaceNode => [SyntaxKind.PublicKeyword],
            _ => [SyntaxKind.PrivateKeyword],
        };

        SyntaxTokenList tokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in accessModifiers)
        {
            tokenList = tokenList.Add(SF.Token(accessModifier));
        }

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

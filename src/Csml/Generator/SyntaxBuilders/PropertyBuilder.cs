﻿using Csml.Parser.Nodes.Members;
using Csml.Parser.Nodes.Types;

namespace Csml.Generator.SyntaxBuilders;

internal static class PropertyBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(PropertyNode[]? nodes, TypeNode parentType)
    {
        SyntaxList<MemberDeclarationSyntax> propertyList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (PropertyNode item in nodes)
            {
                propertyList = propertyList.Add(Build(item, parentType));
            }
        }

        return propertyList;
    }

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

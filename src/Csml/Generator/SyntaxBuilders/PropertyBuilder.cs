﻿using Csml.Exceptions;
using Csml.Parser.Nodes.Members;
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

        SyntaxKind[] propertyAccessModifiers = propertyNode.Access switch
        {
            AccessModifier.Public => [SyntaxKind.PublicKeyword],
            AccessModifier.Private => [SyntaxKind.PrivateKeyword],
            AccessModifier.Protected => [SyntaxKind.ProtectedKeyword],
            AccessModifier.Internal => [SyntaxKind.InternalKeyword],
            AccessModifier.ProtectedInternal => [SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword],
            AccessModifier.PrivateProtected => [SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword],
            AccessModifier.File => throw new InvalidAccessorException(propertyNode.LineNumber, propertyNode.Access, "property"),
            _ when parentType is InterfaceNode => [SyntaxKind.PublicKeyword],
            _ => [SyntaxKind.PrivateKeyword],
        };

        SyntaxTokenList tokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in propertyAccessModifiers)
        {
            tokenList = tokenList.Add(SF.Token(accessModifier));
        }

        AccessorListSyntax accessors = SF.AccessorList();

        if (propertyNode.Getter != PropertyGetterAccessor.Unset)
        {
            SyntaxTokenList getterAccessTokens = SF.TokenList(GetAccessorAccessModifiers(propertyNode.GetterAccess, propertyNode).Select(SF.Token));
            accessors = accessors
                .AddAccessors(SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                .WithModifiers(getterAccessTokens)
                .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)));
        }

        if (propertyNode.Setter != PropertySetterAccessor.Unset)
        {
            SyntaxTokenList setterAccessTokens = SF.TokenList(GetAccessorAccessModifiers(propertyNode.SetterAccess, propertyNode).Select(SF.Token));

            SyntaxKind setterSyntaxKind = propertyNode.Setter == PropertySetterAccessor.Set
                ? SyntaxKind.SetAccessorDeclaration
                : SyntaxKind.InitAccessorDeclaration;

            accessors = accessors
                .AddAccessors(SF.AccessorDeclaration(setterSyntaxKind)
                .WithModifiers(setterAccessTokens)
                .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)));
        }

        return syntax
            .WithModifiers(tokenList)
            .WithAccessorList(accessors);
    }

    private static SyntaxKind[] GetAccessorAccessModifiers(AccessModifier modifier, PropertyNode propertyNode)
    {
        return modifier switch
        {
            AccessModifier.Public => [SyntaxKind.PublicKeyword],
            AccessModifier.Private => [SyntaxKind.PrivateKeyword],
            AccessModifier.Protected => [SyntaxKind.ProtectedKeyword],
            AccessModifier.Internal => [SyntaxKind.InternalKeyword],
            AccessModifier.ProtectedInternal => [SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword],
            AccessModifier.PrivateProtected => [SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword],
            AccessModifier.File => throw new InvalidAccessorException(propertyNode.LineNumber, modifier, "property accessor"),
            _ => [],
        };
    }
}

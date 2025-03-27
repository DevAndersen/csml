namespace Csml.Generator.SyntaxBuilders.Types;

internal class EnumBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(EnumNode[]? nodes, BaseNode parentNode)
    {
        SyntaxList<MemberDeclarationSyntax> typeList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (EnumNode item in nodes)
            {
                typeList = typeList.Add(Build(item, parentNode));
            }
        }

        return typeList;
    }

    public static EnumDeclarationSyntax Build(EnumNode enumNode, BaseNode parentNode)
    {
        EnumDeclarationSyntax enumDeclaration = SF.EnumDeclaration(enumNode.Name);

        SyntaxKind[] accessModifiers = enumNode.Access switch
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

        SeparatedSyntaxList<EnumMemberDeclarationSyntax> enumMemberDeclarations = SF.SeparatedList<EnumMemberDeclarationSyntax>(GetValueDeclarations(enumNode.Values));

        return enumDeclaration
            .WithMembers(enumMemberDeclarations)
            .WithModifiers(tokenList);
    }

    private static IEnumerable<SyntaxNodeOrToken> GetValueDeclarations(EnumValue[]? values)
    {
        if (values == null)
        {
            yield break;
        }

        for (int i = 0; i < values.Length; i++)
        {
            if (i != 0)
            {
                yield return SF.MissingToken(SyntaxKind.CommaToken);
            }

            EnumValue value = values[i];
            EnumMemberDeclarationSyntax declaration = SF.EnumMemberDeclaration(value.Name);

            if (value.Value != null)
            {
                EqualsValueClauseSyntax valueSyntax = SF.EqualsValueClause(SF.IdentifierName(value.Value));
                declaration = declaration.WithEqualsValue(valueSyntax);
            }

            yield return declaration;
        }
    }
}

namespace Csml.Generator.SyntaxBuilders.Members;

internal static class ConstructorBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(ConstructorNode[]? nodes, TypeNode parentType)
    {
        SyntaxList<MemberDeclarationSyntax> methodList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (ConstructorNode item in nodes)
            {
                methodList = methodList.Add(Build(item, parentType));
            }
        }

        return methodList;
    }

    public static ConstructorDeclarationSyntax Build(ConstructorNode constructorNode, TypeNode parentType)
    {
        SyntaxKind[] accessModifiers = constructorNode.Access switch
        {
            AccessModifier.Public => [SyntaxKind.PublicKeyword],
            AccessModifier.Private => [SyntaxKind.PrivateKeyword],
            AccessModifier.Protected => [SyntaxKind.ProtectedKeyword],
            AccessModifier.Internal => [SyntaxKind.InternalKeyword],
            AccessModifier.ProtectedInternal => [SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword],
            AccessModifier.PrivateProtected => [SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword],
            AccessModifier.File => throw new InvalidAccessorException(constructorNode.LineNumber, constructorNode.Access, "constructor"),
            _ => [SyntaxKind.PrivateKeyword],
        };

        SyntaxTokenList tokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in accessModifiers)
        {
            tokenList = tokenList.Add(SF.Token(accessModifier));
        }
        BlockSyntax block = BlockBuilder.Build(constructorNode.Statements?.Statements);

        ConstructorDeclarationSyntax constructorDeclaration = SF.ConstructorDeclaration(parentType.Name);

        if (constructorNode.Parameters != null)
        {
            constructorDeclaration = constructorDeclaration.WithParameterList(
                ParameterBuilder.BuildMultiple(constructorNode.Parameters));
        }

        return constructorDeclaration
            .WithModifiers(tokenList)
            .WithBody(block);
    }
}

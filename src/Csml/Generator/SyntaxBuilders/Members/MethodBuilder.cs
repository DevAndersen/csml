namespace Csml.Generator.SyntaxBuilders.Members;

internal class MethodBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(MethodNode[]? nodes, TypeNode parentType)
    {
        SyntaxList<MemberDeclarationSyntax> methodList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (MethodNode item in nodes)
            {
                methodList = methodList.Add(Build(item, parentType));
            }
        }

        return methodList;
    }

    public static MethodDeclarationSyntax Build(MethodNode methodNode, TypeNode parentType)
    {
        SyntaxKind[] accessModifiers = methodNode.Access switch
        {
            AccessModifier.Public => [SyntaxKind.PublicKeyword],
            AccessModifier.Private => [SyntaxKind.PrivateKeyword],
            AccessModifier.Protected when parentType is StructNode => throw new InvalidAccessorException(methodNode.LineNumber, methodNode.Access, "method"),
            AccessModifier.Protected => [SyntaxKind.ProtectedKeyword],
            AccessModifier.Internal => [SyntaxKind.InternalKeyword],
            AccessModifier.ProtectedInternal when parentType is StructNode => throw new InvalidAccessorException(methodNode.LineNumber, methodNode.Access, "method"),
            AccessModifier.ProtectedInternal => [SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword],
            AccessModifier.PrivateProtected when parentType is StructNode => throw new InvalidAccessorException(methodNode.LineNumber, methodNode.Access, "method"),
            AccessModifier.PrivateProtected => [SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword],
            AccessModifier.File => throw new InvalidAccessorException(methodNode.LineNumber, methodNode.Access, "method"),
            _ when parentType is InterfaceNode => [SyntaxKind.PublicKeyword],
            _ => [SyntaxKind.PrivateKeyword],
        };

        SyntaxTokenList tokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in accessModifiers)
        {
            tokenList = tokenList.Add(SF.Token(accessModifier));
        }

        tokenList = AddTokenIf(tokenList, methodNode.Static, SyntaxKind.StaticKeyword);
        tokenList = AddTokenIf(tokenList, methodNode.Async, SyntaxKind.AsyncKeyword);
        tokenList = AddTokenIf(tokenList, methodNode.Abstract, SyntaxKind.AbstractKeyword);
        tokenList = AddTokenIf(tokenList, methodNode.Virtual, SyntaxKind.VirtualKeyword);
        tokenList = AddTokenIf(tokenList, methodNode.Override, SyntaxKind.OverrideKeyword);

        MethodDeclarationSyntax methodDeclaration = SF.MethodDeclaration(
            SF.IdentifierName(methodNode.Return),
            SF.Identifier(methodNode.Name));

        if (methodNode.Abstract || (parentType is InterfaceNode && methodNode.Statements?.Statements?.Any() != true))
        {
            methodDeclaration = methodDeclaration.WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken));
        }
        else if (methodNode.Statements != null)
        {
            BlockSyntax block = BlockBuilder.Build(methodNode.Statements.Statements);
            methodDeclaration = methodDeclaration.WithBody(block);
        }

        if (methodNode.Parameters != null)
        {
            SeparatedSyntaxList<ParameterSyntax> parameterList = SF.SeparatedList<ParameterSyntax>();

            foreach (ParameterNode parameter in methodNode.Parameters)
            {
                parameterList = parameterList.Add(BuildParameter(parameter));
            }

            methodDeclaration = methodDeclaration.WithParameterList(SF.ParameterList(parameterList));
        }

        return methodDeclaration
            .WithModifiers(tokenList);
    }

    private static SyntaxTokenList AddTokenIf(SyntaxTokenList tokenList, bool state, SyntaxKind syntaxKind)
    {
        return state
            ? tokenList.Add(SF.Token(syntaxKind))
            : tokenList;
    }

    private static ParameterSyntax BuildParameter(ParameterNode parameterNode)
    {
        ParameterSyntax parameter = SF
            .Parameter(SF.Identifier(parameterNode.Name))
            .WithType(SF.IdentifierName(parameterNode.Type));

        if (parameterNode.Default != null && !string.IsNullOrWhiteSpace(parameterNode.Default))
        {
            EqualsValueClauseSyntax defaultClause = SF.EqualsValueClause(SF.IdentifierName(parameterNode.Default));
            parameter = parameter.WithDefault(defaultClause);
        }

        SyntaxKind[] accessModifiers = parameterNode.Modifier switch
        {
            ParameterModifier.Ref => [SyntaxKind.RefKeyword],
            ParameterModifier.Out => [SyntaxKind.OutKeyword],
            ParameterModifier.RefReadonly => [SyntaxKind.ReadOnlyKeyword, SyntaxKind.RefKeyword],
            ParameterModifier.In => [SyntaxKind.InKeyword],
            ParameterModifier.Params => [SyntaxKind.ParamsKeyword],
            _ => [],
        };

        SyntaxTokenList modifierTokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in accessModifiers)
        {
            modifierTokenList = modifierTokenList.Add(SF.Token(accessModifier));
        }

        return parameter
            .WithModifiers(modifierTokenList);
    }
}

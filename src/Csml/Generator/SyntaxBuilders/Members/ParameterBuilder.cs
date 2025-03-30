namespace Csml.Generator.SyntaxBuilders.Members;

internal static class ParameterBuilder
{
    public static ParameterListSyntax BuildMultiple(ParameterNode[] parameters)
    {
        SeparatedSyntaxList<ParameterSyntax> parameterList = SF.SeparatedList<ParameterSyntax>();

        foreach (ParameterNode parameter in parameters)
        {
            parameterList = parameterList.Add(BuildParameter(parameter));
        }

        return SF.ParameterList(parameterList);
    }

    public static ParameterSyntax BuildParameter(ParameterNode parameterNode)
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

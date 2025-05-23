﻿namespace Csml.Generator.SyntaxBuilders.Statements;

internal class VariableBuilder
{
    public static LocalDeclarationStatementSyntax Build(VariableNode node)
    {
        VariableDeclaratorSyntax variableDeclarator = SF.VariableDeclarator(node.Name);

        if (node.Expression != null)
        {
            ExpressionSyntax valueExpression = ExpressionBuilder.Build(node.Expression.Expression);
            variableDeclarator = variableDeclarator.WithInitializer(SF.EqualsValueClause(valueExpression));
        }

        VariableDeclarationSyntax variableDeclaration = SF.VariableDeclaration(SF.IdentifierName(node.Type), [variableDeclarator]);

        SyntaxTokenList tokenList = SF.TokenList();

        if (node.Const)
        {
            tokenList = tokenList.Add(SF.Token(SyntaxKind.ConstKeyword));
        }

        return SF.LocalDeclarationStatement(variableDeclaration)
            .WithModifiers(tokenList);
    }
}

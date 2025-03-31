namespace Csml.Generator.SyntaxBuilders.Statements;

internal class CallBuilder
{
    public static ExpressionStatementSyntax Build(CallNode node)
    {
        InvocationExpressionSyntax invocationExpression;

        if (node.Target != null && !string.IsNullOrWhiteSpace(node.Target))
        {
            MemberAccessExpressionSyntax methodAccessExpression = SF.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SF.IdentifierName(node.Target),
                SF.IdentifierName(node.Method));

            invocationExpression = SF.InvocationExpression(methodAccessExpression);
        }
        else
        {
            invocationExpression = SF.InvocationExpression(SF.IdentifierName(node.Method));
        }

        if (node.Arguments != null)
        {
            invocationExpression = invocationExpression.WithArgumentList(ArgumentListBuilder.BuildArgumentList(node.Arguments));
        }

        return SF.ExpressionStatement(invocationExpression);
    }
}

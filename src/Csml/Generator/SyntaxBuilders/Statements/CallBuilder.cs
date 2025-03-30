namespace Csml.Generator.SyntaxBuilders.Statements;

internal class CallBuilder
{
    public static ExpressionStatementSyntax Build(CallNode node)
    {
        MemberAccessExpressionSyntax methodAccessExpression = SF.MemberAccessExpression(
            SyntaxKind.SimpleMemberAccessExpression,
            SF.IdentifierName(node.Target),
            SF.IdentifierName(node.Method));

        InvocationExpressionSyntax invocationExpression = SF.InvocationExpression(methodAccessExpression);

        if (node.Arguments != null)
        {
            invocationExpression = invocationExpression.WithArgumentList(ArgumentListBuilder.BuildArgumentList(node.Arguments));
        }

        return SF.ExpressionStatement(invocationExpression);
    }
}

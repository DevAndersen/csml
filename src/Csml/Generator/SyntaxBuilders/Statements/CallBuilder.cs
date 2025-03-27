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
            ArgumentListSyntax argumentList = SF.ArgumentList();

            foreach (ArgumentNode argument in node.Arguments)
            {
                argumentList = argumentList.AddArguments(SF.Argument(SF.IdentifierName(argument.Value)));
            }

            invocationExpression = invocationExpression.WithArgumentList(argumentList);
        }

        return SF.ExpressionStatement(invocationExpression);
    }
}

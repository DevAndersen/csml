using Csml.Parser.Nodes.Expressions;

namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class ExpressionBuilder
{
    public static ExpressionSyntax Build(ExpressionNode node)
    {
        if (node is NewNode newNode)
        {
            return BuildNew(newNode);
        }
        else if (node is AwaitNode awaitNode)
        {
            return BuildAwait(awaitNode);
        }
        else if (node is CallNode callNode)
        {
            return CallBuilder.Build(callNode).Expression;
        }
        else if (node is ValueNode valueNode)
        {
            return SF.IdentifierName(valueNode.Value);
        }
        else if (node is AssignmentNode assignmentNode)
        {
            return SF.AssignmentExpression(
                SyntaxKind.SimpleAssignmentExpression,
                Build(assignmentNode.Left.Expression),
                Build(assignmentNode.Right.Expression));
        }
        else if (node is UnaryExpressionNode unaryExpression)
        {
            SyntaxKind kind = unaryExpression switch
            {
                NotNode => SyntaxKind.LogicalNotExpression,
                BitwiseNotNode => SyntaxKind.BitwiseNotExpression,
                _ => throw new NotImplementedException() // Todo: Throw appropriate exception.
            };

            ExpressionSyntax expression = Build(unaryExpression.Expression.Expression);

            return SF.PrefixUnaryExpression(
                kind,
                SF.ParenthesizedExpression(expression));
        }
        else if (node is UnaryValueExpressionNode unaryValue)
        {
            IdentifierNameSyntax target = SF.IdentifierName(unaryValue.Target);

            return unaryValue switch
            {
                IncrementNode => SF.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, target),
                DecrementNode => SF.PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, target),
                PrefixIncrementNode => SF.PrefixUnaryExpression(SyntaxKind.PreIncrementExpression, target),
                PrefixDecrementNode => SF.PrefixUnaryExpression(SyntaxKind.PreDecrementExpression, target),
                _ => throw new NotImplementedException() // Todo: Throw appropriate exception.
            };
        }
        else if (node is BinaryExpressionNode binary)
        {
            SyntaxKind kind = binary switch
            {
                AddNode => SyntaxKind.AddExpression,
                AndNode => SyntaxKind.LogicalAndExpression,
                BitwiseAndNode => SyntaxKind.BitwiseAndExpression,
                BitwiseOrNode => SyntaxKind.BitwiseOrExpression,
                DivideNode => SyntaxKind.DivideExpression,
                EqualsNode => SyntaxKind.EqualsExpression,
                GreaterThanNode => SyntaxKind.GreaterThanExpression,
                GreaterThanOrEqualNode => SyntaxKind.GreaterThanOrEqualExpression,
                LeftShiftNode => SyntaxKind.LeftShiftExpression,
                LessThanNode => SyntaxKind.LessThanExpression,
                LessThanOrEqualNode => SyntaxKind.LessThanOrEqualExpression,
                MultiplyNode => SyntaxKind.MultiplyExpression,
                NotEqualsNode => SyntaxKind.NotEqualsExpression,
                OrNode => SyntaxKind.LogicalOrExpression,
                RemainderNode => SyntaxKind.ModuloExpression,
                RightShiftNode => SyntaxKind.RightShiftExpression,
                SubtractNode => SyntaxKind.SubtractExpression,
                UnsignedRightShiftNode => SyntaxKind.UnsignedRightShiftExpression,
                XorNode => SyntaxKind.ExclusiveOrExpression,
                _ => throw new NotImplementedException() // Todo: Throw appropriate exception.
            };

            ExpressionSyntax left = Build(binary.Left.Expression);
            ExpressionSyntax right = Build(binary.Right.Expression);

            return SF.BinaryExpression(
                kind,
                left,
                right);
        }
        throw new NotImplementedException(); // Todo: Throw appropriate exception.
    }

    private static AwaitExpressionSyntax BuildAwait(AwaitNode awaitNode)
    {
        return SF.AwaitExpression(Build(awaitNode.Expression.Expression));
    }

    private static ObjectCreationExpressionSyntax BuildNew(NewNode newNode)
    {
        ObjectCreationExpressionSyntax expression = SF.ObjectCreationExpression(SF.IdentifierName(newNode.Type));

        if (newNode.Arguments != null)
        {
            expression = expression.WithArgumentList(ArgumentListBuilder.BuildArgumentList(newNode.Arguments));
        }

        return expression;
    }
}

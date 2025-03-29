using Csml.Parser.Nodes.Expressions;

namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class ExpressionBuilder
{
    public static ExpressionSyntax Build(ExpressionNode node)
    {
        if (node is CallNode callNode)
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
        else if (node is UnaryExpressionNode unary)
        {
            IdentifierNameSyntax target = SF.IdentifierName(unary.Target);

            return unary switch
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
                SubtractNode => SyntaxKind.SubtractExpression,
                MultiplyNode => SyntaxKind.MultiplyExpression,
                DivideNode => SyntaxKind.DivideExpression,
                RemainderNode => SyntaxKind.ModuloExpression,
                EqualsNode => SyntaxKind.EqualsExpression,
                NotEqualsNode => SyntaxKind.NotEqualsExpression,
                LessThanNode => SyntaxKind.LessThanExpression,
                LessThanOrEqualNode => SyntaxKind.LessThanOrEqualExpression,
                GreaterThanNode => SyntaxKind.GreaterThanExpression,
                GreaterThanOrEqualNode => SyntaxKind.GreaterThanOrEqualExpression,
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
}

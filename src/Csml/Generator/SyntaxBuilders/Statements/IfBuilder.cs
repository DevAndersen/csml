using Csml.Parser.Nodes.Statements;

namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class IfBuilder
{
    public static IfStatementSyntax Build(IfNode node, IEnumerable<StatementContainerNode> elseNodeChain)
    {
        BinaryExpressionSyntax condition = SF.BinaryExpression(
            GetSyntaxKindForComparison(node.Comparison),
            SF.IdentifierName(node.Left),
            SF.IdentifierName(node.Right));

        BlockSyntax block = BlockBuilder.Build(node.Statements);
        IfStatementSyntax ifStatement = SF.IfStatement(condition, block);

        ifStatement = BuildElseChain(ifStatement, elseNodeChain);

        return ifStatement;
    }

    private static IfStatementSyntax BuildElseChain(IfStatementSyntax ifStatement, IEnumerable<StatementContainerNode> elseNodeChain)
    {
        StatementContainerNode firstNode = elseNodeChain.FirstOrDefault();

        if (firstNode is ElseIfNode elseIfNode)
        {
            ElseClauseSyntax elseClause = SF.ElseClause(Build(elseIfNode, elseNodeChain.Skip(1)));
            ifStatement = ifStatement.WithElse(elseClause);
        }
        else if (firstNode is ElseNode elseNode)
        {
            BlockSyntax block = BlockBuilder.Build(elseNode.Statements);
            ifStatement = ifStatement.WithElse(SF.ElseClause(block));
        }

        return ifStatement;
    }

    private static SyntaxKind GetSyntaxKindForComparison(ComparisonOperator comparison)
    {
        return comparison switch
        {
            ComparisonOperator.Equal => SyntaxKind.EqualsExpression,
            ComparisonOperator.NotEqual => SyntaxKind.NotEqualsExpression,
            ComparisonOperator.LessThan => SyntaxKind.LessThanExpression,
            ComparisonOperator.LessThanOrEqual => SyntaxKind.LessThanOrEqualExpression,
            ComparisonOperator.GreaterThan => SyntaxKind.GreaterThanExpression,
            ComparisonOperator.GreaterThanOrEqual => SyntaxKind.GreaterThanOrEqualExpression,
            _ => throw new NotImplementedException() // Todo: Throw appropriate exception.
        };
    }
}

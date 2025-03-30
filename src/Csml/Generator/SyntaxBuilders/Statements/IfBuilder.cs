namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class IfBuilder
{
    public static IfStatementSyntax Build(IfNode node, IEnumerable<BaseNode> chainedNodes)
    {
        ExpressionSyntax condition = ExpressionBuilder.Build(node.Expression.Expression);

        BlockSyntax block = BlockBuilder.Build(node.Statements.Statements);
        IfStatementSyntax ifStatement = SF.IfStatement(condition, block);

        ifStatement = BuildElseChain(ifStatement, chainedNodes);

        return ifStatement;
    }

    private static IfStatementSyntax BuildElseChain(IfStatementSyntax ifStatement, IEnumerable<BaseNode> chainedNodes)
    {
        BaseNode firstNode = chainedNodes.FirstOrDefault();

        if (firstNode is ElseIfNode elseIfNode)
        {
            ElseClauseSyntax elseClause = SF.ElseClause(Build(elseIfNode, chainedNodes.Skip(1)));
            ifStatement = ifStatement.WithElse(elseClause);
        }
        else if (firstNode is ElseNode elseNode)
        {
            BlockSyntax block = BlockBuilder.Build(elseNode.Statements);
            ifStatement = ifStatement.WithElse(SF.ElseClause(block));
        }

        return ifStatement;
    }
}

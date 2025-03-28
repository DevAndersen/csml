namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class IfBuilder
{
    public static IfStatementSyntax Build(IfNode node, IEnumerable<BaseNode> elseNodeChain)
    {
        ExpressionSyntax condition = ExpressionBuilder.Build(node.Expression.Expression);

        BlockSyntax block = BlockBuilder.Build(node.Statements.Statements);
        IfStatementSyntax ifStatement = SF.IfStatement(condition, block);

        ifStatement = BuildElseChain(ifStatement, elseNodeChain);

        return ifStatement;
    }

    private static IfStatementSyntax BuildElseChain(IfStatementSyntax ifStatement, IEnumerable<BaseNode> elseNodeChain)
    {
        BaseNode firstNode = elseNodeChain.FirstOrDefault();

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
}

namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class WhileBuilder
{
    public static WhileStatementSyntax Build(WhileNode whileNode)
    {
        ExpressionSyntax condition = ExpressionBuilder.Build(whileNode.Condition.Expression);
        BlockSyntax block = BlockBuilder.Build(whileNode.Statements.Statements);

        return SF.WhileStatement(condition, block);
    }
}

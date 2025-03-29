namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class ForBuilder
{
    public static ForStatementSyntax Build(ForNode node)
    {
        LocalDeclarationStatementSyntax variable = VariableBuilder.Build(node.Variable);
        ExpressionSyntax condition = ExpressionBuilder.Build(node.Condition.Expression);
        ExpressionSyntax incrementor = ExpressionBuilder.Build(node.Iterator.Expression);

        BlockSyntax block = BlockBuilder.Build(node.Statements.Statements);

        return SF.ForStatement(block)
            .WithDeclaration(variable.Declaration)
            .WithCondition(condition)
            .WithIncrementors([incrementor]);
    }
}

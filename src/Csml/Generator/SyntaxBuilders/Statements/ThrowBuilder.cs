namespace Csml.Generator.SyntaxBuilders.Statements;

internal class ThrowBuilder
{
    public static ThrowStatementSyntax Build(ThrowNode node)
    {
        return SF.ThrowStatement(ExpressionBuilder.Build(node.Expression));
    }
}

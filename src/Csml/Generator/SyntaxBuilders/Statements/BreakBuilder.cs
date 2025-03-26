namespace Csml.Generator.SyntaxBuilders.Statements;

internal class BreakBuilder
{
    public static BreakStatementSyntax Build()
    {
        return SF.BreakStatement();
    }
}

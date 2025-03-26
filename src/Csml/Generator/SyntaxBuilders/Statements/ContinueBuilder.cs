namespace Csml.Generator.SyntaxBuilders.Statements;

internal class ContinueBuilder
{
    public static ContinueStatementSyntax Build()
    {
        return SF.ContinueStatement();
    }
}

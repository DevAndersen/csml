namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class ReturnBuilder
{
    public static ReturnStatementSyntax Build(ReturnNode node)
    {
        if (node.Value == null)
        {
            return SF.ReturnStatement();
        }

        return SF.ReturnStatement(SF.IdentifierName(node.Value));
    }
}

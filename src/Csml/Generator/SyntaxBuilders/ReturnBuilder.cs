using Csml.Parser.Nodes.Statements;

namespace Csml.Generator.SyntaxBuilders;
internal static class ReturnBuilder
{
    public static ReturnStatementSyntax Build(ReturnNode node, BaseNode parentNode)
    {
        if (node.Value == null)
        {
            return SF.ReturnStatement();
        }

        return SF.ReturnStatement(SF.IdentifierName(node.Value));
    }
}

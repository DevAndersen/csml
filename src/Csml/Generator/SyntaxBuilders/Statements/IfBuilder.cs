using Csml.Parser.Nodes.Statements;

namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class IfBuilder
{
    public static IfStatementSyntax Build(IfNode node, IEnumerable<StatementContainerNode> elseNodeChain)
    {
        BinaryExpressionSyntax condition = SF.BinaryExpression(
            SyntaxKind.EqualsExpression,
            SF.IdentifierName(node.Left),
            SF.IdentifierName(node.Right));

        IfStatementSyntax ifStatement = SF.IfStatement(condition, SF.Block());

        ifStatement = BuildElseChain(ifStatement, elseNodeChain);

        return ifStatement;
    }

    private static IfStatementSyntax BuildElseChain(IfStatementSyntax ifStatement, IEnumerable<StatementContainerNode> elseNodeChain)
    {
        if (elseNodeChain.ElementAt(0) is ElseIfNode elseIfNode)
        {
            ElseClauseSyntax elseClause = SF.ElseClause(Build(elseIfNode, elseNodeChain.Skip(1)));
            ifStatement = ifStatement.WithElse(elseClause);
        }
        else
        {
            ifStatement = ifStatement.WithElse(SF.ElseClause(SF.Block()));
        }

        return ifStatement;
    }
}

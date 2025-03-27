using Csml.Parser.Nodes.Statements;

namespace Csml.Generator.SyntaxBuilders.Statements;

internal class ForEachBuilder
{
    public static ForEachStatementSyntax Build(ForEachNode node)
    {
        BlockSyntax block = BlockBuilder.Build(node.Statements);

        return SF.ForEachStatement(
            SF.IdentifierName(node.Type),
            SF.Identifier(node.Name),
            SF.IdentifierName(node.Collection),
            block);
    }
}

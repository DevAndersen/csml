namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class TryBuilder
{
    public static TryStatementSyntax Build(TryNode tryNode, IEnumerable<BaseNode> chainedNodes)
    {
        BlockSyntax block = BlockBuilder.Build(tryNode.Statements.Statements);
        SyntaxList<CatchClauseSyntax> catchClauseList = SF.List<CatchClauseSyntax>();
        FinallyClauseSyntax? finallyClause = null;

        foreach (BaseNode chainedNode in chainedNodes)
        {
            if (chainedNode is CatchNode catchNode)
            {
                catchClauseList = catchClauseList.Add(BuildCatchClause(catchNode));
            }
            else if (chainedNode is FinallyNode finallyNode)
            {
                finallyClause = BuildFinallyClause(finallyNode);
            }
        }

        return SF.TryStatement(block, catchClauseList, finallyClause);
    }

    private static CatchClauseSyntax BuildCatchClause(CatchNode catchNode)
    {
        BlockSyntax block = BlockBuilder.Build(catchNode.Statements.Statements);
        CatchClauseSyntax catchClause = SF.CatchClause().WithBlock(block);

        if (catchNode.Type != null && !string.IsNullOrWhiteSpace(catchNode.Type))
        {
            CatchDeclarationSyntax declaration = SF.CatchDeclaration(SF.IdentifierName(catchNode.Type));

            if (catchNode.Name != null && !string.IsNullOrWhiteSpace(catchNode.Name))
            {
                declaration = declaration.WithIdentifier(SF.Identifier(catchNode.Name));
            }

            catchClause = catchClause.WithDeclaration(declaration);
        }

        return catchClause;
    }

    private static FinallyClauseSyntax BuildFinallyClause(FinallyNode finallyNode)
    {
        return SF.FinallyClause(BlockBuilder.Build(finallyNode.Statements.Statements));
    }
}

using Csml.Generator.SyntaxBuilders.Statements;

namespace Csml.Generator.SyntaxBuilders;

internal class BlockBuilder
{
    public static BlockSyntax Build(BaseNode[]? nodes)
    {
        BlockSyntax block = SF.Block();

        if (nodes == null)
        {
            return block;
        }

        if (nodes?.Length > 0)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                BaseNode statementNode = nodes[i];

                StatementContainerNode[] elseNodeChain = [];
                if (statementNode is IfNode)
                {
                    elseNodeChain = nodes
                        .Skip(i + 1)
                        .TakeWhile(x => x is ElseIfNode or ElseNode)
                        .OfType<StatementContainerNode>()
                        .ToArray();

                    i += elseNodeChain.Length;
                }

                StatementSyntax statementSyntax = statementNode switch
                {
                    ReturnNode returnNode => ReturnBuilder.Build(returnNode),
                    VariableNode variableNode => VariableBuilder.Build(variableNode),
                    CallNode callNode => CallBuilder.Build(callNode),
                    BreakNode breakNode => BreakBuilder.Build(),
                    ContinueNode continueNode => ContinueBuilder.Build(),
                    IfNode ifNode => IfBuilder.Build(ifNode, elseNodeChain),
                    ForEachNode forEachNode => ForEachBuilder.Build(forEachNode),
                    _ => throw new UnknownCsmlElementException(
                        statementNode.LineNumber,
                        statementNode.GetType().Name)
                };

                block = block.AddStatements(statementSyntax);
            }
        }

        return block;
    }
}

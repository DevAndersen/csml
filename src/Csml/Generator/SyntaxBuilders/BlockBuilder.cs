using Csml.Generator.SyntaxBuilders.Statements;
using Csml.Parser.Nodes.Expressions;

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
                BaseNode[] chainedNodes = [];

                if (statementNode is IfNode)
                {
                    chainedNodes = nodes
                        .Skip(i + 1)
                        .TakeWhile(x => x is ElseIfNode or ElseNode)
                        .ToArray();

                    i += chainedNodes.Length;
                }
                else if (statementNode is TryNode)
                {
                    chainedNodes = nodes
                        .Skip(i + 1)
                        .TakeWhile(x => x is CatchNode or FinallyNode)
                        .ToArray();

                    i += chainedNodes.Length;
                }

                StatementSyntax statementSyntax = statementNode switch
                {
                    ReturnNode returnNode => ReturnBuilder.Build(returnNode),
                    VariableNode variableNode => VariableBuilder.Build(variableNode),
                    CallNode callNode => CallBuilder.Build(callNode),
                    BreakNode breakNode => BreakBuilder.Build(),
                    ContinueNode continueNode => ContinueBuilder.Build(),
                    IfNode ifNode => IfBuilder.Build(ifNode, chainedNodes),
                    ForNode forNode => ForBuilder.Build(forNode),
                    ForEachNode forEachNode => ForEachBuilder.Build(forEachNode),
                    ExpressionNode expressionNode => SF.ExpressionStatement(ExpressionBuilder.Build(expressionNode)),
                    ThrowNode throwNode => ThrowBuilder.Build(throwNode),
                    TryNode tryNode => TryBuilder.Build(tryNode, chainedNodes),
                    SwitchNode switchNode => SwitchBuilder.Build(switchNode),
                    WhileNode whileNode => WhileBuilder.Build(whileNode),
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

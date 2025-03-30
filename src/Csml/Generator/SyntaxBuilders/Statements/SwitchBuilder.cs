namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class SwitchBuilder
{
    public static SwitchStatementSyntax Build(SwitchNode switchNode)
    {
        SwitchStatementSyntax switchStatement = SF.SwitchStatement(SF.IdentifierName(switchNode.Value));

        if (switchNode.Cases != null)
        {
            foreach (StatementContainerNode caseNode in switchNode.Cases)
            {
                switchStatement = switchStatement.AddSections(BuildCase(caseNode));
            }
        }

        return switchStatement;
    }

    private static SwitchSectionSyntax BuildCase(StatementContainerNode node)
    {
        SwitchLabelSyntax label = node switch
        {
            CaseNode caseNode => SF.CaseSwitchLabel(SF.IdentifierName(caseNode.Value)),
            DefaultNode => SF.DefaultSwitchLabel(),
            _ => throw new NotImplementedException() // Todo: Throw appropriate exception.
        };

        BlockSyntax block = BlockBuilder.Build(node.Statements);
        return SF.SwitchSection([label], [block]);
    }
}

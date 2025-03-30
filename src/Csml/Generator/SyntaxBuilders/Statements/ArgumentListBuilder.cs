namespace Csml.Generator.SyntaxBuilders.Statements;

internal static class ArgumentListBuilder
{
    public static ArgumentListSyntax BuildArgumentList(ArgumentNode[] argumentNodes)
    {
        ArgumentListSyntax argumentList = SF.ArgumentList();

        foreach (ArgumentNode argument in argumentNodes)
        {
            argumentList = argumentList.AddArguments(SF.Argument(SF.IdentifierName(argument.Value)));
        }

        return argumentList;
    }
}

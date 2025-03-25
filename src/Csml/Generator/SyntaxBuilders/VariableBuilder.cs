using Csml.Parser.Nodes.Statements;

namespace Csml.Generator.SyntaxBuilders;

internal class VariableBuilder
{
    public static LocalDeclarationStatementSyntax Build(VariableNode node)
    {
        VariableDeclaratorSyntax variableDeclarator = SF.VariableDeclarator(node.Name);

        if (!string.IsNullOrWhiteSpace(node.Value))
        {
            variableDeclarator = variableDeclarator.WithInitializer(SF.EqualsValueClause(SF.IdentifierName(node.Value!)));
        }

        VariableDeclarationSyntax variableDeclaration = SF.VariableDeclaration(SF.IdentifierName(node.Type), [variableDeclarator]);

        SyntaxTokenList tokenList = SF.TokenList();

        if (node.Const)
        {
            tokenList = tokenList.Add(SF.Token(SyntaxKind.ConstKeyword));
        }

        return SF.LocalDeclarationStatement(variableDeclaration)
            .WithModifiers(tokenList);
    }
}

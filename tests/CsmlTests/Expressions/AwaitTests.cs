namespace CsmlTests.Expressions;

public class AwaitTests
{
    [Fact]
    public void AwaitTest()
    {
        // Arrange
        string csml = """
            <Await>
                <Expression>
                    <Value Value="task" />
                </Expression>
            </Await>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? awaitExpression))
        {
            Assert.Fail();
            return;
        }

        if (awaitExpression.Body?.Statements is not [LocalDeclarationStatementSyntax { Declaration: { } declaration }])
        {
            Assert.Fail();
            return;
        }

        Assert.True(declaration.Type is IdentifierNameSyntax { Identifier.Value: "await" });
        Assert.True(declaration.Variables is [VariableDeclaratorSyntax { Identifier.Value: "task" }]);
    }
}

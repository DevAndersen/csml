namespace CsmlTests.Statements;

public class BreakTests
{
    [Fact]
    public void BreakTest()
    {
        // Arrange
        string csml = """
            <Break />
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(methodDeclaration.Body?.GetChildNodes() is [BreakStatementSyntax]);
    }
}

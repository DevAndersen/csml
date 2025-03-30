namespace CsmlTests.Statements;

public class ContinueTests
{
    [Fact]
    public void ContinueTest()
    {
        // Arrange
        string csml = """
            <Continue/>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(methodDeclaration.Body?.GetChildNodes() is [ContinueStatementSyntax]);
    }
}

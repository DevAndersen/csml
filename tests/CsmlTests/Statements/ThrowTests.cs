namespace CsmlTests.Statements;

public class ThrowTests
{
    [Fact]
    public void Throw_NewException()
    {
        // Arrange
        string csml = """
            <Throw>
                <New Type="MyException" />
            </Throw>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out ThrowStatementSyntax? throwStatement))
        {
            Assert.Fail();
            return;
        }

        Assert.True(throwStatement.Expression is ObjectCreationExpressionSyntax);
    }

    [Fact]
    public void Throw_ExceptionVariable()
    {
        // Arrange
        string csml = """
            <Variable Type="MyException" Name="exception">
                <Expression>
                    <New Type="MyException" />
                </Expression>
            </Variable>
            <Throw>
                <Value Value="exception" />
            </Throw>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out ThrowStatementSyntax? throwStatement))
        {
            Assert.Fail();
            return;
        }

        Assert.True(throwStatement.Expression is IdentifierNameSyntax);
    }
}

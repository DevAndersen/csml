namespace CsmlTests.Statements;

public class TryTests
{
    [Fact]
    public void TryCatch_NoExceptionType()
    {
        // Arrange
        string csml = """
            <Try>
                <Statements>
                </Statements>
            </Try>
            <Catch>
                <Statements>
                </Statements>
            </Catch>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out TryStatementSyntax? tryStatement))
        {
            Assert.Fail();
            return;
        }

        if (tryStatement.Catches is not [CatchClauseSyntax catchClause])
        {
            Assert.Fail();
            return;
        }

        Assert.Null(catchClause.Declaration?.Type);
        Assert.Null(catchClause.Declaration?.Identifier.Value);
        Assert.Null(tryStatement.Finally);
    }

    [Fact]
    public void TryCatch_WithExceptionType()
    {
        // Arrange
        string csml = """
            <Try>
                <Statements>
                </Statements>
            </Try>
            <Catch Type="InvalidOperationException">
                <Statements>
                </Statements>
            </Catch>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out TryStatementSyntax? tryStatement))
        {
            Assert.Fail();
            return;
        }

        if (tryStatement.Catches is not [CatchClauseSyntax catchClause])
        {
            Assert.Fail();
            return;
        }

        Assert.True(catchClause.Declaration?.Type is IdentifierNameSyntax { Identifier.Text: "InvalidOperationException" });
        Assert.Null(catchClause.Declaration.Identifier.Value);
        Assert.Null(tryStatement.Finally);
    }

    [Fact]
    public void TryCatch_WithNamedExceptionType()
    {
        // Arrange
        string csml = """
            <Try>
                <Statements>
                </Statements>
            </Try>
            <Catch Type="InvalidOperationException" Name="e">
                <Statements>
                </Statements>
            </Catch>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out TryStatementSyntax? tryStatement))
        {
            Assert.Fail();
            return;
        }

        if (tryStatement.Catches is not [CatchClauseSyntax catchClause])
        {
            Assert.Fail();
            return;
        }

        Assert.True(catchClause.Declaration?.Type is IdentifierNameSyntax { Identifier.Text: "InvalidOperationException" });
        Assert.Equal("e", catchClause.Declaration.Identifier.Value);
        Assert.Null(tryStatement.Finally);
    }

    [Fact]
    public void TryCatchFinally()
    {
        // Arrange
        string csml = """
            <Try>
                <Statements>
                </Statements>
            </Try>
            <Catch>
                <Statements>
                </Statements>
            </Catch>
            <Finally>
                <Statements>
                </Statements>
            </Finally>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out TryStatementSyntax? tryStatement))
        {
            Assert.Fail();
            return;
        }

        if (tryStatement.Catches is not [CatchClauseSyntax catchClause])
        {
            Assert.Fail();
            return;
        }

        Assert.Null(catchClause.Declaration?.Type);
        Assert.Null(catchClause.Declaration?.Identifier.Value);
        Assert.NotNull(tryStatement.Finally);
    }

    [Fact]
    public void TryFinally()
    {
        // Arrange
        string csml = """
            <Try>
                <Statements>
                </Statements>
            </Try>
            <Finally>
                <Statements>
                </Statements>
            </Finally>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out TryStatementSyntax? tryStatement))
        {
            Assert.Fail();
            return;
        }

        Assert.Empty(tryStatement.Catches);
        Assert.NotNull(tryStatement.Finally);
    }
}

namespace CsmlTests.Expressions;

public class NewTests
{
    [Fact]
    public void New_WithoutArguments_HasNoArguments()
    {
        // Arrange
        string csml = """
            <New Type="MyType" />
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out ObjectCreationExpressionSyntax? expression))
        {
            Assert.Fail();
            return;
        }

        Assert.True(expression.Type is IdentifierNameSyntax { Identifier.Value: "MyType" });
        Assert.True(expression.ArgumentList is { Arguments: [] });
    }

    [Fact]
    public void New_WithArgument_HasArgument()
    {
        // Arrange
        string csml = """
            <New Type="MyType">
                <Argument Value="1" />
            </New>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out ObjectCreationExpressionSyntax? expression))
        {
            Assert.Fail();
            return;
        }

        Assert.True(expression.Type is IdentifierNameSyntax { Identifier.Value: "MyType" });
        Assert.True(expression.ArgumentList is { Arguments: [ArgumentSyntax] });
    }

    [Fact]
    public void New_WithArguments_HasArguments()
    {
        // Arrange
        string csml = """
            <New Type="MyType">
                <Argument Value="1" />
                <Argument Value="2" />
            </New>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out ObjectCreationExpressionSyntax? expression))
        {
            Assert.Fail();
            return;
        }

        Assert.True(expression.Type is IdentifierNameSyntax { Identifier.Value: "MyType" });
        Assert.True(expression.ArgumentList is { Arguments: [ArgumentSyntax, ArgumentSyntax] });
    }
}

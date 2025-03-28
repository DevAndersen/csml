namespace CsmlTests.Expressions;

public class UnaryExpressionTests
{
    [Theory]
    [InlineData("Increment", SyntaxKind.PlusPlusToken)]
    [InlineData("Decrement", SyntaxKind.MinusMinusToken)]
    public void PostfixTag_ExpectedSyntaxKind(string tag, SyntaxKind kind)
    {
        // Arrange
        string csml = $"""
            <{tag} Target="number" />
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out PostfixUnaryExpressionSyntax? expression))
        {
            Assert.Fail();
            return;
        }

        Assert.True(expression.Operand is IdentifierNameSyntax { Identifier.Text: "number" });
        Assert.Equal(kind, expression.OperatorToken.Kind());
    }

    [Theory]
    [InlineData("PrefixIncrement", SyntaxKind.PlusPlusToken)]
    [InlineData("PrefixDecrement", SyntaxKind.MinusMinusToken)]
    public void PrefixTag_ExpectedSyntaxKind(string tag, SyntaxKind kind)
    {
        // Arrange
        string csml = $"""
            <{tag} Target="number" />
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out PrefixUnaryExpressionSyntax? expression))
        {
            Assert.Fail();
            return;
        }

        Assert.True(expression.Operand is IdentifierNameSyntax { Identifier.Text: "number" });
        Assert.Equal(kind, expression.OperatorToken.Kind());
    }
}

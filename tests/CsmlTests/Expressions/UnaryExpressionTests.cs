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

    [Theory]
    [InlineData("Not", SyntaxKind.ExclamationToken)]
    [InlineData("BitwiseNot", SyntaxKind.TildeToken)]
    public void PrefixExpressionTag_ExpectedSyntaxKind(string tag, SyntaxKind kind)
    {
        // Arrange
        string csml = $"""
            <Variable Type="int" Name="value">
                <Expression>
                    <{tag}>
                        <Expression>
                            <Value Value="1" />
                        </Expression>
                    </{tag}>
                </Expression>
            </Variable>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out PrefixUnaryExpressionSyntax? expression))
        {
            Assert.Fail();
            return;
        }

        if (expression.Operand is not ParenthesizedExpressionSyntax parenthesis)
        {
            Assert.Fail();
            return;
        }

        if (parenthesis.Expression is not LiteralExpressionSyntax innerExpression)
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(kind, expression.OperatorToken.Kind());
        Assert.Equal(SyntaxKind.NumericLiteralExpression, innerExpression.Kind());
        Assert.Equal(1, innerExpression.Token.Value);
    }
}

namespace CsmlTests.Expressions;

public class BinaryExpressionTests
{
    [Theory]
    [InlineData("Add", SyntaxKind.AddExpression)]
    [InlineData("Subtract", SyntaxKind.SubtractExpression)]
    [InlineData("Multiply", SyntaxKind.MultiplyExpression)]
    [InlineData("Divide", SyntaxKind.DivideExpression)]
    [InlineData("Remainder", SyntaxKind.ModuloExpression)]
    [InlineData("Equals", SyntaxKind.EqualsExpression)]
    [InlineData("NotEquals", SyntaxKind.NotEqualsExpression)]
    [InlineData("LessThan", SyntaxKind.LessThanExpression)]
    [InlineData("LessThanOrEqual", SyntaxKind.LessThanOrEqualExpression)]
    [InlineData("GreaterThan", SyntaxKind.GreaterThanExpression)]
    [InlineData("GreaterThanOrEqual", SyntaxKind.GreaterThanOrEqualExpression)]
    [InlineData("Or", SyntaxKind.LogicalOrExpression)]
    [InlineData("And", SyntaxKind.LogicalAndExpression)]
    [InlineData("BitwiseOr", SyntaxKind.BitwiseOrExpression)]
    [InlineData("BitwiseAnd", SyntaxKind.BitwiseAndExpression)]
    [InlineData("Xor", SyntaxKind.ExclusiveOrExpression)]
    [InlineData("LeftShift", SyntaxKind.LeftShiftExpression)]
    [InlineData("RightShift", SyntaxKind.RightShiftExpression)]
    [InlineData("UnsignedRightShift", SyntaxKind.UnsignedRightShiftExpression)]
    public void Tag_ExpectedSyntaxKind(string tag, SyntaxKind kind)
    {
        // Arrange
        string csml = $"""
            <Variable Type="int" Name="number">
                <Expression>
                    <{tag}>
                        <Left>
                            <Value Value="1" />
                        </Left>
                        <Right>
                            <Value Value="2" />
                        </Right>
                    </{tag}>
                </Expression>
            </Variable>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out BinaryExpressionSyntax? expression))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(kind, expression.Kind());
        Assert.True(expression.Left is LiteralExpressionSyntax
        {
            RawKind: (int)SyntaxKind.NumericLiteralExpression,
            Token.Value: 1
        });
        Assert.True(expression.Right is LiteralExpressionSyntax
        {
            RawKind: (int)SyntaxKind.NumericLiteralExpression,
            Token.Value: 2
        });
    }
}

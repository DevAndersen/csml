namespace CsmlTests.Expressions;

public class AssignmentTests
{
    [Fact]
    public void AssignmentTest()
    {
        // Arrange
        string csml = """
            <Assignment>
                <Left>
                    <Value Value="number" />
                </Left>
                <Right>
                    <Value Value="123" />
                </Right>
            </Assignment>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out ExpressionStatementSyntax? expressionStatement))
        {
            Assert.Fail();
            return;
        }

        if (expressionStatement.Expression is not AssignmentExpressionSyntax assignment)
        {
            Assert.Fail();
            return;
        }

        if (assignment.Right is not LiteralExpressionSyntax rightExpression)
        {
            Assert.Fail();
            return;
        }

        Assert.True(assignment.Left is IdentifierNameSyntax { Identifier.Value: "number" });
        Assert.Equal(SyntaxKind.NumericLiteralExpression, rightExpression.Kind());
        Assert.Equal(123, rightExpression.Token.Value);
    }
}

namespace CsmlTests.Statements;

public class WhileTests
{
    [Fact]
    public void WhileTest()
    {
        // Arrange
        string csml = """
            <While>
                <Condition>
                    <LessThan>
                        <Left>
                            <Value Value="i" />
                        </Left>
                        <Right>
                            <Value Value="5" />
                        </Right>
                    </LessThan>
                </Condition>
                <Statements>
                    <Increment Target="i" />
                </Statements>
            </While>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out WhileStatementSyntax? whileStatement))
        {
            Assert.Fail();
            return;
        }

        Assert.True(whileStatement.Condition is BinaryExpressionSyntax { RawKind: (int)SyntaxKind.LessThanExpression });
        Assert.True(whileStatement.Statement is BlockSyntax { Statements.Count: 1 });
    }
}

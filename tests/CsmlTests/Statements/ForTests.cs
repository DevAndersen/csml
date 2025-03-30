namespace CsmlTests.Statements;

public class ForTests
{
    [Fact]
    public void ForTest()
    {
        // Arrange
        string csml = """
            <For>
                <Variable Type="int" Name="i">
                    <Expression>
                        <Value Value="0" />
                    </Expression>
                </Variable>
                <Condition>
                    <LessThan>
                        <Left>
                            <Value Value="i" />
                        </Left>
                        <Right>
                            <Value Value="10" />
                        </Right>
                    </LessThan>
                </Condition>
                <Iterator>
                    <Increment Target="i" />
                </Iterator>
                <Statements>
                    <Call Target="System.Console" Method="WriteLine" />
                </Statements>
            </For>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out ForStatementSyntax? forStatement))
        {
            Assert.Fail();
            return;
        }

        if (forStatement.Declaration is not VariableDeclarationSyntax variable)
        {
            Assert.Fail();
            return;
        }

        if (forStatement.Condition is not BinaryExpressionSyntax condition)
        {
            Assert.Fail();
            return;
        }

        if (forStatement.Incrementors is not [PostfixUnaryExpressionSyntax incrementor])
        {
            Assert.Fail();
            return;
        }

        if (forStatement.Statement is not BlockSyntax { Statements: [ExpressionStatementSyntax statement] })
        {
            Assert.Fail();
            return;
        }

        Assert.True(variable.Type is PredefinedTypeSyntax { Keyword.Value: "int" });
        Assert.True(variable.Variables is [VariableDeclaratorSyntax
        {
            Identifier.Text: "i",
            Initializer.Value: LiteralExpressionSyntax { Token.Value: 0 }
        }]);

        Assert.Equal(SyntaxKind.LessThanExpression, condition.Kind());
        Assert.True(condition.Left is IdentifierNameSyntax { Identifier.Value: "i" });
        Assert.True(condition.Right is LiteralExpressionSyntax { Token.Value: 10 });

        Assert.True(incrementor.Operand is IdentifierNameSyntax { Identifier.Value: "i" });
        Assert.Equal(SyntaxKind.PlusPlusToken, incrementor.OperatorToken.Kind());

        Assert.IsType<InvocationExpressionSyntax>(statement.Expression);
    }
}

namespace CsmlTests.Expressions;

public class ValueTests
{
    [Fact]
    public void ValueTest()
    {
        // Arrange
        string csml = """
            <Variable Type="int" Name="number">
                <Expression>
                    <Value Value="123" />
                </Expression>
            </Variable>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out LocalDeclarationStatementSyntax? declaration))
        {
            Assert.Fail();
            return;
        }

        if (declaration.Declaration.Variables is not [VariableDeclaratorSyntax declarator])
        {
            Assert.Fail();
            return;
        }

        Assert.True(declaration.Declaration.Type is PredefinedTypeSyntax { Keyword.Value: "int" });
        Assert.Equal("number", declarator.Identifier.Text);
        Assert.True(declarator.Initializer?.Value is LiteralExpressionSyntax { RawKind: (int)SyntaxKind.NumericLiteralExpression });
        Assert.True(declarator.Initializer?.Value is LiteralExpressionSyntax { Token.Value: 123 });
    }
}

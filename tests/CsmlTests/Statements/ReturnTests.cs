namespace CsmlTests.Statements;

public class ReturnTests
{
    [Fact]
    public void Return_Void_ExpectedVoid()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Return/>
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(methodDeclaration.Body?.GetChildNodes() is [ReturnStatementSyntax]);
    }

    [Theory]
    [InlineData("int", "123", 123, SyntaxKind.NumericLiteralExpression)]
    [InlineData("long", "9223372036854775807L", long.MaxValue, SyntaxKind.NumericLiteralExpression)]
    [InlineData("float", "3.14F", 3.14F, SyntaxKind.NumericLiteralExpression)]
    [InlineData("double", "3.14", 3.14, SyntaxKind.NumericLiteralExpression)]
    [InlineData("char", "'A'", 'A', SyntaxKind.CharacterLiteralExpression)]
    public void ReturnLiteral_LiteralValue_ExpectedValue(string type, string text, object value, SyntaxKind literalType)
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="{type}" Name="DoStuff">
                            <Return Value="{text}"/>
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out ReturnStatementSyntax? ret))
        {
            Assert.Fail();
            return;
        }

        if (!output.FirstDescendant(out LiteralExpressionSyntax? literalExpression))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal((int)literalType, literalExpression.RawKind);
        Assert.Equal(value, literalExpression.Token.Value);
    }

    [Fact]
    public void ReturnString_SingleQuote_ExpectedValue()
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="string" Name="DoStuff">
                            <Return Value='"Abc"'/>
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out ReturnStatementSyntax? ret))
        {
            Assert.Fail();
            return;
        }

        if (!output.FirstDescendant(out LiteralExpressionSyntax? literalExpression))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal((int)SyntaxKind.StringLiteralExpression, literalExpression.RawKind);
        Assert.Equal("Abc", literalExpression.Token.Value);
    }

    [Fact]
    public void ReturnString_DoubleQuoteWithXmlEscape_ExpectedValueAndToken()
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="string" Name="DoStuff">
                            <Return Value="&quot;Abc&quot;"/>
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out ReturnStatementSyntax? ret))
        {
            Assert.Fail();
            return;
        }

        if (!output.FirstDescendant(out LiteralExpressionSyntax? literalExpression))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal((int)SyntaxKind.StringLiteralExpression, literalExpression.RawKind);
        Assert.Equal("Abc", literalExpression.Token.Value);
    }
}

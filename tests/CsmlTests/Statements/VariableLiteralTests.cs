namespace CsmlTests.Statements;

public class VariableLiteralTests
{
    [Theory]
    [InlineData("bool")]
    [InlineData("byte")]
    [InlineData("sbyte")]
    [InlineData("short")]
    [InlineData("ushort")]
    [InlineData("int")]
    [InlineData("uint")]
    [InlineData("long")]
    [InlineData("ulong")]
    [InlineData("float")]
    [InlineData("double")]
    [InlineData("string")]
    [InlineData("char")]
    public void PredefinedLiteralType_UnspecifiedValue_ExpectedKeyword(string type)
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Variable Type="{type}" Name="value" />
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out LocalDeclarationStatementSyntax? variableDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(type, (variableDeclaration.Declaration.Type as PredefinedTypeSyntax)?.Keyword.Text);
    }

    [Theory]
    [InlineData("bool", "true", true, SyntaxKind.TrueLiteralExpression)]
    [InlineData("byte", "123", 123, SyntaxKind.NumericLiteralExpression)]
    [InlineData("sbyte", "100", 100, SyntaxKind.NumericLiteralExpression)]
    [InlineData("short", "100", 100, SyntaxKind.NumericLiteralExpression)]
    [InlineData("ushort", "100", 100, SyntaxKind.NumericLiteralExpression)]
    [InlineData("int", "100", 100, SyntaxKind.NumericLiteralExpression)]
    [InlineData("uint", "100U", 100U, SyntaxKind.NumericLiteralExpression)]
    [InlineData("long", "100L", 100L, SyntaxKind.NumericLiteralExpression)]
    [InlineData("ulong", "100UL", 100UL, SyntaxKind.NumericLiteralExpression)]
    [InlineData("float", "100F", 100F, SyntaxKind.NumericLiteralExpression)]
    [InlineData("double", "100D", 100D, SyntaxKind.NumericLiteralExpression)]
    [InlineData("string", "&quot;Text&quot;", "Text", SyntaxKind.StringLiteralExpression)]
    [InlineData("char", "'A'", 'A', SyntaxKind.CharacterLiteralExpression)]
    public void PredefinedLiteralType_WithValue_ExpectedValue(string type, string text, object? value, SyntaxKind literalType)
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Variable Type="{type}" Name="value" Value="{text}" />
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out LocalDeclarationStatementSyntax? variableDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (variableDeclaration.Declaration.Variables is not [VariableDeclaratorSyntax variableDeclarator])
        {
            Assert.Fail();
            return;
        }

        if (variableDeclarator.Initializer?.Value is not LiteralExpressionSyntax literalExpression)
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(type, (variableDeclaration.Declaration.Type as PredefinedTypeSyntax)?.Keyword.Text);
        Assert.Equal((int)literalType, literalExpression.RawKind);
        Assert.Equal(value, literalExpression.Token.Value);
    }
}

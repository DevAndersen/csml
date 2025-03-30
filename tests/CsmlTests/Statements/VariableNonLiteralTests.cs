namespace CsmlTests.Statements;

public class VariableNonLiteralTests
{
    [Fact]
    public void CustomReferenceType_UnspecifiedValue()
    {
        // Arrange
        string csml = $"""
            <Variable Type="MyClass" Name="value" />
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out LocalDeclarationStatementSyntax? variableDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (variableDeclaration.Declaration.Variables is not [VariableDeclaratorSyntax])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyClass", (variableDeclaration.Declaration.Type as IdentifierNameSyntax)?.Identifier.Text);
    }

    [Fact]
    public void CustomReferenceType_ExplicitNullValue_ValueIsNull()
    {
        // Arrange
        string csml = $"""
            <Variable Type="MyClass" Name="value">
                <Expression>
                    <Value Value="null" />
                </Expression>
            </Variable>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

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

        Assert.Equal("MyClass", (variableDeclaration.Declaration.Type as IdentifierNameSyntax)?.Identifier.Text);
        Assert.Equal((int)SyntaxKind.NullLiteralExpression, literalExpression.RawKind);
        Assert.Null(literalExpression.Token.Value);
    }

    [Fact]
    public void CustomReferenceType_DefaultValue_ValueIsNull()
    {
        // Arrange
        string csml = $"""
            <Variable Type="MyClass" Name="value">
                <Expression>
                    <Value Value="default" />
                </Expression>
            </Variable>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

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

        Assert.Equal("MyClass", (variableDeclaration.Declaration.Type as IdentifierNameSyntax)?.Identifier.Text);
        Assert.Equal((int)SyntaxKind.DefaultLiteralExpression, literalExpression.RawKind);
        Assert.Equal("default", literalExpression.Token.Value);
    }
}

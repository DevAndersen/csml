namespace CsmlTests.Statements;

public class VariableNonLiteralTests
{
    [Fact]
    public void CustomReferenceType_UnspecifiedValue()
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Variable Type="MyClass" Name="value" />
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

        Assert.Equal("MyClass", (variableDeclaration.Declaration.Type as IdentifierNameSyntax)?.Identifier.Text);
    }

    [Fact]
    public void CustomReferenceType_ExplicitNullValue_ValueIsNull()
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Variable Type="MyClass" Name="value" Value="null" />
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

        Assert.Equal("MyClass", (variableDeclaration.Declaration.Type as IdentifierNameSyntax)?.Identifier.Text);
        Assert.Equal((int)SyntaxKind.NullLiteralExpression, literalExpression.RawKind);
        Assert.Null(literalExpression.Token.Value);
    }

    [Fact]
    public void CustomReferenceType_DefaultValue_ValueIsNull()
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Variable Type="MyClass" Name="value" Value="default" />
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

        Assert.Equal("MyClass", (variableDeclaration.Declaration.Type as IdentifierNameSyntax)?.Identifier.Text);
        Assert.Equal((int)SyntaxKind.DefaultLiteralExpression, literalExpression.RawKind);
        Assert.Equal("default", literalExpression.Token.Value);
    }
}

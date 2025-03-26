namespace CsmlTests.Types;

public class EnumValueTests
{
    [Fact]
    public void ExplicitValues_ImplicitValues()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Enum Name="MyEnum">
                        <EnumValue Name="A" />
                        <EnumValue Name="B" />
                        <EnumValue Name="C" />
                    </Enum>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (enumDeclaration.Members is not [
            EnumMemberDeclarationSyntax { Identifier.Text: "A" } valueA,
            EnumMemberDeclarationSyntax { Identifier.Text: "B" } valueB,
            EnumMemberDeclarationSyntax { Identifier.Text: "C" } valueC])
        {
            Assert.Fail();
            return;
        }

        Assert.Null(valueA.EqualsValue);
        Assert.Null(valueB.EqualsValue);
        Assert.Null(valueC.EqualsValue);
    }

    [Fact]
    public void ExplicitValues_ExpectedValues()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Enum Name="MyEnum">
                        <EnumValue Name="A" Value="1" />
                        <EnumValue Name="B" Value="2" />
                        <EnumValue Name="C" Value="3" />
                    </Enum>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (enumDeclaration.Members is not [
            EnumMemberDeclarationSyntax { Identifier.Text: "A" } valueA,
            EnumMemberDeclarationSyntax { Identifier.Text: "B" } valueB,
            EnumMemberDeclarationSyntax { Identifier.Text: "C" } valueC])
        {
            Assert.Fail();
            return;
        }

        Assert.True(valueA.EqualsValue?.Value is LiteralExpressionSyntax
        {
            RawKind: (int)SyntaxKind.NumericLiteralExpression,
            Token: { RawKind: (int)SyntaxKind.NumericLiteralToken, Value: 1 }
        });

        Assert.True(valueB.EqualsValue?.Value is LiteralExpressionSyntax
        {
            RawKind: (int)SyntaxKind.NumericLiteralExpression,
            Token: { RawKind: (int)SyntaxKind.NumericLiteralToken, Value: 2 }
        });

        Assert.True(valueC.EqualsValue?.Value is LiteralExpressionSyntax
        {
            RawKind: (int)SyntaxKind.NumericLiteralExpression,
            Token: { RawKind: (int)SyntaxKind.NumericLiteralToken, Value: 3 }
        });
    }

    [Fact]
    public void ExplicitValues_MixedImplicitAndExpectedValues()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Enum Name="MyEnum">
                        <EnumValue Name="A" />
                        <EnumValue Name="B" />
                        <EnumValue Name="C" Value="3" />
                    </Enum>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (enumDeclaration.Members is not [
            EnumMemberDeclarationSyntax { Identifier.Text: "A" } valueA,
            EnumMemberDeclarationSyntax { Identifier.Text: "B" } valueB,
            EnumMemberDeclarationSyntax { Identifier.Text: "C" } valueC])
        {
            Assert.Fail();
            return;
        }

        Assert.Null(valueA.EqualsValue);
        Assert.Null(valueB.EqualsValue);
        Assert.True(valueC.EqualsValue?.Value is LiteralExpressionSyntax
        {
            RawKind: (int)SyntaxKind.NumericLiteralExpression,
            Token: { RawKind: (int)SyntaxKind.NumericLiteralToken, Value: 3 }
        });
    }
}

namespace CsmlTests.Members;

public class ParameterTests
{
    [Fact]
    public void Parameters_NoParameters_EmptyParameterList()
    {
        // Arrange
        string csml = """
            <Method Name="MyMethod" Return="void">
            </Method>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInClass(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Empty(methodDeclaration.ParameterList.Parameters);
    }

    [Fact]
    public void Parameters_OneParameters_NotEmptyParameterList()
    {
        // Arrange
        string csml = """
            <Method Name="MyMethod" Return="void">
                <Parameter Type="int" Name="number" />
            </Method>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInClass(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (methodDeclaration.ParameterList.Parameters is not [ParameterSyntax parameter])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("number", parameter.Identifier.Value);
        Assert.True(parameter.Type is PredefinedTypeSyntax { Keyword.Value: "int" });
    }

    [Fact]
    public void Parameters_TwoParameters_NotEmptyParameterList()
    {
        // Arrange
        string csml = """
            <Method Name="MyMethod" Return="void">
                <Parameter Type="int" Name="number" />
                <Parameter Type="string" Name="text" />
            </Method>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInClass(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (methodDeclaration.ParameterList.Parameters is not [ParameterSyntax parameterA, ParameterSyntax parameterB])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("number", parameterA.Identifier.Value);
        Assert.True(parameterA.Type is PredefinedTypeSyntax { Keyword.Value: "int" });


        Assert.Equal("text", parameterB.Identifier.Value);
        Assert.True(parameterB.Type is PredefinedTypeSyntax { Keyword.Value: "string" });
    }

    [Fact]
    public void Parameters_NoModifiers_EmptyModifierList()
    {
        // Arrange
        string csml = """
            <Method Name="MyMethod" Return="void">
                <Parameter Type="int" Name="number" />
            </Method>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInClass(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (methodDeclaration.ParameterList.Parameters is not [ParameterSyntax parameter])
        {
            Assert.Fail();
            return;
        }

        Assert.Empty(parameter.Modifiers);
    }

    [Theory]
    [InlineData("Ref", SyntaxKind.RefKeyword)]
    [InlineData("Out", SyntaxKind.OutKeyword)]
    [InlineData("RefReadonly", SyntaxKind.ReadOnlyKeyword, SyntaxKind.RefKeyword)]
    [InlineData("In", SyntaxKind.InKeyword)]
    [InlineData("Params", SyntaxKind.ParamsKeyword)]
    public void Parameters_WithModifier_HasExpectedModifier(string modifier, params SyntaxKind[] syntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Method Name="MyMethod" Return="void">
                <Parameter Modifier="{modifier}" Type="int" Name="number" />
            </Method>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInClass(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (methodDeclaration.ParameterList.Parameters is not [ParameterSyntax parameter])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(syntaxKinds, parameter.Modifiers.Select(x => x.Kind()).ToArray());
    }
}

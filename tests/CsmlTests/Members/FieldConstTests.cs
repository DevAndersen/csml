namespace CsmlTests.Members;

public class FieldConstTests
{
    [Fact]
    public void Const_NotSpecified_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field Name="myField" Type="int" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out FieldDeclarationSyntax? fieldDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(fieldDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }]);
    }

    [Fact]
    public void Const_True_IsConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field Const="true" Name="myField" Type="int" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out FieldDeclarationSyntax? fieldDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(fieldDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }, SyntaxToken { RawKind: (int)SyntaxKind.ConstKeyword}]);
    }

    [Fact]
    public void Const_False_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field Const="false" Name="myField" Type="int" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out FieldDeclarationSyntax? fieldDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(fieldDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }]);
    }
}

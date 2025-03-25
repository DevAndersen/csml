namespace CsmlTests.Members;

public class FieldReadOnlyTests
{
    [Fact]
    public void ReadOnly_NotSpecified_IsNotConst()
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
    public void ReadOnly_True_IsConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field ReadOnly="true" Name="myField" Type="int" />
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

        Assert.True(fieldDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }, SyntaxToken { RawKind: (int)SyntaxKind.ReadOnlyKeyword }]);
    }

    [Fact]
    public void ReadOnly_False_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field ReadOnly="false" Name="myField" Type="int" />
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

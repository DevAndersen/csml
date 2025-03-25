namespace CsmlTests.Members;

public class FieldStaticTests
{
    [Fact]
    public void Static_NotSpecified_IsNotConst()
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
    public void Static_True_IsConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field Static="true" Name="myField" Type="int" />
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

        Assert.True(fieldDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }, SyntaxToken { RawKind: (int)SyntaxKind.StaticKeyword }]);
    }

    [Fact]
    public void Static_False_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field Static="false" Name="myField" Type="int" />
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

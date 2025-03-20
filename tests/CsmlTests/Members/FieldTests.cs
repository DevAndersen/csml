using Csml.Generator;
using Microsoft.CodeAnalysis;

namespace CsmlTests.Members;

public class FieldTests
{
    [Fact]
    public void UnspecifiedAccessModifiers_Private()
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
        Assert.Equal("int", fieldDeclaration.Declaration.Type.GetText().ToString().Trim());
        Assert.True(fieldDeclaration.Declaration.Variables is [VariableDeclaratorSyntax { Identifier.Text: "myField"}]);
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    public void Class_DefinedAccessModifiers_ExpectedModifiers(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field Access="{accessText}" Name="myField" Type="int" />
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

        Assert.Equal(accessSyntaxKinds, fieldDeclaration.Modifiers.Select(x => x.Kind()));
        Assert.Equal("int", fieldDeclaration.Declaration.Type.GetText().ToString().Trim());
        Assert.True(fieldDeclaration.Declaration.Variables is [VariableDeclaratorSyntax { Identifier.Text: "myField"}]);
    }

    [Fact]
    public void Class_FileAccessModifiers_CompileFails()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Field Access="File" Name="myField" Type="int" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics);

        // Assert
        Assert.Empty(output);
        Assert.True(diagnostics is [Diagnostic { Id: CsmlDiagnostics.InvalidAccessorId }]);
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    public void Struct_DefinedAccessModifiers_ExpectedModifiers(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                        <Field Access="{accessText}" Name="myField" Type="int" />
                    </Struct>
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

        Assert.Equal(accessSyntaxKinds, fieldDeclaration.Modifiers.Select(x => x.Kind()));
        Assert.Equal("int", fieldDeclaration.Declaration.Type.GetText().ToString().Trim());
        Assert.True(fieldDeclaration.Declaration.Variables is [VariableDeclaratorSyntax { Identifier.Text: "myField" }]);
    }

    [Theory]
    [InlineData("Protected")]
    [InlineData("ProtectedInternal")]
    [InlineData("PrivateProtected")]
    [InlineData("File")]
    public void Struct_InvalidAccessModifiers_CompileFails(string accessText)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                        <Field Access="{accessText}" Name="myField" Type="int" />
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics);

        // Assert
        Assert.Empty(output);
        Assert.True(diagnostics is [Diagnostic { Id: CsmlDiagnostics.InvalidAccessorId }]);
    }
}

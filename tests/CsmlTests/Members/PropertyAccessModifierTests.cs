using Csml.Generator;

namespace CsmlTests.Members;

public class PropertyAccessModifierTests
{
    [Fact]
    public void UnspecifiedAccessModifiers()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Property Name="MyProperty" Type="int" Getter="Get" Setter="Set" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out PropertyDeclarationSyntax? propertyDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(propertyDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }]);
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    public void DefinedAccessModifiers_ExpectedModifiers(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Property Access="{accessText}" Name="MyProperty" Type="int" Getter="Get" Setter="Set" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out PropertyDeclarationSyntax? propertyDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, propertyDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Fact]
    public void FileAccessModifiers_CompileFails()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Property Access="File" Name="MyProperty" Type="int" Getter="Get" Setter="Set" />
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
}

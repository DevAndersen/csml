using Csml.Generator;

namespace CsmlTests.Members;

public class MethodAccessModifierTests
{
    [Fact]
    public void Class_UnspecifiedAccessModifiers_Private()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(methodDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }]);
        Assert.Equal("void", methodDeclaration.ReturnType.GetText().ToString().Trim());
        Assert.Equal("DoStuff", methodDeclaration.Identifier.Text);
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
                        <Method Access="{accessText}" Return="void" Name="DoStuff" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, methodDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Fact]
    public void Class_FileAccessModifiers_CompileFails()
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyStruct">
                        <Method Access="File" Return="void" Name="DoStuff" />
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

    [Fact]
    public void Struct_UnspecifiedAccessModifiers_Private()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                        <Method Return="void" Name="DoStuff" />
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(methodDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }]);
        Assert.Equal("void", methodDeclaration.ReturnType.GetText().ToString().Trim());
        Assert.Equal("DoStuff", methodDeclaration.Identifier.Text);
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
                        <Method Access="{accessText}" Return="void" Name="DoStuff" />
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, methodDeclaration.Modifiers.Select(x => x.Kind()));
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
                        <Method Access="{accessText}" Return="void" Name="DoStuff" />
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
    [Fact]
    public void Interface_UnspecifiedAccessModifiers_Public()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Interface Name="IMyInterface">
                        <Method Return="void" Name="DoStuff" />
                    </Interface>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(methodDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PublicKeyword }]);
        Assert.Equal("void", methodDeclaration.ReturnType.GetText().ToString().Trim());
        Assert.Equal("DoStuff", methodDeclaration.Identifier.Text);
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    public void Interface_DefinedAccessModifiers_ExpectedModifiers(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Interface Name="IMyInterface">
                        <Method Access="{accessText}" Return="void" Name="DoStuff" />
                    </Interface>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, methodDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Fact]
    public void Interface_FileAccessModifiers_CompileFails()
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Interface Name="IMyInterface">
                        <Method Access="File" Return="void" Name="DoStuff" />
                    </Interface>
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

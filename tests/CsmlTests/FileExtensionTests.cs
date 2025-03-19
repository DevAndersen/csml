using Csml.Generator;

namespace CsmlTests;

public class FileExtensionTests
{
    [Fact]
    public void PreferredFileExtension_CompileSucceedsWithoutDiagnostics()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics, "Test.c♯");

        // Assert
        Assert.Empty(diagnostics);
        Assert.True(output is [NamespaceDeclarationSyntax]);
    }

    [Theory]
    [InlineData(".c#")]
    [InlineData(".csml")]
    public void NotPreferredFileExtension_CompileSucceedsWithDiagnostic(string fileExtension)
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics, $"Test{fileExtension}");

        // Assert
        Assert.True(diagnostics is [Diagnostic { Id: GeneratorDiagnostics.NotPreferredFileExtensionId }]);
        Assert.True(output is [NamespaceDeclarationSyntax]);
    }

    [Theory]
    [InlineData(".cs")]
    [InlineData("")]
    public void UnexpectedFileExtension_CompileSkippedWithoutDiagnostic(string fileExtension)
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics, $"Test{fileExtension}");

        // Assert
        Assert.Empty(diagnostics);
        Assert.Empty(output);
    }
}

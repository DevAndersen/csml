namespace CsmlTests;

public class FileExtensionTests
{
    [Fact]
    public void PreferredFiletype_NoDiagnostics()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                </Namespace>
            </Csml>
            """;

        // Act
        IEnumerable<SyntaxNode> output = AssertCompile(csml, out ImmutableArray<Diagnostic> diagnostics, "Test.c♯");

        // Assert
        Assert.Empty(diagnostics);
        Assert.True(output.ToArray() is [NamespaceDeclarationSyntax]);
    }

    [Fact]
    public void NotPreferredFiletype_Diagnostic()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                </Namespace>
            </Csml>
            """;

        // Act
        IEnumerable<SyntaxNode> output = AssertCompile(csml, out ImmutableArray<Diagnostic> diagnostics, "Test.c#");

        // Assert
        Assert.NotEmpty(diagnostics);
        Assert.True(output.ToArray() is [NamespaceDeclarationSyntax]);
    }
}

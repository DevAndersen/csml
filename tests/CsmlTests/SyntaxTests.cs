using Csml.Generator;

namespace CsmlTests;

public class SyntaxTests
{
    [Fact]
    public void EmptySyntax_CompileSkipped()
    {
        // Arrange
        string csml = string.Empty;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics);

        // Assert
        Assert.Empty(output);
        Assert.Empty(diagnostics);
    }

    [Fact]
    public void EmptyCsmlTags_CompileSkipped()
    {
        // Arrange
        string csml = """
            <Csml>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics);

        // Assert
        Assert.Empty(output);
        Assert.Empty(diagnostics);
    }

    [Fact]
    public void BrokenSyntax_CompileFails()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                </Namespace
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics);

        // Assert
        Assert.Empty(output);
        Assert.True(diagnostics is [Diagnostic { Id: CsmlDiagnostics.XmlParseExceptionId }]);
    }

    [Fact]
    public void UnexpectedToken_CompileFails()
    {
        // Arrange
        string csml = """
            <CsmlA>
            	<Namespace Name="MyNamespace">
                </Namespace>
            </CsmlA>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics);

        // Assert
        Assert.Empty(output);
        Assert.True(diagnostics is [Diagnostic { Id: CsmlDiagnostics.UnexpectedParseExceptionId }]);
    }

    [Fact]
    public void MissingRequiredAttribute_CompileFails()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics);

        // Assert
        Assert.Empty(output);
        Assert.True(diagnostics is [Diagnostic { Id: CsmlDiagnostics.MissingRequiredPropertyId }]);
    }

    [Fact]
    public void UnexpectedTags_CompileFails()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace>
                    <Csml>
                    </Csml>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics);

        // Assert
        Assert.Empty(output);
        Assert.True(diagnostics is [Diagnostic { Id: CsmlDiagnostics.ParseErrorId }]);
    }
}

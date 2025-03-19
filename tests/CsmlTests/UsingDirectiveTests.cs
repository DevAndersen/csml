namespace CsmlTests;

public class UsingDirectiveTests
{
    [Fact]
    public void Single_ExectedName()
    {
        // Arrange
        string csml = """
            <Csml>
                <UsingDirective Namespace="System" />
            	<Namespace Name="MyNamespace"></Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [UsingDirectiveSyntax usingDirective, NamespaceDeclarationSyntax])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("System", usingDirective.Name?.ToString());
    }

    [Fact]
    public void Multiple_ExectedNames()
    {
        // Arrange
        string csml = """
            <Csml>
            	<UsingDirective Namespace="System" />
            	<UsingDirective Namespace="System.Text" />
            	<Namespace Name="MyNamespace"></Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [UsingDirectiveSyntax usingDirective1, UsingDirectiveSyntax usingDirective2, NamespaceDeclarationSyntax])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("System", usingDirective1.Name?.ToString());
        Assert.Equal("System.Text", usingDirective2.Name?.ToString());
    }
    [Fact]
    public void InsideNamespace_ExectedNames()
    {
        // Arrange
        string csml = """
            <Csml>
            	<UsingDirective Namespace="System" />
            	<Namespace Name="MyNamespace1">
            	    <UsingDirective Namespace="System.Text" />
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [UsingDirectiveSyntax usingDirective1, NamespaceDeclarationSyntax namespaceDeclaration])
        {
            Assert.Fail();
            return;
        }

        SyntaxNode[] nested = namespaceDeclaration.GetChildNodes();
        if (nested is not [IdentifierNameSyntax, UsingDirectiveSyntax usingDirective2])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("System", usingDirective1.Name?.ToString());
        Assert.Equal("System.Text", usingDirective2.Name?.ToString());
    }
}

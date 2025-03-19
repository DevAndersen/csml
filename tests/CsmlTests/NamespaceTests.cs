namespace CsmlTests;

public class NamespaceTests
{
    [Fact]
    public void Single_ExectedName()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace"></Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [NamespaceDeclarationSyntax namespaceDeclaration])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyNamespace", namespaceDeclaration.Name.ToString());
    }

    [Fact]
    public void Multiple_ExectedNames()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace1"></Namespace>
            	<Namespace Name="MyNamespace2"></Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [NamespaceDeclarationSyntax namespaceDeclaration1, NamespaceDeclarationSyntax namespaceDeclaration2])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyNamespace1", namespaceDeclaration1.Name.ToString());
        Assert.Equal("MyNamespace2", namespaceDeclaration2.Name.ToString());
    }

    [Fact]
    public void Nested_ExectedNames()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace1">
            	    <Namespace Name="MyNamespace2"></Namespace>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [NamespaceDeclarationSyntax namespaceDeclaration1])
        {
            Assert.Fail();
            return;
        }

        SyntaxNode[] nested = namespaceDeclaration1.GetChildNodes();
        if (nested is not [IdentifierNameSyntax, NamespaceDeclarationSyntax namespaceDeclaration2])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyNamespace1", namespaceDeclaration1.Name.ToString());
        Assert.Equal("MyNamespace2", namespaceDeclaration2.Name.ToString());
    }
}

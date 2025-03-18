namespace CsmlTests;

public class ClassDeclarationTests
{
    [Fact]
    public void Single_ExectedName()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass"></Class>
                </Namespace>
            </Csml>
            """;

        // Act
        IEnumerable<SyntaxNode> output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output.ToArray() is not [NamespaceDeclarationSyntax namespaceDeclaration])
        {
            Assert.Fail();
            return;
        }

        IEnumerable<SyntaxNode> namespaceChildren = namespaceDeclaration.ChildNodes();
        if (namespaceChildren.ToArray() is not [IdentifierNameSyntax, ClassDeclarationSyntax classDeclaration])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyClass", classDeclaration.Identifier.Text);
    }

    [Fact]
    public void Multiple_ExectedNames()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClassA"></Class>
                    <Class Name="MyClassB"></Class>
                </Namespace>
            </Csml>
            """;

        // Act
        IEnumerable<SyntaxNode> output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output.ToArray() is not [NamespaceDeclarationSyntax namespaceDeclaration])
        {
            Assert.Fail();
            return;
        }

        IEnumerable<SyntaxNode> namespaceChildren = namespaceDeclaration.ChildNodes();
        if (namespaceChildren.ToArray() is not [IdentifierNameSyntax, ClassDeclarationSyntax classDeclarationA, ClassDeclarationSyntax classDeclarationB])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyClassA", classDeclarationA.Identifier.Text);
        Assert.Equal("MyClassB", classDeclarationB.Identifier.Text);
    }
}

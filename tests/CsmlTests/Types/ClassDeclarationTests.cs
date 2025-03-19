namespace CsmlTests.Types;

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
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [NamespaceDeclarationSyntax namespaceDeclaration])
        {
            Assert.Fail();
            return;
        }

        SyntaxNode[] namespaceChildren = namespaceDeclaration.GetChildNodes();
        if (namespaceChildren is not [IdentifierNameSyntax, ClassDeclarationSyntax classDeclaration])
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
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [NamespaceDeclarationSyntax namespaceDeclaration])
        {
            Assert.Fail();
            return;
        }

        SyntaxNode[] namespaceChildren = namespaceDeclaration.GetChildNodes();
        if (namespaceChildren is not [IdentifierNameSyntax, ClassDeclarationSyntax classDeclarationA, ClassDeclarationSyntax classDeclarationB])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyClassA", classDeclarationA.Identifier.Text);
        Assert.Equal("MyClassB", classDeclarationB.Identifier.Text);
    }

    [Fact]
    public void Static_Unspecified_IsNotStatic()
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
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output is not [NamespaceDeclarationSyntax namespaceDeclaration])
        {
            Assert.Fail();
            return;
        }

        SyntaxNode[] namespaceChildren = namespaceDeclaration.GetChildNodes();
        if (namespaceChildren is not [IdentifierNameSyntax, ClassDeclarationSyntax classDeclaration])
        {
            Assert.Fail();
            return;
        }

        Assert.DoesNotContain(classDeclaration.Modifiers, x => x.IsKind(SyntaxKind.StaticKeyword));
    }

    [Fact]
    public void Static_True_IsStatic()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass" Static="true"></Class>
                </Namespace>
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

        SyntaxNode[] namespaceChildren = namespaceDeclaration.GetChildNodes();
        if (namespaceChildren is not [IdentifierNameSyntax, ClassDeclarationSyntax classDeclaration])
        {
            Assert.Fail();
            return;
        }

        Assert.Contains(classDeclaration.Modifiers, x => x.IsKind(SyntaxKind.StaticKeyword));
    }

    [Fact]
    public void Static_False_IsNotStatic()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass" Static="false"></Class>
                </Namespace>
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

        SyntaxNode[] namespaceChildren = namespaceDeclaration.GetChildNodes();
        if (namespaceChildren is not [IdentifierNameSyntax, ClassDeclarationSyntax classDeclaration])
        {
            Assert.Fail();
            return;
        }

        Assert.DoesNotContain(classDeclaration.Modifiers, x => x.IsKind(SyntaxKind.StaticKeyword));
    }
}

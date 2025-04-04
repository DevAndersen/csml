﻿namespace CsmlTests.Types;

public class ClassAccessModifierTests
{
    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    [InlineData("File", SyntaxKind.FileKeyword)]
    public void AccessModifiers_ClassInsideNamespace(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass" Access="{accessText}"></Class>
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

        Assert.Equal(accessSyntaxKinds, classDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Fact]
    public void UnspecifiedAccessModifiers_ClassInsideNamespace_Internal()
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

        Assert.Equal([SyntaxKind.InternalKeyword], classDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    [InlineData("File", SyntaxKind.FileKeyword)]
    public void AccessModifiers_ClassInsideClass(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClassA">
                        <Class Name="MyClassB" Access="{accessText}"></Class>
                    </Class>
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
        if (namespaceChildren is not [IdentifierNameSyntax, ClassDeclarationSyntax outerClassDeclaration])
        {
            Assert.Fail();
            return;
        }

        SyntaxNode[] outerClassChildren = outerClassDeclaration.GetChildNodes();
        if (outerClassChildren is not [ClassDeclarationSyntax innerClassDeclaration])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, innerClassDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Fact]
    public void UnspecifiedAccessModifiers_ClassInsideClass_Private()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClassA">
                        <Class Name="MyClassB"></Class>
                    </Class>
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
        if (namespaceChildren is not [IdentifierNameSyntax, ClassDeclarationSyntax outerClassDeclaration])
        {
            Assert.Fail();
            return;
        }

        SyntaxNode[] outerClassChildren = outerClassDeclaration.GetChildNodes();
        if (outerClassChildren is not [ClassDeclarationSyntax innerClassDeclaration])
        {
            Assert.Fail();
            return;
        }

        Assert.Equal([SyntaxKind.PrivateKeyword], innerClassDeclaration.Modifiers.Select(x => x.Kind()));
    }
}

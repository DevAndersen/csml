namespace CsmlTests.Types;

public class InheritanceTests
{
    [Fact]
    public void Inheritance_HasNoInheritance_HasNoBaseList()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out ClassDeclarationSyntax? classDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Null(classDeclaration.BaseList);
    }

    [Fact]
    public void Inheritance_HasInheritance_HasBaseList()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Inheritance Type="IDisposable" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out ClassDeclarationSyntax? classDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(classDeclaration.BaseList?.Types is [
            SimpleBaseTypeSyntax { Type: IdentifierNameSyntax { Identifier.Text: "IDisposable" } }
        ]);
    }
}

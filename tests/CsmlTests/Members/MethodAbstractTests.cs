namespace CsmlTests.Members;

public class MethodAbstractTests
{
    [Fact]
    public void Abstract_Unspecified_IsNotAbstract()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Name="MyMethod" Return="void">
                        </Method>
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

        Assert.DoesNotContain(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.AbstractKeyword));
    }

    [Fact]
    public void Abstract_True_IsAbstract()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Abstract="true" Name="MyMethod" Return="void">
                        </Method>
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

        Assert.Contains(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.AbstractKeyword));
    }

    [Fact]
    public void Abstract_False_IsNotAbstract()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Abstract="false" Name="MyMethod" Return="void">
                        </Method>
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

        Assert.DoesNotContain(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.AbstractKeyword));
    }
}

namespace CsmlTests.Members;

public class MethodOverrideTests
{
    [Fact]
    public void Override_Unspecified_IsNotOverride()
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

        Assert.DoesNotContain(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.OverrideKeyword));
    }

    [Fact]
    public void Override_True_IsOverride()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Override="true" Name="MyMethod" Return="void">
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

        Assert.Contains(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.OverrideKeyword));
    }

    [Fact]
    public void Override_False_IsNotOverride()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Override="false" Name="MyMethod" Return="void">
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

        Assert.DoesNotContain(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.OverrideKeyword));
    }
}

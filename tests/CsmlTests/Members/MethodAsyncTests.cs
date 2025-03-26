namespace CsmlTests.Members;

public class MethodAsyncTests
{
    [Fact]
    public void Async_Unspecified_IsNotAsync()
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

        Assert.DoesNotContain(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.AsyncKeyword));
    }

    [Fact]
    public void Async_True_IsAsync()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Async="true" Name="MyMethod" Return="void">
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

        Assert.Contains(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.AsyncKeyword));
    }

    [Fact]
    public void Async_False_IsNotAsync()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Async="false" Name="MyMethod" Return="void">
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

        Assert.DoesNotContain(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.AsyncKeyword));
    }
}

namespace CsmlTests.Members;

public class MethodVirtualTests
{
    [Fact]
    public void Virtual_Unspecified_IsNotVirtual()
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

        Assert.DoesNotContain(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.VirtualKeyword));
    }

    [Fact]
    public void Virtual_True_IsVirtual()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Virtual="true" Name="MyMethod" Return="void">
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

        Assert.Contains(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.VirtualKeyword));
    }

    [Fact]
    public void Virtual_False_IsNotVirtual()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Virtual="false" Name="MyMethod" Return="void">
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

        Assert.DoesNotContain(methodDeclaration.Modifiers, x => x.IsKind(SyntaxKind.VirtualKeyword));
    }
}

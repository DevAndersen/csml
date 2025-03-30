namespace CsmlTests.Members;

public class MethodParameterTests
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
}

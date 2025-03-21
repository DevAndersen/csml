namespace CsmlTests.Members;

public class MethodTests
{
    [Fact]
    public void Method()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Access="Public" Return="void" Name="DoStuff" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(methodDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PublicKeyword }]);
        Assert.Equal("void", methodDeclaration.ReturnType.GetText().ToString().Trim());
        Assert.Equal("DoStuff", methodDeclaration.Identifier.Text);
    }
}

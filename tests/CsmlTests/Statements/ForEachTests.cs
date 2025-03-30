namespace CsmlTests.Statements;

public class ForEachTests
{
    [Fact]
    public void ForEachTest()
    {
        // Arrange
        string csml = """
            <ForEach Type="int" Name="number" Collection="numbers">
                <Variable Type="int" Name="valA">
                    <Expression>
                        <Value Value="number" />
                    </Expression>
                </Variable>
            </ForEach>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out MethodDeclarationSyntax? methodDeclaration))
        {
            Assert.Fail();
            return;
        }

        if (methodDeclaration.GetChildNodes() is not [.., BlockSyntax blockSyntax])
        {
            Assert.Fail();
            return;
        }

        if (blockSyntax.GetChildNodes() is not [ForEachStatementSyntax forEachSyntax])
        {
            Assert.Fail();
            return;
        }

        Assert.True(forEachSyntax.Type is PredefinedTypeSyntax { Keyword.ValueText: "int" });
        Assert.Equal("number", forEachSyntax.Identifier.ValueText);
        Assert.True(forEachSyntax.Expression is IdentifierNameSyntax { Identifier.ValueText: "numbers" });
        Assert.True(forEachSyntax.Statement is BlockSyntax { Statements: [LocalDeclarationStatementSyntax] });
    }
}

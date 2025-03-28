namespace CsmlTests.Statements;

public class ForEachTests
{
    [Fact]
    public void ForEachTest()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <ForEach Type="int" Name="number" Collection="numbers">
                                <Variable Type="int" Name="valA">
                                    <Expression>
                                        <Value Value="number" />
                                    </Expression>
                                </Variable>
                            </ForEach>
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

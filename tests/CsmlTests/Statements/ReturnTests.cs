namespace CsmlTests.Statements;

public class ReturnTests
{
    [Fact]
    public void ReturnVoid()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Return/>
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

        Assert.True(methodDeclaration.Body?.GetChildNodes() is [ReturnStatementSyntax]);
    }

    [Fact]
    public void ReturnValue()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="int" Name="DoStuff">
                            <Return Value="123"/>
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

        Assert.True(methodDeclaration.Body?.GetChildNodes() is [ReturnStatementSyntax ret]
            && ret is { Expression: LiteralExpressionSyntax
            {
                RawKind: (int)SyntaxKind.NumericLiteralExpression,
                Token.Value: 123
            }});
    }
}

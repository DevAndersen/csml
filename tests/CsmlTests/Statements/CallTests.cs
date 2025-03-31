namespace CsmlTests.Statements;

public class CallTests
{
    [Fact]
    public void Call_WithoutArguments()
    {
        // Arrange
        string csml = """
            <Call Target="System.Console" Method="WriteLine"/>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out InvocationExpressionSyntax? _))
        {
            Assert.Fail();
            return;
        }

        if (!output.FirstDescendant(out MemberAccessExpressionSyntax? methodAccess))
        {
            Assert.Fail();
            return;
        }

        if (methodAccess.Expression is not MemberAccessExpressionSyntax typeAccess)
        {
            Assert.Fail();
            return;
        }

        if (typeAccess.Expression is not IdentifierNameSyntax namespaceAccess)
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("System", namespaceAccess.Identifier.Text);
        Assert.Equal("Console", typeAccess.Name.Identifier.Text);
        Assert.Equal("WriteLine", methodAccess.Name.Identifier.Text);
    }

    [Fact]
    public void Call_WithArguments()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Statements>
                                <Call Target="System.Console" Method="WriteLine">
                                    <Argument Value="123"/>
                                </Call>
                            </Statements>
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out InvocationExpressionSyntax? invocation))
        {
            Assert.Fail();
            return;
        }

        if (!output.FirstDescendant(out MemberAccessExpressionSyntax? methodAccess))
        {
            Assert.Fail();
            return;
        }

        if (methodAccess.Expression is not MemberAccessExpressionSyntax typeAccess)
        {
            Assert.Fail();
            return;
        }

        if (typeAccess.Expression is not IdentifierNameSyntax namespaceAccess)
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("System", namespaceAccess.Identifier.Text);
        Assert.Equal("Console", typeAccess.Name.Identifier.Text);
        Assert.Equal("WriteLine", methodAccess.Name.Identifier.Text);
        Assert.True(invocation.ArgumentList.Arguments is [ArgumentSyntax { Expression: LiteralExpressionSyntax expression }]
            && expression.Token is { Value: 123 });
    }

    [Fact]
    public void Call_WithoutTarget()
    {
        // Arrange
        string csml = """
            <Call Method="MyMethod"/>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out InvocationExpressionSyntax? invocation))
        {
            Assert.Fail();
            return;
        }

        if (output.FirstDescendant(out MemberAccessExpressionSyntax? _))
        {
            Assert.Fail();
            return;
        }

        Assert.True(invocation.Expression is IdentifierNameSyntax { Identifier.Value: "MyMethod" });
    }
}

namespace CsmlTests.Statements;

public class SwitchTests
{
    [Fact]
    public void SwitchTest()
    {
        // Arrange
        string csml = """
            <Switch Value="myNumber">
                <Case Value="1">
                    <Break />
                </Case>
                <Case Value="2">
                    <Break />
                </Case>
                <Default>
                    <Break />
                </Default>
            </Switch>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(CsmlSyntaxWrapper.WrapInMethod(csml));

        // Assert
        if (!output.FirstDescendant(out SwitchStatementSyntax? switchStatement))
        {
            Assert.Fail();
            return;
        }

        if (switchStatement.Sections is not [SwitchSectionSyntax case1, SwitchSectionSyntax case2, SwitchSectionSyntax case3])
        {
            Assert.Fail();
            return;
        }

        Assert.True(switchStatement.Expression is IdentifierNameSyntax { Identifier.Value: "myNumber" });

        Assert.True(case1.Labels is [CaseSwitchLabelSyntax { Value: LiteralExpressionSyntax { Token.Value: 1 } }]);
        Assert.True(case2.Labels is [CaseSwitchLabelSyntax { Value: LiteralExpressionSyntax { Token.Value: 2 } }]);
        Assert.True(case3.Labels is [DefaultSwitchLabelSyntax]);
    }
}

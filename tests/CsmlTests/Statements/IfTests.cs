using CsmlTests.Helpers;

namespace CsmlTests.Statements;

public class IfTests
{
    [Fact]
    public void IfTest()
    {
        // Arrange
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Return="void" Name="DoStuff">
                            <Call Target="System.Console" Method="WriteLine" />
                            <If Left="true" Comparison="Equal" Right="false">
                                <Variable Type="int" Name="valA" Value="1" />
                            </If>
                            <ElseIf Left="false" Comparison="Equal" Right="true">
                                <Variable Type="int" Name="valA" Value="2" />
                            </ElseIf>
                            <Else>
                                <Variable Type="int" Name="valA" Value="3" />
                            </Else>
                            <Call Target="System.Console" Method="WriteLine" />
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

        if (blockSyntax.GetChildNodes() is not [
            ExpressionStatementSyntax,
            IfStatementSyntax ifStatement,
            ExpressionStatementSyntax])
        {
            Assert.Fail();
            return;
        }
    }
}

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

                            <If>
                                <Expression>
                                    <Equals>
                                        <Left>
                                            <Value Value="true" />
                                        </Left>
                                        <Right>
                                            <Value Value="false" />
                                        </Right>
                                    </Equals>
                                </Expression>
                                <Statements>
                                    <Variable Type="int" Name="valA">
                                        <Expression>
                                            <Value Value="1" />
                                        </Expression>
                                    </Variable>
                                </Statements>
                            </If>
                            <ElseIf>
                                <Expression>
                                    <Equals>
                                        <Left>
                                            <Value Value="false" />
                                        </Left>
                                        <Right>
                                            <Value Value="true" />
                                        </Right>
                                    </Equals>
                                </Expression>
                                <Statements>
                                    <Variable Type="int" Name="valA">
                                        <Expression>
                                            <Value Value="1" />
                                        </Expression>
                                    </Variable>
                                </Statements>
                            </ElseIf>
                            <Else>
                                <Variable Type="int" Name="valA">
                                    <Expression>
                                        <Value Value="3" />
                                    </Expression>
                                </Variable>
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
            IfStatementSyntax,
            ExpressionStatementSyntax])
        {
            Assert.Fail();
            return;
        }
    }
}

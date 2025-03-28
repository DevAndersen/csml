namespace CsmlTests.Operators;

public class OperatorTests
{
    [Fact]
    public void OperatorTest()
    {
        string csml = """
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Name="MyMethod" Return="void">

                            <Variable Type="int" Name="myNumber">
                                <Expression>
                                    <Value Value="123" />
                                </Expression>
                            </Variable>

                            <Increment Target="myNumber" />

                            <If>
                                <Expression>
                                    <Value Value="true" />
                                </Expression>
                                <Statements>
                                </Statements>
                            </If>

                            <If>
                                <Expression>
                                    <Equals>
                                        <Left>
                                            <Value Value="1" />
                                        </Left>
                                        <Right>
                                            <Value Value="2" />
                                        </Right>
                                    </Equals>
                                </Expression>
                                <Statements>
                                    <Call Target="System.Console" Method="WriteLine" />
                                </Statements>
                            </If>
                            <ElseIf>
                                <Expression>
                                    <LessThanOrEqual>
                                        <Left>
                                            <Increment Target="myNumber" />
                                        </Left>
                                        <Right>
                                            <Value Value="2" />
                                        </Right>
                                    </LessThanOrEqual>
                                </Expression>
                                <Statements>
                                    <Call Target="System.Console" Method="WriteLine" />
                                </Statements>
                            </ElseIf>
                            <Else>
                                <Call Target="System.Console" Method="WriteLine" />
                            </Else>

                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert

        string str = output.First().ToString();
    }
}

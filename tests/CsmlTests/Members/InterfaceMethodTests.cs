namespace CsmlTests.Members;

public class InterfaceMethodTests
{
    [Fact]
    public void MethodOnInterface_NoDefaultImplementation_MethodHasNoBody()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Interface Name="IMyInterface">
                        <Method Return="void" Name="DoStuff">
                        </Method>
                    </Interface>
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

        Assert.Null(methodDeclaration.Body);
    }

    [Fact]
    public void MethodOnInterface_HasDefaultImplementation_MethodHasBody()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Interface Name="IMyInterface">
                        <Method Return="void" Name="DoStuff">
                            <Variable Type="int" Name="number">
                                <Expression>
                                    <Value Value="2" />
                                </Expression>
                            </Variable>
                        </Method>
                    </Interface>
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

        Assert.NotNull(methodDeclaration.Body);
    }
}

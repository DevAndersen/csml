namespace CsmlTests.Members;

public class ConstructorTests
{
    [Fact]
    public void Constructor_NoConstructor_HasNoConstructor()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (output.FirstDescendant(out ConstructorDeclarationSyntax? constructorDeclaration))
        {
            Assert.Fail();
            return;
        }
    }

    [Fact]
    public void Constructor_NoParameters_HasNoParameters()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Constructor>
                        </Constructor>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out ConstructorDeclarationSyntax? constructorDeclaration)
            || constructorDeclaration.Body == null)
        {
            Assert.Fail();
            return;
        }

        Assert.Empty(constructorDeclaration.Body.Statements);
        Assert.Empty(constructorDeclaration.ParameterList.Parameters);
    }

    [Fact]
    public void Constructor_WithParameter_HasParameters()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Constructor>
                            <Parameter Type="int" Name="number" />
                        </Constructor>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out ConstructorDeclarationSyntax? constructorDeclaration)
            || constructorDeclaration.Body == null)
        {
            Assert.Fail();
            return;
        }

        Assert.Empty(constructorDeclaration.Body.Statements);
        Assert.True(constructorDeclaration.ParameterList.Parameters is [ParameterSyntax]);
    }

    [Fact]
    public void Constructor_WithStatements_HasBody()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Constructor>
                            <Parameter Type="int" Name="number" />
                            <Statements>
                                <Call Target="System.Console" Method="WriteLine" />
                            </Statements>
                        </Constructor>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out ConstructorDeclarationSyntax? constructorDeclaration)
            || constructorDeclaration.Body == null)
        {
            Assert.Fail();
            return;
        }

        Assert.True(constructorDeclaration.Body.Statements is [StatementSyntax]);
        Assert.True(constructorDeclaration.ParameterList.Parameters is [ParameterSyntax]);
    }
}

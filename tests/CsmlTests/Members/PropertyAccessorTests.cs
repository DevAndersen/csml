using CsmlTests.Helpers;

namespace CsmlTests.Members;

public class PropertyAccessorTests
{
    [Fact]
    public void GetSet()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Property Name="MyProperty" Type="int" Getter="Get" Setter="Set" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out PropertyDeclarationSyntax? propertyDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyProperty", propertyDeclaration.Identifier.Text);
        Assert.Equal("int", propertyDeclaration.Type.GetText().ToString().Trim());

        Assert.True(propertyDeclaration.AccessorList?.Accessors is [
            AccessorDeclarationSyntax { Keyword.Text: "get" },
            AccessorDeclarationSyntax { Keyword.Text: "set" }]);
    }

    [Fact]
    public void Get()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Property Name="MyProperty" Type="int" Getter="Get" />
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out PropertyDeclarationSyntax? propertyDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyProperty", propertyDeclaration.Identifier.Text);
        Assert.Equal("int", propertyDeclaration.Type.GetText().ToString().Trim());

        Assert.True(propertyDeclaration.AccessorList?.Accessors is [
            AccessorDeclarationSyntax { Keyword.Text: "get" }]);
    }

    [Fact]
    public void GetInit()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Property Name="MyProperty" Type="int" Getter="Get" Setter="Init">
                        </Property>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out PropertyDeclarationSyntax? propertyDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal("MyProperty", propertyDeclaration.Identifier.Text);
        Assert.Equal("int", propertyDeclaration.Type.GetText().ToString().Trim());

        Assert.True(propertyDeclaration.AccessorList?.Accessors is [
            AccessorDeclarationSyntax { Keyword.Text: "get" },
            AccessorDeclarationSyntax { Keyword.Text: "init" }]);
    }
}

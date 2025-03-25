namespace CsmlTests.Types;

public class StructReadOnlyTests
{
    [Fact]
    public void ReadOnly_NotSpecified_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out StructDeclarationSyntax? structDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(structDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.InternalKeyword }]);
    }

    [Fact]
    public void ReadOnly_True_IsConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct ReadOnly="true" Name="MyStruct">
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out StructDeclarationSyntax? structDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(structDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.InternalKeyword }, SyntaxToken { RawKind: (int)SyntaxKind.ReadOnlyKeyword }]);
    }

    [Fact]
    public void ReadOnly_False_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct ReadOnly="false" Name="MyStruct">
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out StructDeclarationSyntax? structDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(structDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.InternalKeyword }]);
    }
}

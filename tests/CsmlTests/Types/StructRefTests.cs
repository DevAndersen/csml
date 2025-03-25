namespace CsmlTests.Types;

public class StructRefTests
{
    [Fact]
    public void Ref_NotSpecified_IsNotConst()
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
    public void Ref_True_IsConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Ref="true" Name="MyStruct">
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

        Assert.True(structDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.InternalKeyword }, SyntaxToken { RawKind: (int)SyntaxKind.RefKeyword }]);
    }

    [Fact]
    public void Ref_False_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Ref="false" Name="MyStruct">
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

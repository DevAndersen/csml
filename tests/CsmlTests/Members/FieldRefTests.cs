namespace CsmlTests.Members;

public class FieldRefTests
{
    [Fact]
    public void Ref_NotSpecified_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                        <Field Name="myField" Type="int" />
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out FieldDeclarationSyntax? fieldDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.IsNotType<RefTypeSyntax>(fieldDeclaration.Declaration.Type);
    }

    [Fact]
    public void Ref_True_IsConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                        <Field Ref="true" Name="myField" Type="int" />
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out FieldDeclarationSyntax? fieldDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.IsType<RefTypeSyntax>(fieldDeclaration.Declaration.Type);
    }

    [Fact]
    public void Ref_False_IsNotConst()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                        <Field Ref="false" Name="myField" Type="int" />
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out FieldDeclarationSyntax? fieldDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.IsNotType<RefTypeSyntax>(fieldDeclaration.Declaration.Type);
    }
}

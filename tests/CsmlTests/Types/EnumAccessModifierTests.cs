namespace CsmlTests.Types;

public class EnumAccessModifierTests
{
    [Fact]
    public void EnumInsideNamespace_UnspecifiedAccessModifiers_IsInternal()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Enum Name="MyEnum">
                    </Enum>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(enumDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.InternalKeyword }]);
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    [InlineData("File", SyntaxKind.FileKeyword)]
    public void EnumInsideNamespace_SpecifiedAccessModifiers_ExpectedAccessModifiers(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Enum Access="{accessText}" Name="MyEnum">
                    </Enum>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, enumDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Fact]
    public void EnumInsideClass_UnspecifiedAccessModifiers_IsPrivate()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Enum Name="MyEnum">
                        </Enum>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(enumDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }]);
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    public void EnumInsideClass_SpecifiedAccessModifiers_ExpectedAccessModifiers(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Enum Access="{accessText}" Name="MyEnum">
                        </Enum>
                    </Class>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, enumDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Fact]
    public void EnumInsideStruct_UnspecifiedAccessModifiers_IsPrivate()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                        <Enum Name="MyEnum">
                        </Enum>
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(enumDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PrivateKeyword }]);
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    public void EnumInsideStruct_SpecifiedAccessModifiers_ExpectedAccessModifiers(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Struct Name="MyStruct">
                        <Enum Access="{accessText}" Name="MyEnum">
                        </Enum>
                    </Struct>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, enumDeclaration.Modifiers.Select(x => x.Kind()));
    }

    [Fact]
    public void EnumInsideInterface_UnspecifiedAccessModifiers_IsPublic()
    {
        // Arrange
        string csml = """
            <Csml>
                <Namespace Name="MyNamespace">
                    <Interface Name="IMyInterface">
                        <Enum Name="MyEnum">
                        </Enum>
                    </Interface>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.True(enumDeclaration.Modifiers is [SyntaxToken { RawKind: (int)SyntaxKind.PublicKeyword }]);
    }

    [Theory]
    [InlineData("Public", SyntaxKind.PublicKeyword)]
    [InlineData("Private", SyntaxKind.PrivateKeyword)]
    [InlineData("Protected", SyntaxKind.ProtectedKeyword)]
    [InlineData("Internal", SyntaxKind.InternalKeyword)]
    [InlineData("ProtectedInternal", SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword)]
    [InlineData("PrivateProtected", SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword)]
    public void EnumInsideInterface_SpecifiedAccessModifiers_ExpectedAccessModifiers(string accessText, params SyntaxKind[] accessSyntaxKinds)
    {
        // Arrange
        string csml = $"""
            <Csml>
                <Namespace Name="MyNamespace">
                    <Interface Name="IMyInterface">
                        <Enum Access="{accessText}" Name="MyEnum">
                        </Enum>
                    </Interface>
                </Namespace>
            </Csml>
            """;

        // Act
        SyntaxNode[] output = AssertCompileNoDiagnostics(csml);

        // Assert
        if (!output.FirstDescendant(out EnumDeclarationSyntax? enumDeclaration))
        {
            Assert.Fail();
            return;
        }

        Assert.Equal(accessSyntaxKinds, enumDeclaration.Modifiers.Select(x => x.Kind()));
    }
}

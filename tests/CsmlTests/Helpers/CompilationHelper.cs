using Csml.Generator;
using Microsoft.CodeAnalysis.Text;
using System.Reflection;

namespace CsmlTests.Helpers;

internal static class CompilationHelper
{
    /// <summary>
    /// Compiles <paramref name="csml"/>, and asserts that no diagnostics were emitted.
    /// </summary>
    /// <param name="csml"></param>
    /// <returns></returns>
    public static SyntaxNode[] AssertCompileNoDiagnostics(string csml)
    {
        SyntaxNode[] output = Compile(csml, out ImmutableArray<Diagnostic> diagnostics, null);
        Assert.Empty(diagnostics);
        return output;
    }

    /// <summary>
    /// Compiles <paramref name="csml"/>, returning the compiled result and any potential <paramref name="diagnostics"/>.
    /// </summary>
    /// <param name="csml"></param>
    /// <param name="diagnostics"></param>
    /// <returns></returns>
    public static SyntaxNode[] Compile(
        string csml,
        out ImmutableArray<Diagnostic> diagnostics,
        string? fileName = null)
    {
        Compilation compilationInput = CSharpCompilation.Create(null,
            [],
            [MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location)],
            new CSharpCompilationOptions(OutputKind.ConsoleApplication));

        FakeAdditionalText fake = new FakeAdditionalText(csml, fileName);
        CsmlGenerator generator = new CsmlGenerator();

        GeneratorDriver driver = CSharpGeneratorDriver
            .Create(generator)
            .AddAdditionalTexts([fake]);

        driver.RunGeneratorsAndUpdateCompilation(
            compilationInput,
            out Compilation compilationOutput,
            out diagnostics);

        if (compilationOutput.SyntaxTrees.FirstOrDefault()?.GetRoot() is CompilationUnitSyntax unit)
        {
            return unit.GetChildNodes();
        }

        return [];
    }

    /// <summary>
    /// Fake for an <see cref="AdditionalText"/>.
    /// </summary>
    private class FakeAdditionalText : AdditionalText
    {
        private readonly string _text;
        private readonly string _path;

        public override string Path => _path;

        public FakeAdditionalText(string text, string? fileName = null)
        {
            _text = text;
            _path = fileName ?? $"SourceFile.c♯";
        }

        public override SourceText? GetText(CancellationToken cancellationToken = default)
        {
            return SourceText.From(_text);
        }
    }
}

using Csml.Generator;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Immutable;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CsmlTests;

internal static class CompilationHelper
{
    /// <summary>
    /// Compiles <paramref name="csml"/>, and asserts that no diagnostics were emitted.
    /// </summary>
    /// <param name="csml"></param>
    /// <returns></returns>
    public static IEnumerable<SyntaxNode> AssertCompileNoDiagnostics(string csml)
    {
        IEnumerable<SyntaxNode> output = AssertCompile(csml, out ImmutableArray<Diagnostic> diagnostics);
        Assert.Empty(diagnostics);
        return output;
    }

    /// <summary>
    /// Compiles <paramref name="csml"/>, returning the compiled result and any potential <paramref name="diagnostics"/>.
    /// </summary>
    /// <param name="csml"></param>
    /// <param name="diagnostics"></param>
    /// <returns></returns>
    public static IEnumerable<SyntaxNode> AssertCompile(string csml, out ImmutableArray<Diagnostic> diagnostics)
    {
        Compilation compilationInput = CSharpCompilation.Create(null,
            [],
            [MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location)],
            new CSharpCompilationOptions(OutputKind.ConsoleApplication));

        FakeAdditionalText fake = new FakeAdditionalText(csml);
        CsmlGenerator generator = new CsmlGenerator();

        GeneratorDriver driver = CSharpGeneratorDriver
            .Create(generator)
            .AddAdditionalTexts([fake]);

        driver = driver.RunGeneratorsAndUpdateCompilation(
            compilationInput,
            out Compilation compilationOutput,
            out diagnostics);

        Assert.Single(compilationOutput.SyntaxTrees);
        SyntaxTree tree = compilationOutput.SyntaxTrees.First();

        if (tree.GetRoot() is CompilationUnitSyntax unit)
        {
            return unit.ChildNodes();
        }

        Assert.Fail($"Syntax tree root node was {tree.GetRoot().GetType().FullName}, expected {nameof(CompilationUnitSyntax)}");
        return default;
    }

    /// <summary>
    /// Fake for an <see cref="AdditionalText"/>.
    /// </summary>
    private class FakeAdditionalText : AdditionalText
    {
        private readonly string _text;
        private readonly string _path;

        public override string Path => _path;

        public FakeAdditionalText(string text, string? fileName = null, [CallerMemberName] string callerMemberName = "")
        {
            _text = text;
            _path = fileName ?? $"{callerMemberName}.c♯";
        }

        public override SourceText? GetText(CancellationToken cancellationToken = default)
        {
            return SourceText.From(_text);
        }
    }
}

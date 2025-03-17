using Csml.Generator.SyntaxBuilders;
using Csml.Parser;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;

namespace Csml.Generator;

[Generator(LanguageNames.CSharp)]
internal class CsmlGenerator : IIncrementalGenerator
{
    private const string _preferredFileExtension = ".c♯";

    private static readonly string[] _validFileExtensions =
    [
        _preferredFileExtension,
        ".c#",
        ".csml",
    ];

    public void Initialize(IncrementalGeneratorInitializationContext generatorContext)
    {
        IncrementalValuesProvider<CsmlSourceFile> sourceFiles = generatorContext.AdditionalTextsProvider
            .Select(ValidateSourceFile)
            .Where(x => x != null)!;

        generatorContext.RegisterSourceOutput(sourceFiles, (context, sourceFile) =>
        {
            if (!Debugger.IsAttached)
            {
                //Debugger.Launch();
            }

            if (sourceFile.FileExtension != _preferredFileExtension)
            {
                context.ReportDiagnostic(Diagnostic.Create(GeneratorDiagnostics.HastagFileExtension, Location.None));
            }

            CsmlParseResult result = CsmlParser.Parse(sourceFile.FileContent);

            if (result is { Result: not null, Errors.Count: 0 })
            {
                CompilationUnitSyntax syntax = CsmlBuilder.Build(result.Result!);
                SyntaxTree syntaxTree = SyntaxFactory.SyntaxTree(syntax, encoding: System.Text.Encoding.Unicode);

                context.AddSource($"{sourceFile.FileName}.g.cs", syntaxTree.GetText());
            }

            foreach (CsmlParseError error in result.Errors)
            {
                Location location;
                if (error.LineNumber == null)
                {
                    location = Location.None;
                }
                else
                {
                    LinePositionSpan linePositionSpan = new LinePositionSpan(
                        new LinePosition(error.LineNumber.Value - 1, 0),
                        new LinePosition(error.LineNumber.Value - 1, 0)
                    );

                    location = Location.Create(
                        sourceFile.FullFileName,
                        default,
                        linePositionSpan);
                }

                context.ReportDiagnostic(Diagnostic.Create(
                    GeneratorDiagnostics.ParseError,
                    location,
                    [error.Message]));
            }
        });
    }

    public static bool IsValidSourceFile(string path)
    {
        return _validFileExtensions.Contains(Path.GetExtension(path), StringComparer.OrdinalIgnoreCase);
    }

    private CsmlSourceFile? ValidateSourceFile(AdditionalText additionalText, CancellationToken cancellationToken)
    {
        string fileName = Path.GetFileNameWithoutExtension(additionalText.Path);
        string fileExtension = Path.GetExtension(additionalText.Path);

        if (_validFileExtensions.Contains(Path.GetExtension(fileExtension), StringComparer.OrdinalIgnoreCase))
        {
            string? fileContent = additionalText.GetText(cancellationToken)?.ToString();

            if (!string.IsNullOrWhiteSpace(fileContent))
            {
                return new CsmlSourceFile(
                    additionalText.Path,
                    fileName,
                    fileExtension,
                    fileContent!);
            }
        }

        return null;
    }

    private record CsmlSourceFile(
        string FullFileName,
        string FileName,
        string FileExtension,
        string FileContent);
}

using Csml.Exceptions;
using Csml.Generator.SyntaxBuilders;
using Csml.Parser;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace Csml.Generator;

/// <summary>
/// The C♯ML source generator.
/// Contains base logic for detecting C♯ML source files, attempting to invoke the parser and builder, and emitting diagnostics.
/// </summary>
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
            if (sourceFile.FileExtension != _preferredFileExtension)
            {
                context.ReportDiagnostic(Diagnostic.Create(CsmlDiagnostics.NotPreferredFileExtension, Location.None));
            }

            CsmlParseResult result = CsmlParser.Parse(sourceFile.FileContent);

            if (result is { Result: not null, Errors.Count: 0 })
            {
                try
                {
                    CompilationUnitSyntax syntax = CsmlBuilder.Build(result.Result);
                    SyntaxTree syntaxTree = SyntaxFactory.SyntaxTree(syntax, encoding: Encoding.Unicode);

                    context.AddSource($"{sourceFile.FileName}.g.cs", syntaxTree.GetText());
                }
                catch (InvalidAccessorException invalidAccessorException)
                {
                    result.Errors.Add(new CsmlParseError(
                        CsmlDiagnostics.InvalidAccessor,
                        invalidAccessorException.LineNumber,
                        [invalidAccessorException.AccessModifiers.ToString(), invalidAccessorException.Target]));
                }
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
                        new LinePosition(error.LineNumber.Value, 0),
                        new LinePosition(error.LineNumber.Value, 0)
                    );

                    location = Location.Create(
                        sourceFile.FullFileName,
                        default,
                        linePositionSpan);
                }

                context.ReportDiagnostic(Diagnostic.Create(
                    error.Descriptor,
                    location,
                    error.Arguments));
            }
        });
    }

    /// <summary>
    /// Validates that <paramref name="additionalText"/> represents a valid C♯ML source file.
    /// </summary>
    /// <param name="additionalText"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Represents the values of interest for a C♯ML source file.
    /// </summary>
    /// <param name="FullFileName"></param>
    /// <param name="FileName"></param>
    /// <param name="FileExtension"></param>
    /// <param name="FileContent"></param>
    private record CsmlSourceFile(
        string FullFileName,
        string FileName,
        string FileExtension,
        string FileContent);
}

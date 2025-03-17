using Csml.Generator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CsmlTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var xml = """
            <?xml version="1.0" encoding="utf-8" ?>
            <Csml>

            	<UsingDirective Namespace="System" />
            	<UsingDirective Namespace="System.Text.Json" />

            	<Namespace Name="MyNamespace">
            		<UsingDirective Namespace="System.Text" />
            		<Namespace Name="Nested">

            			<Class Name="NestedClass">

            			</Class>

            		</Namespace>

            		<Class Name="MyClass">

                  <Property Name="Number" Access="Public" Accessors="GetSet" Type="int" />

            		</Class>

            		<Struct Name="MyStruct" Access="Internal">

            		</Struct>

            		<Interface Name="IClass" Access="Public">

            		</Interface>

            	</Namespace>

            </Csml>

            """;

        FakeAdditionalText fake = new FakeAdditionalText(xml);
        Compilation inputCompilation = CreateCompilation();
        CsmlGenerator generator = new CsmlGenerator();

        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);
        driver = driver.AddAdditionalTexts([fake]);
        driver = driver.RunGeneratorsAndUpdateCompilation(
            inputCompilation,
            out Compilation? outputCompilation,
            out System.Collections.Immutable.ImmutableArray<Diagnostic> diagnostics);

        GeneratorDriverRunResult runResult = driver.GetRunResult();

        Debug.Assert(runResult.GeneratedTrees.Length == 1);
        Debug.Assert(runResult.Diagnostics.IsEmpty);

        GeneratorRunResult generatorResult = runResult.Results[0];
        Debug.Assert(generatorResult.Diagnostics.IsEmpty);
        Debug.Assert(generatorResult.GeneratedSources.Length == 1);
        Debug.Assert(generatorResult.Exception is null);
    }

    private static CSharpCompilation CreateCompilation()
    {
        return CSharpCompilation.Create(null,
            [],
            [MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location)],
            new CSharpCompilationOptions(OutputKind.ConsoleApplication));
    }

    internal class FakeAdditionalText : AdditionalText
    {
        private readonly string _text;
        private readonly string _callerMemberName;

        public override string Path => $"{_callerMemberName}.c♯";

        public FakeAdditionalText(string text, [CallerMemberName] string callerMemberName = "")
        {
            _text = text;
            _callerMemberName = callerMemberName;
        }

        public override SourceText? GetText(CancellationToken cancellationToken = default)
        {
            return SourceText.From(_text);
        }
    }
}

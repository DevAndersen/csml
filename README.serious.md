# Readme, serious edition

This project is, of course, not to be taken serious. It is, however, functional in accordance with [the technical documentation](./documentation/README.md).

The primary purpose of this project was to give me an excuse to start looking into source generators.

The secondary purpose was to be fun and silly. Hopefully, the fairly absurd idea of writing C# in XML will provide a bit of entertainment for anyone reading this.

## Conclusions and takeaways

### Using tests to debug source generators

Debugging source generators can be quite the tedious process.

As the source generator is executed before the application starts, you have to attach the debugger via something like [`Debugger.Launch()`](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.debugger.launch) in order to debug it.

When using Visual Studio, this means you also have to deal with the debugger attachment windows popping up, which it sometimes does multiple times. This is not detrimental to development, thought it quickly becomes a point of friction.

A far less frustrating approach to debugging a source generator is by using tests which directly invoke the source generator. This way, debugging a test will hit breakpoints within the source generator, making for a much nicer debugging experience.

It should be noted that the tests in this repository are not meant to cover all scenarios, just the ones that came to mind while designing functionality. Furthermore, the tests are not necessarily written well or in accordance with best practices. They and were largely written after the code they test, in order to raise flags when functionality would break during development.

### Building C# syntax trees gets rather lengthy

This seems fairly obvious in hindsight, but manually typing out the structure of a [C# syntax tree](https://learn.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/get-started/syntax-analysis) using the [`SyntaxFactory`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntaxfactory) class can be quite the task.

Even simple parts of the language boil down to a number of parts which needs to be put together, and while this isn't necessarily difficult or complicated once you get the hang of it, it does require quite a bit of code.

[KirillOsenkov](https://github.com/KirillOsenkov)'s [RoslynQuoter](https://roslynquoter.azurewebsites.net/) ([repo](https://github.com/KirillOsenkov/RoslynQuoter)) was of great help in getting things working, as it allows you to simply paste in a block of C# code, and the site will generate analyzer code that can build the C# code using the `SyntaxFactory` class.

### Targeting .NET Standard 2.0

Supposedly in order to make them run properly with Visual Studio, source generators must target .NET Standard 2.0.

This imposes a number of limtations in regards to which .NET APIs and C# language features are available, which can feel somewhat limiting to work with if you are used to having access to newer runtime- and language versions.

Luckily, as a good number of C#'s language features do not actually require a correspondingly new runtimes to work, simply [changing the language version in the `.csproj` file](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version) will give you access to a large number of these.

Other language features can be a bit more tricky. For exmaple, the [`required`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required) and [`init`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/init) keywords rely on certain types existing. These limitations can be worked around by manually defining the missing types. This is of course a hacky way of doing things, but it does work for certain features. See [Workaround.cs](./src/Csml/Workarounds.cs) for examples.

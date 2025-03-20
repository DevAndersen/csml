# C♯ML - The C# Markup Language

**Write C# code in XML**

## Introduction

C♯ML is a programming language designed to provide the functionality of C#, through the powerful syntax of XML.

Unlike C#, which derives its syntax from C, C♯ML leverages the powerful syntax of XML. This allows for more expressive code, without getting bogged down by the semantic idiosyncrasies of the C language family.

C♯ML uses a [.NET source generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/), which builds the C♯ML source files as the code gets written, allowing seamless interoperability between C♯ML and C#. This allows development teams of all sizes to smoothly transition their code from C# to C♯ML, one file at a time, without interrupting product delivery.

C♯ML also addresses C#'s misleading name. While it is pronounced "C sharp", it does not actually use the sharp sign (`♯`), but instead inappropriately uses a number sign (aka. hash- or pound sign) (`#`). C♯ML improves upon C# in this regard, by correctly using the sharp sign.

## Usage guide

C♯ML source files use the `.C♯` file extension. That is the letter `C` followed by the sharp sign (`♯`, unicode character DEC `9839`, HEX `266F`). Alternatively, the `.C#` and `.CSML` file extensions can also be used, however using these will result in a warning, as these file extensions are considered misleading.

In order to get C♯ML source files working, they need to be added as an "additional file".

**Note:** As IDEs such as Visual Studio and Rider have yet to add syntax highlight for C♯ML, it is recommended that you add the following at the beginning of the source files:

    <?xml version="1.0" encoding="utf-8" ?>

[WORK IN PROGRESS]

## Code examples

[WORK IN PROGRESS]

## Q & A

**Q:** Why?

- **A:** [WORK IN PROGRESS]

**Q:** Why does *[insert C# functionality]* not work?

- **A:** A lot of C# functionality can be considered syntactic sugar; it's a sweeter way of doing something that can already be done. However, as too much sugar can be damaging to your health, C♯ML made the bold decision to cut down on sugar. Consider it a healthy alternative to sugary C#.

**Q:** Does this really qualify as a programming language? It's just an XML parser and a source generator.

- **A:** The question of what constitutes a programming language has been the source of much debate in the software development community. C# itself is traditionally compiled to CIL, which itself traditionally gets JIT-compiled into native code at runtime. I say we give C♯ML the benefit of the doubt, and consider it a programming language until proven otherwise.

## Special thanks to

- The authors of the [Incremental Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.cookbook.md), for descriptions and examples for writing source generators.
- [KirillOsenkov](https://github.com/KirillOsenkov), for their excellent [RoslynQuoter](https://roslynquoter.azurewebsites.net/) ([repo](https://github.com/KirillOsenkov/RoslynQuoter)). This tool has been a great help in discovering how to structure C# syntax trees.

## License

C♯ML is licensed under the [MIT license](/LICENSE).

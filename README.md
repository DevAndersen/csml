# C♯ML - The C# Markup Language

```xml
<Csml>
  <Namespace Name="HelloWorld">
    <Class Static="true" Name="Program">
      <Method Access="Public" Static="true" Return="void" Name="Main">
        <Statements>
          <Call Target="Console" Method="WriteLine">
            <Argument Value='"Hello, World!"' />
          </Call>
        </Statements>
      </Method>
    </Class>
  </Namespace>
</Csml>
```

*"Hello, World!" in C♯ML*

## Introduction

C♯ML is a programming language designed to provide the functionality of C#, through the powerful syntax of XML.

Unlike C#, which derives its syntax from C, C♯ML leverages the powerful syntax of XML. This allows for more expressive code, without getting bogged down by the semantic idiosyncrasies of the C language family.

C♯ML supports seamless interoperability with C# code. This allows development teams of all sizes to smoothly transition their code from C# to C♯ML, one file at a time, without interrupting product delivery. This is achieved via the C♯ML [source generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/).

Furthermore, C♯ML improves upon C# in naming. While C# is pronounced "C sharp", it does not actually use the sharp sign (`♯`), but instead inappropriately uses a number sign (`#`, aka. hash- or pound sign). C♯ML correctly using the sharp sign, both in its name and the file extension of its source files.

## Usage guide

C♯ML source files use the `.C♯` file extension. That is the letter `C` followed by the sharp sign (`♯`, unicode character DEC `9839`, HEX `266F`). Alternatively, the `.C#` and `.CSML` file extensions can also be used, however using these will result in an analyzer warning, as these file extensions are considered misleading.

In order to get C♯ML source files working, they need to be added to your `.csproj` as "additional files". This can be done either by manually editing the `.csproj` file, or by using your IDE of choice.

```xml
  <ItemGroup>
    <AdditionalFiles Include="Filename.c♯" />
  </ItemGroup>
```

**Note:** IDEs such as Visual Studio and Rider have yet to add syntax highlight for C♯ML, and it is therefore recommended that you add the following at the beginning of the source files:

```xml
<?xml version="1.0" encoding="utf-8" ?>
```

## Demos

- [Sandbox](./demos/Sandbox/README.md)
- [Hello, World!](./demos/HelloWorld/README.md)
- [FizzBuzz](./demos/FizzBuzz/README.md)
- [WebAPI](./demos/WebAPI/README.md)

## Documentation

For full technical documentation, see: [Technical documentation](./documentation/README.md)

## Q & A

**Q:** Why?

- **A:** Software development isn't about "*Why?*", it's about "*Why not?*".

**Q:** Why are some C# language features not supported?

- **A:** A lot of C# functionality can be considered syntactic sugar; it's a sweeter way of doing something that can already be done. However, as too much sugar can be damaging to your health, C♯ML made the bold decision to cut down on sugar. Consider it a healthy alternative to sugary C#.

**Q:** Does this really qualify as a programming language? It's just an XML parser and a source generator.

- **A:** The question of what constitutes a programming language has been the source of much debate in the software development community. C# itself is traditionally compiled to CIL, which itself traditionally gets JIT-compiled into native code at runtime. This is quite similar to how C♯ML works, from a certain point of view. I say we give C♯ML the benefit of the doubt, and consider it a programming language until proven otherwise.

**Q:** Why does C♯ML successfully building C# code that does not compile?

- **A:** While C♯ML will provide analyzer warnings and errors for broken syntax, it is designed to be flexible and future-proof, and therefore does not perform strict compilability validation. Ultimately, the responsibility for writing code correctly lies with the developer, not the language or associated tooling.

## Special thanks to

- The authors of the [Incremental Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.cookbook.md), for descriptions and examples for writing source generators.
- [KirillOsenkov](https://github.com/KirillOsenkov), for their excellent [RoslynQuoter](https://roslynquoter.azurewebsites.net/) ([repo](https://github.com/KirillOsenkov/RoslynQuoter)). This tool has been a great help in discovering how to structure C# syntax trees.

## License

C♯ML is licensed under the [MIT license](/LICENSE).

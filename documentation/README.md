# Technical documentation

## General

While tags and attributes are case-insensitive, the value of attributes is case sensitive.

## Tags

Below is a table of C♯ML tags, as well as their corresponding C# equivalent.

| C♯ML | C# |
|---|---|
| [`<Add>`](./tags/add.md) | [`+`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#addition-operator-) |
| [`<And>`](./tags/and.md) | [`&&`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#conditional-logical-and-operator-) |
| [`<Argument>`](./tags/argument.md) | Method argument (method invocation) |
| [`<Assignment>`](./tags/assignment.md) | [Assignment](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/assignment-operator) |
| [`<Await>`](./tags/await.md) | [`await`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await) |
| [`<BitwiseAnd>`](./tags/bitwise-and.md) | [`&`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator-) |
| [`<BitwiseNot>`](./tags/bitwise-not.md) | [`~`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#bitwise-complement-operator-) |
| [`<BitwiseOr>`](./tags/bitwise-or.md) | [`\|`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-) |
| [`<Block>`](./tags/block.md) | Block scope |
| [`<Break>`](./tags/break.md) | [`break`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements#the-break-statement) |
| [`<Call>`](./tags/call.md) | [Method invocation](https://learn.microsoft.com/en-us/dotnet/csharp/methods#method-invocation) |
| [`<Case>`](./tags/case.md) | [`case`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement) |
| [`<Catch>`](./tags/catch.md) | [`catch`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements#the-try-catch-statement) |
| [`<Class>`](./tags/class.md) | [`class`](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes) |
| [`<Constructor>`](./tags/constructor.md) | [Constructor](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors) |
| [`<Continue>`](./tags/continue.md) | [`continue`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements#the-continue-statement) |
| [`<csml>`](./tags/csml.md) | *No equivalent* |
| [`<Decrement>`](./tags/decrement.md) | [`--`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#decrement-operator---) |
| [`<Default>`](./tags/default.md) | [`default`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement) |
| [`<Divide>`](./tags/divide.md) | [`/`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#division-operator-) |
| [`<Else>`](./tags/else.md) | [`else`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-if-statement) |
| [`<ElseIf>`](./tags/else-if.md) | [`else if`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-if-statement) |
| [`<Enum>`](./tags/enum.md) | [`enum`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum) |
| [`<EnumValue>`](./tags/enum-value.md) | [Enum value](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum) |
| [`<Equals>`](./tags/equals.md) | [`==`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators#equality-operator-) |
| [`<Field>`](./tags/field.md) | [Field](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields) |
| [`<Finally>`](./tags/finally.md) | [`finally`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements#the-try-finally-statement) |
| [`<For>`](./tags/for.md) | [`for`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement) |
| [`<ForEach>`](./tags/for-each.md) | [`foreach`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-foreach-statement) |
| [`<GreaterThan>`](./tags/greater-than.md) | [`>`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators#greater-than-operator-) |
| [`<GreaterThanOrEqual>`](./tags/greater-than-or-equal.md) | [`>=`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators#greater-than-or-equal-operator-) |
| [`<If>`](./tags/if.md) | [`if`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-if-statement) |
| [`<Increment>`](./tags/increment.md) | [`++`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#increment-operator-) |
| [`<Inheritance>`](./tags/inheritance.md) | [Inheritance](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance) |
| [`<Interface>`](./tags/interface.md) | [`interface`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface) |
| [`<LeftShift>`](./tags/left-shift.md) | [`<<`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-) |
| [`<LessThan>`](./tags/less-than.md) | [`<`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators#less-than-operator-) |
| [`<LessThanOrEqual>`](./tags/less-than-or-equal.md) | [`<=`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators#less-than-or-equal-operator-) |
| [`<Method>`](./tags/method.md) | [Method](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods) |
| [`<Multiply>`](./tags/multiply.md) | [`*`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#multiplication-operator-) |
| [`<Namespace>`](./tags/namespace.md) | [`namespace`](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/namespaces) |
| [`<New>`](./tags/new.md) | [`new`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/new-operator) |
| [`<Not>`](./tags/not.md) | [`!`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#logical-negation-operator-) |
| [`<NotEquals>`](./tags/not-equals.md) | [`!=`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators#inequality-operator-) |
| [`<Or>`](./tags/or.md) | [`\|\|`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#conditional-logical-or-operator-) |
| [`<Parameter>`](./tags/parameter.md) | [Method parameter](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters) (method declaration) |
| [`<PrefixDecrement>`](./tags/prefix-decrement.md) | [`--`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#decrement-operator---) |
| [`<PrefixIncrement>`](./tags/prefix-increment.md) | [`++`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#increment-operator-) |
| [`<Property>`](./tags/property.md) | [Property](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties) |
| [`<Remainder>`](./tags/remainder.md) | [`%`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-) |
| [`<Return>`](./tags/return.md) | [`return`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements#the-return-statement) |
| [`<RightShift>`](./tags/right-shift.md) | [`>>`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#right-shift-operator-) |
| [`<Struct>`](./tags/struct.md) | [`struct`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct) |
| [`<Subtract>`](./tags/subtract.md) | [`-`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#subtraction-operator--) |
| [`<Switch>`](./tags/switch.md) | [`switch`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement) |
| [`<Throw>`](./tags/throw.md) | [`throw`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements#the-throw-statement) |
| [`<Try>`](./tags/try.md) | [`try`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements#the-try-statement) |
| [`<UnsignedRightShift>`](./tags/unsigned-right-shift.md) | [`>>>`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#unsigned-right-shift-operator-) |
| [`<UsingDirective>`](./tags/using-directive.md) | [`using`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive) directive |
| [`<Value>`](./tags/value.md) | *No direct equivalent* |
| [`<Variable>`](./tags/variable.md) | [Variable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/variables) |
| [`<While>`](./tags/while.md) | [`while`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement) |
| [`<Xor>`](./tags/xor.md) | [`^`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-exclusive-or-operator-) |

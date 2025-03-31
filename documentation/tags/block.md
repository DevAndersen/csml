# `<Block>`

## Description

Represents a block of statements.

Note: `<Block>` tags will normally have a different name, e.g. `<Statements>` in the case of [`<If>`](./if.md).

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Assignment>` | [`<Assignment>`](./assignment.md) | *None* | No | Yes |  |
| `<Await>` | [`<Await>`](./await.md) | *None* | No | Yes |  |
| `<Break>` | [`<Break>`](./break.md) | *None* | No | Yes |  |
| `<Call>` | [`<Call>`](./call.md) | *None* | No | Yes |  |
| `<Catch>` | [`<Catch>`](./catch.md) | *None* | No | Yes |  |
| `<Continue>` | [`<Continue>`](./continue.md) | *None* | No | Yes |  |
| `<Decrement>` | [`<Decrement>`](./decrement.md) | *None* | No | Yes |  |
| `<Else>` | [`<Else>`](./else.md) | *None* | No | Yes |  |
| `<ElseIf>` | [`<ElseIf>`](./else-if.md) | *None* | No | Yes |  |
| `<For>` | [`<For>`](./for.md) | *None* | No | Yes |  |
| `<ForEach>` | [`<ForEach>`](./for-each.md) | *None* | No | Yes |  |
| `<Finally>` | [`<Finally>`](./finally.md) | *None* | No | Yes |  |
| `<If>` | [`<If>`](./if.md) | *None* | No | Yes |  |
| `<Increment>` | [`<Increment>`](./increment.md) | *None* | No | Yes |  |
| `<New>` | [`<New>`](./new.md) | *None* | No | Yes |  |
| `<PrefixDecrement>` | [`<PrefixDecrement>`](./prefix-decrement.md) | *None* | No | Yes |  |
| `<PrefixIncrement>` | [`<PrefixIncrement>`](./prefix-increment.md) | *None* | No | Yes |  |
| `<Return>` | [`<Return>`](./return.md) | *None* | No | Yes |  |
| `<Throw>` | [`<Throw>`](./throw.md) | *None* | No | Yes |  |
| `<Try>` | [`<Try>`](./try.md) | *None* | No | Yes |  |
| `<Variable>` | [`<Variable>`](./variable.md) | *None* | No | Yes |  |
| `<Switch>` | [`<Switch>`](./switch.md) | *None* | No | Yes |  |
| `<While>` | [`<While>`](./while.md) | *None* | No | Yes |  |

## C# equivalent

A block of statements.

## Example

### C♯ML

```xml
<Block>
    <Call Method="MethodA" />
    <Call Method="MethodB" />
</Block>
```

### C#

```csharp
MethodA();
MethodB();
```

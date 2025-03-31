# `<Variable>`

## Description

Declares a variable.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Name` | `string` | *None* | Yes | The name of the variable. |
| `Type` | `string` | *None* | Yes | The type of the variable. |
| `Const` | `bool` | `false` | No | Defines the variable as [`const`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const). |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Expression>` | [Expressions](../types/expressions.md) | *Uninitialized* | No | No | The expression defining the value of the variable. |

## C# equivalent

A variable declaration.

## Example

```xml
<Variable Type="int" Name="number">
    <Expression>
        <Value Value="123" />
    </Expression>
</Variable>
```

### C#

```csharp
int number = 123;
```

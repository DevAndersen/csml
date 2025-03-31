# `<Field>`

## Description

Represents a field.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | Yes | The type of the field. |
| `Name` | `string` | *None* | Yes | The name of the field. |
| `Value` | `string` | *None* | No | The initial value of the field. |
| `Access` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the field. |
| `Const` | `bool` | `false` | No | Marks the field as [`const`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const). |
| `ReadOnly` | `bool` | `false` | No | Marks the field as [`readonly`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly). |
| `Ref` | `bool` | `false` | No | Marks the field as [`ref`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/declarations#reference-variables). |
| `Static` | `bool` | `false` | No | Marks the field as [`static`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static). |

## Elements

None.

## C# equivalent

A field declaration.

## Example

### C♯ML

```xml
<Class Name="MyClass">
    <Field Name="myField" Type="int" />
</Class>
```

### C#

```csharp
class MyClass
{
    int myField;
}
```

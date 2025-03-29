# `<Struct>`

## Description

Declares a struct.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Name` | `string` | *None* | Yes | The name of the struct |
| `Access` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the struct. |
| `Ref` | `bool` | `false` | No | Marks the struct as a ref struct. |

## Elements

- `<Field>` (multiple): Contained fields.
- `<Property>` (multiple): Contained properties.
- `<Method>` (multiple): Contained methods.
- `<Class>` (multiple): Nested classes.
- `<Struct>` (multiple): Nested structs.
- `<Interface>` (multiple): Nested interfaces.
- `<Enum>` (multiple): Nested enums.

## C# equivalent

The `struct` keyword and an associated struct declaration.

## Example

### C♯ML

```xml
<Struct Access="Public" Name="MyStruct">
</Struct>
```

### C#

```csharp
public struct MyStruct
{
}
```

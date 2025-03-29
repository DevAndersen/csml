# `<Class>`

## Description

Declares a class.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Name` | `string` | *None* | Yes | The name of the class |
| `Access` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the class. |
| `Static` | `bool` | `false` | No | Marks the class as static. |

## Elements

- `<Field>` (multiple): Contained fields.
- `<Property>` (multiple): Contained properties.
- `<Method>` (multiple): Contained methods.
- `<Class>` (multiple): Nested classes.
- `<Struct>` (multiple): Nested structs.
- `<Interface>` (multiple): Nested interfaces.
- `<Enum>` (multiple): Nested enums.

## C# equivalent

The `class` keyword and an associated class declaration.

## Example

### C♯ML

```xml
<Class Access="Public" Static="true" Name="MyClass">
</Class>
```

### C#

```csharp
public static class MyClass
{
}
```

# `<Class>`

## Description

Declares a class.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Access` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the class. |
| `Name` | `string` | *None* | Yes | The name of the class. |
| `Static` | `bool` | `false` | No | Marks the class as static. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Class>` | [`<Class>`](../tags/class.md) | *None* | No | Yes | Nested class declarations. |
| `<Constructor>` | [`<Constructor>`](../tags/constructor.md) | *None* | No | Yes | Constructors. |
| `<Enum>` | [`<Enum>`](../tags/enum.md) | *None* | No | Yes | Nested enum declarations. |
| `<Field>` | [`<Field>`](../tags/field.md) | *None* | No | Yes | Field declarations. |
| `<Inheritance>` | [`<Inheritance>`](../tags/inheritance.md) | *None* | No | Yes | Class- and interface inheritence. |
| `<Interface>` | [`<Interface>`](../tags/interface.md) | *None* | No | Yes | Nested interface declarations. |
| `<Method>` | [`<Method>`](../tags/method.md) | *None* | No | Yes | Method declarations. |
| `<Property>` | [`<Property>`](../tags/property.md) | *None* | No | Yes | Property declarations. |
| `<Struct>` | [`<Struct>`](../tags/struct.md) | *None* | No | Yes | Nested struct declarations. |

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

# `<Namespace>`

## Description

Represents a namespace declaration.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Name` | `string` | *None* | Yes | The name of the namespace. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Class>` | [`<Class>`](../tags/class.md) | *None* | No | Yes | Class declarations. |
| `<Enum>` | [`<Enum>`](../tags/enum.md) | *None* | No | Yes | Enum declarations. |
| `<Namespace>` | [`<Namespace>`](../tags/namespace.md) | *None* | No | Yes | Namespace declarations. |
| `<Interface>` | [`<Interface>`](../tags/interface.md) | *None* | No | Yes |  declarations. |
| `<Struct>` | [`<Struct>`](../tags/struct.md) | *None* | No | Yes |  declarations. |
| `<UsingDirective>` | [`<UsingDirective>`](../tags/using-directive.md) | *None* | No | Yes |  Using directives. |

## C# equivalent

The `namespace` keyword and an associated namespace declaration.

## Example

```xml
<Namespace Name="MyNamespace">

    <Class Name="MyClass">
    </Class>

    <Interface Name="IMyInterface">
    </Interface>

</Namespace>
```

### C#

```csharp
namespace MyNamespace
{
    class MyClass
    {
    }

    interface IMyInterface
    {
    }
}
```

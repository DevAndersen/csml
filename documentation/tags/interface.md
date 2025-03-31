# `<Interface>`

## Description

Declares an interface.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Access` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the interface. |
| `Name` | `string` | *None* | Yes | The name of the interface. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Method>` | [`<Method>`](../tags/method.md) | *None* | No | Yes | Method declarations. |
| `<Property>` | [`<Property>`](../tags/property.md) | *None* | No | Yes | Property declarations. |

## C# equivalent

The `interface` keyword and an associated interface declaration.

## Example

### C♯ML

```xml
<Interface Access="Public" Name="IMyInterface">
    <Method Return="void" Name="DoStuff" />
</Interface>
```

### C#

```csharp
public interface IMyInterface
{
    void DoStuff();
}
```

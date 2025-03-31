# `<Constructor>`

## Description

Represents an constructor declaration.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Access` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the constructor. |
| `Static` | `bool` | `false` | No | Marks the constructor as static. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Parameter>` | [`<Block>`](./block.md) | *None* | No | Yes | The parameters of the constructor. |
| `<Statements>` | [`<Block>`](./block.md) | *None* | No | No | The statements contained within the constructor. |

## C# equivalent

A constructor method.

## Example

### C♯ML

```xml
<Class Name="MyClass">
    <Constructor Access="Public">
        <Parameter Type="int" Name="number" />
    </Constructor>
</Class>
```

### C#

```csharp
class MyClass
{
    public MyClass(int number)
    {
    }
}
```

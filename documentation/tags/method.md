# `<Method>`

## Description

Represents an method declaration.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Access` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the constructor. |
| `Static` | `bool` | `false` | No | Marks the constructor as static. |
| `Name` | `string` | *None* | Yes | The name of the method. |
| `Return` | `string` | *None* | Yes | The return type of the method. |
| `Async` | `bool` | `false` | No | Marks the method as [`async`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/async). |
| `Abstract` | `bool` | `false` | No | Marks the method as [`abstract`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract). |
| `Virtual` | `bool` | `false` | No | Marks the method as [`virtual`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual). |
| `Override` | `bool` | `false` | No | Marks the method as [`override`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override). |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Parameter>` | [`<Block>`](./block.md) | *None* | No | Yes | The parameters of the constructor. |
| `<Statements>` | [`<Block>`](./block.md) | *None* | No | No | The statements contained within the constructor. |

## C# equivalent

A method.

## Example

### C♯ML

```xml
<Method Access="Public" Return="int" Name="MyMethod">
    <Parameter Type="int" Name="number" />
    <Statements>
        <Return Value="i" />
    </Statements>
</Method>
```

### C#

```csharp
public int MyMethod(int number)
{
    return i;
}
```

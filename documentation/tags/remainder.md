# `<Remainder>`

## Description

Performs a remainder/modulo operation on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `%` operator.

## Example

### C♯ML

```xml
<Remainder>
    <Left>
        <Value Value="2" />
    </Left>
    <Right>
        <Value Value="1" />
    </Right>
</Remainder>
```

### C#

```csharp
2 - 1
```

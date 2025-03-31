# `<BitwiseAnd>`

## Description

Performs a bitwise AND operation on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `&` operator.

## Example

### C♯ML

```xml
<BitwiseAnd>
    <Left>
        <Value Value="numberA" />
    </Left>
    <Right>
        <Value Value="numberB" />
    </Right>
</BitwiseAnd>
```

### C#

```csharp
numberA & numberB
```

# `<LeftShift>`

## Description

Performs a left shift-operation on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `<<` operator.

## Example

### C♯ML

```xml
<LeftShift>
    <Left>
        <Value Value="4" />
    </Left>
    <Right>
        <Value Value="2" />
    </Right>
</LeftShift>
```

### C#

```csharp
4 << 2
```

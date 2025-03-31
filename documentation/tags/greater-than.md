# `<GreaterThan>`

## Description

Performs an greater-than comparison on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `>` operator.

## Example

### C♯ML

```xml
<GreaterThan>
    <Left>
        <Value Value="3" />
    </Left>
    <Right>
        <Value Value="2" />
    </Right>
</GreaterThan>
```

### C#

```csharp
3 > 2
```

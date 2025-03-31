# `<LessThanOrEqual>`

## Description

Performs a less-than-or-equal comparison on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `<=` operator.

## Example

### C♯ML

```xml
<LessThanOrEqual>
    <Left>
        <Value Value="2" />
    </Left>
    <Right>
        <Value Value="3" />
    </Right>
</LessThanOrEqual>
```

### C#

```csharp
2 <= 3
```

# `<GreaterThanOrEqual>`

## Description

Performs a greater-than-or-equal comparison on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `>=` operator.

## Example

### C♯ML

```xml
<GreaterThanOrEqual>
    <Left>
        <Value Value="3" />
    </Left>
    <Right>
        <Value Value="2" />
    </Right>
</GreaterThanOrEqual>
```

### C#

```csharp
3 >= 2
```

# `<Add>`

## Description

Performs an addition operation on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `+` operator.

## Example

### C♯ML

```xml
<Add>
    <Left>
        <Value Value="1" />
    </Left>
    <Right>
        <Value Value="2" />
    </Right>
</Add>
```

### C#

```csharp
1 + 2
```

# `<Divide>`

## Description

Performs a division operation on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `*` operator.

## Example

### C♯ML

```xml
<Divide>
    <Left>
        <Value Value="4" />
    </Left>
    <Right>
        <Value Value="2" />
    </Right>
</Divide>
```

### C#

```csharp
4 / 2
```

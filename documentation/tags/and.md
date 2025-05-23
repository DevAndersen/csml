# `<And>`

## Description

Performs a logical AND operation on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `&&` operator.

## Example

### C♯ML

```xml
<And>
    <Left>
        <Value Value="valueA" />
    </Left>
    <Right>
        <Value Value="valueB" />
    </Right>
</And>
```

### C#

```csharp
valueA && valueB
```

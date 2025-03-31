# `<Assignment>`

## Description

Assigns a value to a variable, property, or field.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `=` operator.

## Example

### C♯ML

```xml
<Assignment>
    <Left>
        <Value Value="number" />
    </Left>
    <Right>
        <Value Value="123" />
    </Right>
</Assignment>
```

### C#

```csharp
number = 123;
```

# `<BitwiseOr>`

## Description

Performs a bitwise OR operation on `<Left>` and `<Right>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Left>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |
| `<Right>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The left-hand argument of the expression. |

## C# equivalent

The `|` operator.

## Example

### C♯ML

```xml
<BitwiseOr>
    <Left>
        <Value Value="numberA" />
    </Left>
    <Right>
        <Value Value="numberB" />
    </Right>
</BitwiseOr>
```

### C#

```csharp
numberA | numberB
```

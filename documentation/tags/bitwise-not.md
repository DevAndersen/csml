# `<BitwiseNot>`

## Description

Performs a bitwise NOT operation on `<Expression>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Expression>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The contained expression. |

## C# equivalent

The `~` operator.

## Example

### C♯ML

```xml
<BitwiseNot>
    <Expression>
        <Value Value="myNumber" />
    </Expression>
</BitwiseNot>
```

### C#

```csharp
~myNumber
```

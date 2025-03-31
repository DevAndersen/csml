# `<Case>`

## Description

Represents a `case` in a `switch` statement.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Value` | `string` | *None* | Yes | The expression of the case. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| *Varies* | [Expressions](../types/expressions.md) | *None* | No | Yes | The statements contained within the case. |

## C# equivalent

The `case` keyword.

## Example

### C♯ML

```xml
<Case Value="1">
    <Call Method="DoWork" />
    <Break />
</Case>
```

### C#

```csharp
case 1:
    DoWork();
    break;
```

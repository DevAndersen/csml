# `<Not>`

## Description

Performs a logical NOT operation on `<Expression>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Expression>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The contained expression. |

## C# equivalent

The `!` operator.

## Example

### C♯ML

```xml
<Not>
    <Expression>
        <Value Value="hasValue" />
    </Expression>
</Not>
```

### C#

```csharp
!hasValue
```

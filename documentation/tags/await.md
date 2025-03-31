# `<Await>`

## Description

Performs `<Expression>` in an `await` expression.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Expression>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The contained expression. |

## C# equivalent

The `await` keyword.

## Example

### C♯ML

```xml
<Await>
    <Expression>
        <Value Value="myTask" />
    </Expression>
</Await>
```

### C#

```csharp
await myTask
```

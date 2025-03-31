# `<Throw>`

## Description

Performs `throw` on `<Expression>`.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Expression>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The contained expression. |

## C# equivalent

The `throw` keyword.

## Example

### C♯ML

```xml
<Throw>
    <New Type="MyException" />
</Throw>
```

### C#

```csharp
throw new MyException();
```

# `<Try>`

## Description

Represents a `try` statement.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Statements>` | [`<Block>`](./block.md) | *None* | Yes | No | The statements contained within the try-statement. |

## C# equivalent

The `try` keyword.

## Example

### C♯ML

```xml
<Try>
    <Statements>
        <Call Method="DoWork" />
    </Statements>
</Try>
```

### C#

```csharp
try
{
    DoWork();
}
```

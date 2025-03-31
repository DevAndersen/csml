# `<Finally>`

## Description

Represents an `finally` statement.

Note: This tag must come after a [`<Try>`](./try.md) or [`<Catch>`](./catch.md) tag.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | No | The exception type to catch. |
| `Name` | `string` | *None* | No | The name of the caught exception. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Statements>` | [`<Block>`](./block.md) | *None* | Yes | No | The statements contained within the finally-statement. |

## C# equivalent

The `finally` keyword.

## Example

### C♯ML

```xml
<Finally>
    <Statements>
        <Call Method="Dispose" />
    </Statements>
</Finally>
```

### C#

```csharp
finally
{
    Dispose();
}
```

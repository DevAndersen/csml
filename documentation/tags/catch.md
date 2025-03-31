# `<Catch>`

## Description

Represents an `catch` statement.

Note: This tag must come after a [`<Try>`](./try.md) tag.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | No | The exception type to catch. |
| `Name` | `string` | *None* | No | The name of the caught exception. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Statements>` | [`<Block>`](./block.md) | *None* | Yes | No | The statements contained within the catch-statement. |

## C# equivalent

The `catch` keyword.

## Example

### C♯ML

```xml
<Catch Type="InvalidOperationException" Name="e">
    <Statements>
        <Call Method="HandleError">
            <Argument Value="e"/>
        </Call>
    </Statements>
</Catch>
```

### C#

```csharp
catch (InvalidOperationException e)
{
    HandleError(e);
}
```

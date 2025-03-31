# `<ForEach>`

## Description

Represents a `foreach` statement.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | Yes | The type of the values being iterated over. |
| `Name` | `string` | *None* | Yes | The name of the current iterated value. |
| `Collection` | `string` | *None* | Yes | The name of the collection that the foreach statement iterates over. |

## Elements

None.

## C# equivalent

The `foreach` keyword.

## Example

### C♯ML

```xml
<ForEach Type="int" Name="number" Collection="numbers">
    <Variable Type="int" Name="valA">
        <Expression>
            <Value Value="number" />
        </Expression>
    </Variable>
</ForEach>
```

### C#

```csharp
foreach (int number in numbers)
{
    int valA = number;
}
```

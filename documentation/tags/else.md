# `<Else>`

## Description

Represents an `else` statement.

Note: This tag must come after an [`<If>`](./if.md) or [`<ElseIf>`](./else-if.md) tag.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Expression>` | [Expression](../types/expressions.md) | *None* | Yes | No | The expression to be matched in order for the statements of the else-statement to be executed. |
| `<Statements>` | [`<Block>`](./block.md) | *None* | Yes | No | The statements contained within the else-statement. |

## C# equivalent

The `else` keyword.

## Example

### C♯ML

```xml
<Else>
    <Statements>
        <Variable Type="int" Name="valA">
            <Expression>
                <Value Value="3" />
            </Expression>
        </Variable>
    </Statements>
</Else>
```

### C#

```csharp
else
{
    int valA = 3;
}
```

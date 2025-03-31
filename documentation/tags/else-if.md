# `<ElseIf>`

## Description

Represents an `else if` statement.

Note: This tag must come after an [`<If>`](./if.md) tag.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Expression>` | [Expression](../types/expressions.md) | *None* | Yes | No | The expression to be matched in order for the statements of the else-if-statement to be executed. |
| `<Statements>` | [`<Block>`](./block.md) | *None* | Yes | No | The statements contained within the else-if-statement. |

## C# equivalent

An `else if` statement.

## Example

### C♯ML

```xml
<ElseIf>
    <Expression>
        <NotEquals>
            <Left>
                <Value Value="4" />
            </Left>
            <Right>
                <Value Value="2" />
            </Right>
        </NotEquals>
    </Expression>
    <Statements>
        <Variable Type="int" Name="valA">
            <Expression>
                <Value Value="2" />
            </Expression>
        </Variable>
    </Statements>
</ElseIf>
```

### C#

```csharp
else if (4 != 2)
{
    int valA = 2;
}
```

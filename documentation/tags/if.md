# `<If>`

## Description

Represents an `if` statement.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Expression>` | [Expression](../types/expressions.md) | *None* | Yes | No | The expression to be matched in order for the statements of the if-statement to be executed. |
| `<Statements>` | [`<Block>`](./block.md) | *None* | Yes | No | The statements contained within the if-statement. |

## C# equivalent

The `case` keyword.

## Example

### C♯ML

```xml
<If>
    <Expression>
        <LessThan>
            <Left>
                <Value Value="1" />
            </Left>
            <Right>
                <Value Value="2" />
            </Right>
        </LessThan>
    </Expression>
    <Statements>
        <Variable Type="int" Name="valA">
            <Expression>
                <Value Value="1" />
            </Expression>
        </Variable>
    </Statements>
</If>
```

### C#

```csharp
if (1 < 2)
{
    int valA = 1;
}
```

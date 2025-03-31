# `<While>`

## Description

Represents a `while` statement.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Condition>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The condition of the while-statement. |
| `<Statements>` | [`<Block>`](./block.md) | *None* | Yes | No | The statements contained within the while-statement. |

## C# equivalent

The `while` keyword.

## Example

### C♯ML

```xml
<While>
    <Condition>
        <LessThan>
            <Left>
                <Value Value="i" />
            </Left>
            <Right>
                <Value Value="5" />
            </Right>
        </LessThan>
    </Condition>
    <Statements>
        <Increment Target="i" />
    </Statements>
</While>
```

### C#

```csharp
while (i < 5)
{
    i++;
}
```

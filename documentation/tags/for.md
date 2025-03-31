# `<For>`

## Description

Represents a `for` statement.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Variable>` | [`<Variable>`](./variable.md) | *None* | Yes | No | The variable declaration of the for-statements's iterator. |
| `<Condition>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The condition of the for-statement. |
| `<Iterator>` | [Expressions](../types/expressions.md) | *None* | Yes | No | The incrementor of the for-statement. |
| `<Statements>` | [`<Block>`](./block.md) | *None* | Yes | No | The statements contained within the for-statement. |

## C# equivalent

The `for` keyword.

## Example

### C♯ML

```xml
<For>
    <Variable Type="int" Name="i">
        <Expression>
            <Value Value="0" />
        </Expression>
    </Variable>
    <Condition>
        <LessThan>
            <Left>
                <Value Value="i" />
            </Left>
            <Right>
                <Value Value="10" />
            </Right>
        </LessThan>
    </Condition>
    <Iterator>
        <Increment Target="i" />
    </Iterator>
    <Statements>
        <Call Target="System.Console" Method="WriteLine">
            <Argument Value="i"/>
        </Call>
    </Statements>
</For>
```

### C#

```csharp
for (int i = 0; i < 10; i++)
{
    System.Console.WriteLine(i);
}
```

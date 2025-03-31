# `<Switch>`

## Description

Represents a `switch` statement.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Value` | `string` | *None* | Yes | The name of the value being switched over. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Case>` | [Expressions](./case.md) | *None* | No | Yes | A `case` within the switch-statement. |
| `<Default>` | [Expressions](./default.md) | *None* | No | Yes | A `default` case within the switch-statement. |

## C# equivalent

The `switch` keyword.

## Example

### C♯ML

```xml
<Switch Value="myNumber">
    <Case Value="1">
        <Break />
    </Case>
    <Case Value="2">
        <Break />
    </Case>
    <Default>
        <Break />
    </Default>
</Switch>
```

### C#

```csharp
switch (myNumber)
{
    case 1:
    {
        break;
    }

    case 2:
    {
        break;
    }

    default:
    {
        break;
    }
}
```

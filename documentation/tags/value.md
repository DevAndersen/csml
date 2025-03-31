# `<Value>`

## Description

Refers to a value or an object.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | Yes | The value. |

## Elements

None.

## C# equivalent

A literal value, or the name of a variable.

## Example

```xml
<Variable Type="int" Name="number">
    <Expression>
        <Value Value="123" />
    </Expression>
</Variable>
```

### C#

```csharp
int number = 123;
```

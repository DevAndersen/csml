# `<Parameter>`

## Description

Represents a parameter of a method or a constructor.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | Yes | The type of the parameter. |
| `Name` | `string` | *None* | Yes | The name of the parameter. |
| `Default` | `string` | *None* | No | The default value of the parameter. |
| `Modifier` | [`ParameterModifier`](../types/parameter-modifier.md) | *None* | No | The modifiers of the parameter. |

## Elements

None.

## C# equivalent

The method- or constructor parameter.

## Example

### C♯ML

```xml
<Method Name="MyMethod" Return="void">
    <Parameter Type="int" Name="number" />
</Method>
```

### C#

```csharp
void MyMethod(int number)
```

# `<EnumValue>`

## Description

Defines a value in an enum.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Name` | `string` | *None* | Yes | The name of the enum value. |
| `Value` | Number | *Implicitly determined* | No | The value of the enum value. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Values>` | [`<EnumValue>`](../tags/enum-value.md) | *None* | No | Yes | The values of the enum. |

## C# equivalent

The values of an `enum`.

## Example

### C♯ML

```xml
<Enum Name="MyEnum">
    <EnumValue Name="A" />
    <EnumValue Name="B" />
    <EnumValue Name="C" Value="3" />
</Enum>
```

### C#

```csharp
enum MyEnum
{
    A,
    B,
    C = 3
}
```

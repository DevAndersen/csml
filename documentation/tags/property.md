# `<Property>`

## Description

Represents a property.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | Yes | The type of the property. |
| `Name` | `string` | *None* | Yes | The name of the property. |
| `Value` | `string` | *None* | No | The initial value of the property. |
| `Access` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the property. |
| `Getter` | [Property getter accessor](../types/property-getter-accessor.md) | *Context dependent* | No | The accessor for the property getter. |
| `GetterAccess` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the getter. |
| `Setter` | [Property setter accessor](../types/property-setter-accessor.md) | *Context dependent* | No | The accessor for the property setter. |
| `SetterAccess` | [Access modifiers](../types/access-modifiers.md) | *Context dependent* | No | The [access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) of the setter. |

## Elements

None.

## C# equivalent

A property declaration.

## Example

### C♯ML

```xml
<Class Name="MyClass">
    <Property Name="MyProperty" Type="int" Getter="Get" Setter="Set" />
</Class>
```

### C#

```csharp
class MyClass
{
    int MyProperty { get; set; }
}
```

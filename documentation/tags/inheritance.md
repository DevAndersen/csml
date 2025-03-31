# `<Inheritance>`

## Description

Specifies a base class or interface implementation.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | Yes | The name of the type. |

## Elements

None.

## C# equivalent

The `:` keyword and an type name.

## Example

### C♯ML

```xml
<Class Name="MyClass">
    <Inheritance Type="IDisposable" />
</Class>
```

### C#

```csharp
class MyClass : IDisposable
{
}
```

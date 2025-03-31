# `<Call>`

## Description

Represents a method invocation.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Target` | `string` | *None* | No | The object or type to target the method invocation at. |
| `Method` | `string` | *None* | Yes | The name of the method being invoked. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Argument>` | [`<Argument>`](./argument.md) | *None* | No | Yes | The arguments passed to the method invocation. |

## C# equivalent

A method invocation.

## Example

### C♯ML

```xml
<Call Target="System.Console" Method="WriteLine">
    <Argument Value="123"/>
</Call>
```

### C#

```csharp
System.Console.WriteLine(123);
```

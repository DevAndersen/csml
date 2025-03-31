# `<Argument>`

## Description

Represents an argument being provided to a method invocation or object constructor.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Value` | `string` | *None* | Yes | The value of the argument. |

## Elements

None.

## C# equivalent

A method- or constructor argument.

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

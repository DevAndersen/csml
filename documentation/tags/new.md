# `<New>`

## Description

Constructs a new object.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Type` | `string` | *None* | Yes | The type to be constructed. |

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<Argument>` | [`<Argument>`](../tags/argument.md) | *None* | No | Yes | Constructor arguments. |

## C# equivalent

The `new` keyword.

## Example

```xml
<New Type="MyType">
    <Argument Value="1" />
</New>
```

### C#

```csharp
new MyType(1)
```

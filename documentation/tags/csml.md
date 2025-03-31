# `<csml>`

## Description

Represents the root node of a C♯ML source file.

## Attributes

None.

## Elements

| Name | Type | Default | Mandatory | Multiple allowed | Description |
|---|---|---|---|---|---|
| `<UsingDirective>` | Using directive | *None* | No | Yes | Using directives. |
| `<Namespace>` | Namespace | *None* | No | Yes | Namespace declarations. |

## C# equivalent

*No direct C# equivalent.*

## Example

```xml
<csml>

    <UsingDirective Namespace="System" />
    
    <Namespace Name="MyNamespace">
    </Namespace>

</csml>
```

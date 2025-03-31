# `<UsingDirective>`

## Description

Declares a using directive.

## Attributes

| Name | Type | Default | Mandatory | Description |
|---|---|---|---|---|
| `Namespace` | `string` | *None* | Yes | The namespace of the using directive. |

## Elements

None.

## C# equivalent

The `using` keyword, in the context of using directives.

## Example

### C♯ML

```xml
<Csml>
    <UsingDirective Namespace="System" />
    <Namespace Name="MyNamespace">
        <UsingDirective Namespace="System.Text" />
    </Namespace>
</Csml>
```

### C#

```csharp
using System;

namespace MyNamespace
{
    using System.Text;
}
```

using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Csml.Parser;

/// <summary>
/// Contains logic for validating the state of objects.
/// </summary>
public static class ObjectValidator
{
    /// <summary>
    /// Ensures that all reference type properties on <paramref name="obj"/> marked as <c>required</c> have a non-null value.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="results"></param>
    public static void Validate(object obj, List<CsmlParseError> results)
    {
        Type type = obj.GetType();
        if (obj is not BaseNode node)
        {
            return;
        }

        foreach (PropertyInfo property in type.GetProperties())
        {
            object? propertyValue = property.GetValue(node);

            RequiredMemberAttribute? requiredAttribute = property.GetCustomAttribute<RequiredMemberAttribute>();
            if (requiredAttribute != null && property.PropertyType.IsClass && propertyValue == null)
            {
                results.Add(new CsmlParseError(CsmlDiagnostics.MissingRequiredProperty, node.LineNumber, property.Name));
            }

            if (propertyValue != null)
            {
                if (propertyValue is IEnumerable enumerable)
                {
                    foreach (object enumeratedValue in enumerable)
                    {
                        Validate(enumeratedValue, results);
                    }
                }
                else
                {
                    Validate(propertyValue, results);
                }
            }
        }
    }
}

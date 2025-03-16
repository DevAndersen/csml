#pragma warning disable IDE0130 // Namespace does not match folder structure
#pragma warning disable IDE0290 // Use primary constructor
#pragma warning disable IDE0060 // Remove unused parameter

namespace System.Runtime.CompilerServices;

/// <summary>
/// Makes <c>init</c> working on .NET Standard 2.0.
/// </summary>
internal static class IsExternalInit
{
}

/// <summary>
/// Makes <c>required</c> work on .NET Standard 2.0.
/// </summary>
internal class RequiredMemberAttribute : Attribute
{
}

/// <summary>
/// Makes <c>required</c> work on .NET Standard 2.0.
/// </summary>
internal sealed class CompilerFeatureRequiredAttribute : Attribute
{
    internal CompilerFeatureRequiredAttribute(string featureName)
    {
    }
}

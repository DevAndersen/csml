using System.Diagnostics.CodeAnalysis;

namespace CsmlTests.Helpers;

internal static class SyntaxNodeDescendantExtensions
{
    /// <summary>
    /// Returns the child nodes of <paramref name="node"/> an array, allowing direct use of pattern matching.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static SyntaxNode[] GetChildNodes(this SyntaxNode node)
    {
        return node.ChildNodes().ToArray();
    }

    /// <summary>
    /// Attempts to find the first <typeparamref name="T"/> nested inside <paramref name="node"/> that fulfills <paramref name="predicate"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="node"></param>
    /// <param name="match"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool FirstDescendant<T>(
        this SyntaxNode node,
        [NotNullWhen(true)] out T? match,
        Func<T, bool>? predicate = null)
        where T : SyntaxNode
    {
        return FindDescendant([node], true, out match, predicate);
    }

    /// <summary>
    /// Attempts to find the first <typeparamref name="T"/> nested inside <paramref name="nodes"/> that fulfills <paramref name="predicate"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodes"></param>
    /// <param name="match"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool FirstDescendant<T>(
        this IEnumerable<SyntaxNode> nodes,
        [NotNullWhen(true)] out T? match,
        Func<T, bool>? predicate = null)
        where T : SyntaxNode
    {
        return FindDescendant(nodes, true, out match, predicate);
    }

    /// <summary>
    /// Attempts to find the last <typeparamref name="T"/> nested inside <paramref name="node"/> that fulfills <paramref name="predicate"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="node"></param>
    /// <param name="match"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool LastDescendant<T>(
        this SyntaxNode node,
        [NotNullWhen(true)] out T? match,
        Func<T, bool>? predicate = null)
        where T : SyntaxNode
    {
        return FindDescendant([node], false, out match, predicate);
    }

    /// <summary>
    /// Attempts to find the last <typeparamref name="T"/> nested inside <paramref name="nodes"/> that fulfills <paramref name="predicate"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodes"></param>
    /// <param name="match"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool LastDescendant<T>(
        this IEnumerable<SyntaxNode> nodes,
        [NotNullWhen(true)] out T? match,
        Func<T, bool>? predicate = null)
        where T : SyntaxNode
    {
        return FindDescendant(nodes, false, out match, predicate);
    }

    /// <summary>
    /// Attempts to find a <typeparamref name="T"/> nested inside <paramref name="nodes"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodes"></param>
    /// <param name="predicate"></param>
    /// <param name="match"></param>
    /// <returns></returns>
    private static bool FindDescendant<T>(
        IEnumerable<SyntaxNode> nodes,
        bool returnFirstMatch,
        [NotNullWhen(true)] out T? match,
        Func<T, bool>? predicate)
        where T : SyntaxNode
    {
        match = null;

        foreach (SyntaxNode descendant in nodes.SelectMany(x => x.DescendantNodesAndSelf()))
        {
            if (descendant is T matchingNode && predicate?.Invoke(matchingNode) != false)
            {
                match = matchingNode;
                if (returnFirstMatch)
                {
                    return true;
                }
            }
        }

        return match != null;
    }
}

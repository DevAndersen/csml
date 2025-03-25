namespace Csml.Generator.SyntaxBuilders;

internal static class CsmlBuilder
{
    public static CompilationUnitSyntax Build(CsmlNode node)
    {
        CompilationUnitSyntax comp = SF.CompilationUnit();

        SyntaxList<UsingDirectiveSyntax> usingList = UsingDirectiveBuilder.BuildMultiple(node.UsingDirectives);
        SyntaxList<MemberDeclarationSyntax> namespaceList = NamespaceBuilder.BuildMultiple(node.Namespaces);

        return comp
            .WithUsings(usingList)
            .WithMembers(namespaceList)
            .NormalizeWhitespace();
    }
}

using Csml.Exceptions;
using Csml.Parser.Nodes.Members;
using Csml.Parser.Nodes.Types;

namespace Csml.Generator.SyntaxBuilders;

public static class FieldBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(FieldNode[]? nodes, TypeNode parentType)
    {
        SyntaxList<MemberDeclarationSyntax> fieldList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (FieldNode item in nodes)
            {
                fieldList = fieldList.Add(Build(item, parentType));
            }
        }

        return fieldList;
    }

    public static FieldDeclarationSyntax Build(FieldNode fieldNode, TypeNode parentType)
    {
        SyntaxKind[] accessModifiers = fieldNode.Access switch
        {
            AccessModifier.Public => [SyntaxKind.PublicKeyword],
            AccessModifier.Private => [SyntaxKind.PrivateKeyword],
            AccessModifier.Protected when parentType is StructNode => throw new InvalidAccessorException(fieldNode.LineNumber, fieldNode.Access, "field"),
            AccessModifier.Protected => [SyntaxKind.ProtectedKeyword],
            AccessModifier.Internal => [SyntaxKind.InternalKeyword],
            AccessModifier.ProtectedInternal when parentType is StructNode => throw new InvalidAccessorException(fieldNode.LineNumber, fieldNode.Access, "field"),
            AccessModifier.ProtectedInternal => [SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword],
            AccessModifier.PrivateProtected when parentType is StructNode => throw new InvalidAccessorException(fieldNode.LineNumber, fieldNode.Access, "field"),
            AccessModifier.PrivateProtected => [SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword],
            AccessModifier.File => throw new InvalidAccessorException(fieldNode.LineNumber, fieldNode.Access, "field"),
            _ => [SyntaxKind.PrivateKeyword],
        };

        SyntaxTokenList tokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in accessModifiers)
        {
            tokenList = tokenList.Add(SF.Token(accessModifier));
        }

        VariableDeclarationSyntax variable = SF
            .VariableDeclaration(SF.IdentifierName(fieldNode.Type))
            .WithVariables([SF.VariableDeclarator(fieldNode.Name)]);

        return SF.FieldDeclaration([], tokenList, variable);
    }
}

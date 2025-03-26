using Csml.Exceptions;
using Csml.Generator.SyntaxBuilders.Statements;
using Csml.Parser.Nodes.Members;
using Csml.Parser.Nodes.Statements;
using Csml.Parser.Nodes.Types;

namespace Csml.Generator.SyntaxBuilders.Members;

internal class MethodBuilder
{
    public static SyntaxList<MemberDeclarationSyntax> BuildMultiple(MethodNode[]? nodes, TypeNode parentType)
    {
        SyntaxList<MemberDeclarationSyntax> methodList = SF.List<MemberDeclarationSyntax>();

        if (nodes != null)
        {
            foreach (MethodNode item in nodes)
            {
                methodList = methodList.Add(Build(item, parentType));
            }
        }

        return methodList;
    }

    public static MethodDeclarationSyntax Build(MethodNode methodNode, TypeNode parentType)
    {
        SyntaxKind[] accessModifiers = methodNode.Access switch
        {
            AccessModifier.Public => [SyntaxKind.PublicKeyword],
            AccessModifier.Private => [SyntaxKind.PrivateKeyword],
            AccessModifier.Protected when parentType is StructNode => throw new InvalidAccessorException(methodNode.LineNumber, methodNode.Access, "method"),
            AccessModifier.Protected => [SyntaxKind.ProtectedKeyword],
            AccessModifier.Internal => [SyntaxKind.InternalKeyword],
            AccessModifier.ProtectedInternal when parentType is StructNode => throw new InvalidAccessorException(methodNode.LineNumber, methodNode.Access, "method"),
            AccessModifier.ProtectedInternal => [SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword],
            AccessModifier.PrivateProtected when parentType is StructNode => throw new InvalidAccessorException(methodNode.LineNumber, methodNode.Access, "method"),
            AccessModifier.PrivateProtected => [SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword],
            AccessModifier.File => throw new InvalidAccessorException(methodNode.LineNumber, methodNode.Access, "method"),
            _ when parentType is InterfaceNode => [SyntaxKind.PublicKeyword],
            _ => [SyntaxKind.PrivateKeyword],
        };

        SyntaxTokenList tokenList = SF.TokenList();

        foreach (SyntaxKind accessModifier in accessModifiers)
        {
            tokenList = tokenList.Add(SF.Token(accessModifier));
        }

        if (methodNode.Static)
        {
            tokenList = tokenList.Add(SF.Token(SyntaxKind.StaticKeyword));
        }

        if (methodNode.Async)
        {
            tokenList = tokenList.Add(SF.Token(SyntaxKind.AsyncKeyword));
        }

        if (methodNode.Abstract)
        {
            tokenList = tokenList.Add(SF.Token(SyntaxKind.AbstractKeyword));
        }

        if (methodNode.Virtual)
        {
            tokenList = tokenList.Add(SF.Token(SyntaxKind.VirtualKeyword));
        }

        if (methodNode.Override)
        {
            tokenList = tokenList.Add(SF.Token(SyntaxKind.OverrideKeyword));
        }

        MethodDeclarationSyntax methodDeclaration = SF.MethodDeclaration(
            SF.IdentifierName(methodNode.Return),
            SF.Identifier(methodNode.Name));

        if (methodNode.Abstract || (parentType is InterfaceNode && methodNode.Statements?.Any() != true))
        {
            methodDeclaration = methodDeclaration.WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken));
        }
        else
        {
            BlockSyntax block = SF.Block();

            if (methodNode.Statements?.Length > 0)
            {
                foreach (BaseNode statementNode in methodNode.Statements)
                {
                    StatementSyntax statementSyntax = statementNode switch
                    {
                        ReturnNode returnNode => ReturnBuilder.Build(returnNode),
                        VariableNode variableNode => VariableBuilder.Build(variableNode),
                        CallNode callNode => CallBuilder.Build(callNode),
                        BreakNode breakNode => BreakBuilder.Build(),
                        ContinueNode continueNode => ContinueBuilder.Build(),
                        _ => throw new UnknownCsmlElementException(
                            statementNode.LineNumber,
                            statementNode.GetType().Name)
                    };

                    block = block.AddStatements(statementSyntax);
                }
            }
            methodDeclaration = methodDeclaration.WithBody(block);
        }

        return methodDeclaration
            .WithModifiers(tokenList);
    }
}

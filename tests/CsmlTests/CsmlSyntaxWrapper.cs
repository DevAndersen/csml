﻿namespace CsmlTests;

internal static class CsmlSyntaxWrapper
{
    public static string WrapInClass(string markup)
    {
        return $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        {markup}
                    </Class>
                </Namespace>
            </Csml>
            """;
    }

    public static string WrapInMethod(string markup)
    {
        return $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Name="MyMethod" Return="void">
                            <Statements>
                                {markup}
                            </Statements>
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;
    }
}

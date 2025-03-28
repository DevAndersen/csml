﻿namespace CsmlTests;

internal static class CsmlSyntaxWrapper
{
    public static string WrapInMethod(string markup)
    {
        return $"""
            <Csml>
            	<Namespace Name="MyNamespace">
                    <Class Name="MyClass">
                        <Method Name="MyMethod" Return="void">
                            {markup}
                        </Method>
                    </Class>
                </Namespace>
            </Csml>
            """;
    }
}

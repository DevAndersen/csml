namespace Csml.Exceptions;

public class InvalidAccessorException : Exception
{
    public int LineNumber { get; }

    public AccessModifier AccessModifiers { get; }

    public string Target { get; }

    public InvalidAccessorException(int lineNumber, AccessModifier accessModifiers, string target)
    {
        LineNumber = lineNumber;
        AccessModifiers = accessModifiers;
        Target = target;
    }
}

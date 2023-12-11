namespace ProjectHub.Abstractions.Exceptions.ValidationEx;

public class ValidationException : Exception
{
    protected ValidationException(string? message)
        : base(message)
    {
    }
}
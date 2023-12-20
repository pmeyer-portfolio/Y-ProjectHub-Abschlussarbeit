namespace ProjectHub.Abstractions.Exceptions.ValidationEx;

public class ValidationException : ProjectHubException
{
    protected ValidationException(string? message)
        : base(message)
    {
    }
}
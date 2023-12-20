namespace ProjectHub.Abstractions.Exceptions;

public abstract class ProjectHubException : Exception
{
    protected ProjectHubException(string? message)
        : base(message)
    {
    }
}
namespace ProjectHub.Abstractions.Exceptions.ValidationEx;

public class ProjectTitleIsNullOrWhiteSpaceException : ValidationException
{
    public ProjectTitleIsNullOrWhiteSpaceException(string? message)
        : base(message)
    {
    }
}
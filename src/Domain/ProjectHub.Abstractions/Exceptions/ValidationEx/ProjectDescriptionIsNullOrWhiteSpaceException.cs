namespace ProjectHub.Abstractions.Exceptions.ValidationEx;

public class ProjectDescriptionIsNullOrWhiteSpaceException
    : ValidationException
{
    public ProjectDescriptionIsNullOrWhiteSpaceException(string? message)
        : base(message)
    {
    }
}
namespace ProjectHub.Blazor.Models;

public class ProjectViewModel
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Status { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public string? CreatedBy { get; init; }
    public string? TribeName { get; init; }
    public IList<string> ProgrammingLanguages { get; init; } = new List<string>();
    public string? Description { get; init; }
}
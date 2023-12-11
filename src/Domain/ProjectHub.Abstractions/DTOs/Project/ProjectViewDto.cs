namespace ProjectHub.Abstractions.DTOs.Project;

public class ProjectViewDto
{
    public int Id { get; set; }
    public IList<string> ProgrammingLanguages { get; set; } = new List<string>();
    public string? TribeName { get; init; }
    public required string? Description { get; init; }
    public required string? Title { get; init; }
    public string? Created { get; init; }
    public string? Status { get; init; }
}
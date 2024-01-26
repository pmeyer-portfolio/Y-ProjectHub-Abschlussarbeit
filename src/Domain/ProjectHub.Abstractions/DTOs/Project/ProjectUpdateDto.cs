namespace ProjectHub.Abstractions.DTOs.Project;

public class ProjectUpdateDto
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public int? TribeId { get; set; }
    public IList<int> ProgrammingLanguages { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
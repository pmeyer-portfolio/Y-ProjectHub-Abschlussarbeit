namespace ProjectHub.Blazor.Models.Project;

public class ProjectFilterModel
{
    public string? TribeName { get; set; }
    public string? Status { get; set; }
    public string? ProgrammingLanguage { get; set; }
    public DateTime? SpecificDateTime { get; set; }
    public DateTime? FromDateTime { get; set; }
    public DateTime? ToDateTime { get; set; }
}
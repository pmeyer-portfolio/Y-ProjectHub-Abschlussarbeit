namespace ProjectHub.Blazor.Models;

using ProjectHub.Blazor.Services.Base;

public class ProjectViewModel
{ 
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; init; }
    public string? CreatedBy { get; init; }
    public string? TribeName { get; set; }
    public IList<string> ProgrammingLanguages { get; init; } = new List<string>();
}
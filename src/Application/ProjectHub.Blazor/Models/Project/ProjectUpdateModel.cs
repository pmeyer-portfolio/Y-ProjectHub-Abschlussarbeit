namespace ProjectHub.Blazor.Models.Project;

using Microsoft.AspNetCore.Components;

public class ProjectUpdateModel
{
    public bool projectHaveUpdates;
    public int Id { get; set; }
    public string Status { get; set; }
    public int TribeId { get; set; }
    public IList<int> ProgrammingLanguageIds { get; set; } = new List<int>();
    public string Title { get; set; }
    public MarkupString Description { get; set; }
}
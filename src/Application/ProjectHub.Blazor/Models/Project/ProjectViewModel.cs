namespace ProjectHub.Blazor.Models.Project;

using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Models.Tribe;

public class ProjectViewModel
{
    public int Id { get; init; }
    public string? Title { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; init; }
    public string? CreatedBy { get; init; }
    public TribeViewModel? TribeViewModel { get; set; }

    public IList<ProgrammingLanguageViewModel> ProgrammingLanguageViewModels { get; set; } =
        new List<ProgrammingLanguageViewModel>();
}
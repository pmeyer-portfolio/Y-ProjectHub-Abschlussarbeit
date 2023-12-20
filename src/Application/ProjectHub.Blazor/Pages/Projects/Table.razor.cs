namespace ProjectHub.Blazor.Pages.Projects;

using System.Text;
using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models;

public partial class Table
{
    [Parameter]
    public IList<ProjectViewModel>? Projects { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    private void OpenDetailsView(int projectsId)
    {
        this.NavigationManager.NavigateTo(ProjectHubRoute.Details.Replace("{id:int}", projectsId.ToString()));
    }

    private string? GetTribeNameOrPlaceholder(ProjectViewModel project)
    {
        return string.IsNullOrEmpty(project.TribeName)
            ? PlaceHolder.NotAssigned
            : project.TribeName;
    }

    private MarkupString GetProgrammingLanguagesOrPlaceHolder(ProjectViewModel project)
    {
        if (!project.ProgrammingLanguages.Any())
        {
            project.ProgrammingLanguages.Add(PlaceHolder.NotSpecified);
        }

        StringBuilder stringBuilder = new();

        foreach (string projectProgrammingLanguage in project.ProgrammingLanguages)
        {
            stringBuilder.AppendLine($"{projectProgrammingLanguage}<br>");
        }

        return new MarkupString(stringBuilder.ToString());
    }
}
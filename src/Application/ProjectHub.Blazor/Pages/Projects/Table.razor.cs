namespace ProjectHub.Blazor.Pages.Projects;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models;
using Radzen.Blazor;

public partial class Table
{
    private RadzenDataGrid<ProjectViewModel> dataGrid = null!;

    private IList<ProjectViewModel>? filteredProjects = null!;

    [Parameter]
    public IList<ProjectViewModel>? Projects { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected override void OnInitialized()
    {
        this.filteredProjects = this.Projects;
    }

    private void OpenDetailsView(int projectsId)
    {
        this.NavigationManager.NavigateTo(ProjectHubRoute.Details.Replace("{id:int}", projectsId.ToString()));
    }

    private void OnProjectsFiltered(IList<ProjectViewModel> projects)
    {
        this.filteredProjects = projects;
        this.dataGrid.Reload();
    }
}
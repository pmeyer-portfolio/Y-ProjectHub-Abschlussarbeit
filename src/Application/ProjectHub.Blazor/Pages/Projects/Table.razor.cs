namespace ProjectHub.Blazor.Pages.Projects;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Project;
using Radzen;
using Radzen.Blazor;

public partial class Table
{
    private RadzenDataGrid<ProjectViewModel> dataGrid = null!;

    private IList<ProjectViewModel>? filteredProjects = null!;

    [Parameter]
    public IList<ProjectViewModel>? Projects { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public DialogService DialogService { get; set; } = null!;

    protected override void OnInitialized()
    {
        this.filteredProjects = this.Projects;
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        this.filteredProjects = this.Projects;
        this.dataGrid?.Reload();
    }

    private async Task OpenDetailsView(int projectId)
    {
        await this.DialogService.OpenAsync<Details>("Projektdetails",
            new Dictionary<string, object> { { "ProjectId", projectId } },
            ProjectDetailsDialogOptions.GetDefault());
    }

    private void OnProjectsFiltered(IList<ProjectViewModel> projects)
    {
        this.filteredProjects = projects;
        this.dataGrid.Reload();
    }
}
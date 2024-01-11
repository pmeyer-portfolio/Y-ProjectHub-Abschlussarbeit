namespace ProjectHub.Blazor.Pages.Projects;
using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Contracts;

public partial class Details
{
    private Response<ProjectDetailsViewModel> response = new() { Success = true };

    private MarkupString DescriptionMarkupString { get; set; }

    [Parameter]
    public int ProjectId { get; set; }

    [Inject]
    private IProjectService ProjectService { get; set; } = null!;

    private ProjectDetailsViewModel? ProjectDetailsViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.ProjectDetailsViewModel = new ProjectDetailsViewModel();
        this.response = await this.ProjectService.GetById(this.ProjectId);
        if (this.response.Data != null)
        {
            this.ProjectDetailsViewModel = this.response.Data;
        }
        this.DescriptionMarkupString = new MarkupString(this.ProjectDetailsViewModel.Description!);
    }
}
namespace ProjectHub.Blazor.Pages.Projects;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Mappers;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Contracts;

public partial class Details
{
    private Response<ProjectDetailsViewModel> response = new() { Success = true };

    [Parameter]
    public int ProjectId { get; set; }

    [Inject]
    private IProjectDetailsViewModelMapper ProjectDetailsViewModelMapper { get; set; } = null!;

    [Inject]
    private IProjectService ProjectService { get; set; } = null!;

    private ProjectDetailsViewModel? ProjectDetailsViewModel { get; set; } = new ();

    protected override async Task OnInitializedAsync()
    {
        this.response = await this.ProjectService.GetById(this.ProjectId);
        if (this.response.Data != null)
        {
            this.ProjectDetailsViewModel = this.response.Data;
        }
    }
}
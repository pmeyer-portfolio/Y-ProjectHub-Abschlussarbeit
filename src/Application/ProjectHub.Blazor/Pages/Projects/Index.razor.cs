namespace ProjectHub.Blazor.Pages.Projects;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Interfaces;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Contracts;

public partial class Index : IObserver
{
    private Response<IList<ProjectViewModel>> response = new() { Success = true };

    [Inject]
    private IProjectUpdateService ProjectUpdateService { get; set; } = null!;

    public async Task Update()
    {
        await this.LoadProjects();
        this.StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        this.ProjectUpdateService.Attach(this);

        await this.LoadProjects();
    }

    public void Dispose()
    {
        this.ProjectUpdateService.Detach(this);
    }

    private async Task LoadProjects()
    {
        if (this.response.Success)
        {
            this.response = await this.ProjectService.GetAll();
        }
    }
}
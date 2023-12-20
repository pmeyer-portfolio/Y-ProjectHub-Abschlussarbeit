namespace ProjectHub.Blazor.Pages.Projects;

using ProjectHub.Blazor.Models;

public partial class Index
{
    private Response<IList<ProjectViewModel>> response = new() { Success = true };

    protected override async Task OnInitializedAsync()
    {
        if (this.response.Success)
        {
            this.response = await this.ProjectService.GetAll();
        }
    }
}
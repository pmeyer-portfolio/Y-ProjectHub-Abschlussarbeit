namespace ProjectHub.Blazor.Shared;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Constants;

public partial class MainLayout
{
    private bool sidebar1Expanded = true;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    private void ToLogOutPage()
    {
        this.NavigationManager.NavigateTo(ProjectHubRoute.Logout);
    }

    private void ToCreateProjectsPage()
    {
        this.NavigationManager.NavigateTo(ProjectHubRoute.Create);
    }

    private void ToIndexProjectsPage()
    {
        this.NavigationManager.NavigateTo(ProjectHubRoute.Projects);
    }
}
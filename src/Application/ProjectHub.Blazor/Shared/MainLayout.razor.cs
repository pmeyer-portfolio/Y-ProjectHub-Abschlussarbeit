#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Blazor.Shared;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Constants;

public partial class MainLayout
{
    private bool sidebar1Expanded = true;

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private void ToLogOutPage()
    {
        this.NavigationManager.NavigateTo(ProjectHubRoute.LogoutPage);
    }

    private void ToCreateProjectsPage()
    {
        this.NavigationManager.NavigateTo(ProjectHubRoute.CreateProjectsPage);
    }
}
namespace ProjectHub.Blazor.Shared;

using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ProjectHub.Blazor.Constants;

public partial class LoginDisplay
{
    private void BeginLogOut()
    {
        this.Navigation.NavigateToLogout(ProjectHubRoute.AuthenticationLogout);
    }

    private void BeginLogIn()
    {
        this.Navigation.NavigateToLogin(ProjectHubRoute.AuthenticationLogin);
    }
}
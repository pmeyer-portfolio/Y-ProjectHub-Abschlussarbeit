using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ProjectHub.Blazor.Constants;

namespace ProjectHub.Blazor.Shared;

public partial class LoginDisplay
{
    private void BeginLogOut()
    {
        Navigation.NavigateToLogout(ProjectHubRoute.AuthenticationLogout);
    }

    private void BeginLogIn()
    {
        Navigation.NavigateToLogin(ProjectHubRoute.AuthenticationLogin);
    }
}
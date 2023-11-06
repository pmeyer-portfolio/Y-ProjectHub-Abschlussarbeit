using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ProjectHub.Blazor.Constants;

namespace ProjectHub.Blazor.Pages;

public partial class Authentication
{
    [Parameter] public string? Action { get; set; }

    private void LoginSuccessHandler(RemoteAuthenticationState state)
    {
        state.ReturnUrl = ProjectHubRoute.LandingPage;
    }

    private void LogoutSuccessHandler(RemoteAuthenticationState state)
    {
        state.ReturnUrl = ProjectHubRoute.LogoutPage;
    }
}
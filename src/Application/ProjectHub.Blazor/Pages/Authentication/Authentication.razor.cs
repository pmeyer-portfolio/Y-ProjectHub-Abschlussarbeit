namespace ProjectHub.Blazor.Pages.Authentication;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ProjectHub.Blazor.Constants;

public partial class Authentication
{
    [Parameter]
    public string? Action { get; set; }

    private static void LoginSuccessHandler(RemoteAuthenticationState state) { state.ReturnUrl = ProjectHubRoute.Home; }

    private static void LogoutSuccessHandler(RemoteAuthenticationState state) { state.ReturnUrl = ProjectHubRoute.Logout; }
}
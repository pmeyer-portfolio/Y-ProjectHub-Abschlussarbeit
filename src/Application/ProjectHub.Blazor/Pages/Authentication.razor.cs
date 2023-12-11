namespace ProjectHub.Blazor.Pages;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ProjectHub.Blazor.Constants;

public partial class Authentication
{
    [Parameter]
    public string? Action { get; set; }

    private void LoginSuccessHandler(RemoteAuthenticationState state) { state.ReturnUrl = ProjectHubRoute.Index; }

    private void LogoutSuccessHandler(RemoteAuthenticationState state) { state.ReturnUrl = ProjectHubRoute.LogoutPage; }
}
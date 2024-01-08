namespace ProjectHub.Blazor.Pages.Projects;

using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;
using Radzen;

public partial class Create
{
    public required ProjectCreateDto projectCreateDto;

    [Inject]
    public required IProjectService Service { get; set; }

    [Inject]
    public required NotificationService NotificationService { get; set; }

    [Inject]
    public required AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private const int Duration = 4000;

    protected override async Task OnInitializedAsync()
    {
        this.projectCreateDto = new ProjectCreateDto();
        await Task.CompletedTask;
    }

    private async Task Submit()
    {
        this.projectCreateDto.Created = DateTimeOffset.UtcNow;
        await this.SetLoggedInUserAsProjectCreator();

        Response<int> response = await this.Service.Create(this.projectCreateDto);
        switch (response.Success)
        {
            case true:
                this.projectCreateDto = new ProjectCreateDto();
                this.ShowNotification(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Erfolgreich erstellt",
                    Detail = NotificationMessages.SuccessCreated,
                    Duration = Duration
                });
                break;
            case false:
                this.ShowNotification(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = response.Title,
                    Detail = response.ValidationErrors,
                    Duration = Duration,
                });
                break;
        }
    }

    private async Task SetLoggedInUserAsProjectCreator()
    {
        AuthenticationState authState = await this.AuthenticationStateProvider.GetAuthenticationStateAsync();
        ClaimsPrincipal user = authState.User;

        UserCreateDto userCreateDto = new();

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            userCreateDto.Email = user.FindFirst(c => c.Type == "email")?.Value;
            userCreateDto.FirstName = user.FindFirst(c => c.Type == "family_name")?.Value;
            userCreateDto.LastName = user.FindFirst(c => c.Type == "given_name")?.Value;
        }

        this.projectCreateDto.User = userCreateDto;
    }

    private void ShowNotification(NotificationMessage message)
    {
        this.NotificationService.Notify(message);
    }
}
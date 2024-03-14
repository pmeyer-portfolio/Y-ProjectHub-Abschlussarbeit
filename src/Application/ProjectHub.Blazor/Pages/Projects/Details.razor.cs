namespace ProjectHub.Blazor.Pages.Projects;

using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Project.Interfaces;
using Radzen;

public partial class Details
{
    [CascadingParameter]
    public Task<AuthenticationState> AuthState { get; set; } = null!;

    private ProjectUpdateModel ProjectUpdateModel { get; set; } = null!;

    private ProjectDetailsViewModel ProjectDetailsViewModel { get; set; } = null!;

    [Parameter]
    public int ProjectId { get; set; }

    [Inject]
    private IProjectService ProjectService { get; set; } = null!;

    [Inject]
    private IProjectUpdateService ProjectUpdateService { get; set; } = null!;

    [Inject]
    private DialogService DialogService { get; set; } = null!;

    [Inject]
    private IEditDialogInitializer EditDialogInitializer { get; set; } = null!;

    private bool EditIconsVisible { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.ProjectDetailsViewModel = await this.ProjectService.LoadProjectDetails(this.ProjectId);
        this.ProjectUpdateModel = this.CreateProjectUpdateModelFromDetails(this.ProjectDetailsViewModel);

        this.EditDialogInitializer.SetProjectDetailsViewModel(this.ProjectDetailsViewModel);
        this.EditDialogInitializer.SetProjectUpdateModel(this.ProjectUpdateModel);

        await this.ChangeEditIconVisibility();
    }

    private async Task ChangeEditIconVisibility()
    {
        ClaimsPrincipal user = await this.GetClaimsPrincipal();

        string? userEmail = user.FindFirst(c => c.Type == PrincipalAttributes.Email)?.Value;

        if (this.UserIsInRole(user, userEmail))
        {
            this.EditIconsVisible = true;
        }
    }

    private bool UserIsInRole(ClaimsPrincipal user, string? userEmail)
    {
        return user.IsInRole(Roles.SuperAdmin) ||
               (user.IsInRole(Roles.ProjectAdmin) && userEmail == this.ProjectDetailsViewModel.CreatorEmail);
    }

    private async Task<ClaimsPrincipal> GetClaimsPrincipal()
    {
        AuthenticationState authState = await this.AuthState;
        ClaimsPrincipal user = authState.User;
        return user;
    }

    private async Task OpenEditDialog(string propertyName)
    {
        await this.EditDialogInitializer.OpenEditDialogAsync(propertyName);
    }

    private async Task OnUpdate()
    {
        Response<ProjectUpdateDto> result =
            await this.ProjectUpdateService.UpdateProject(this.ProjectUpdateModel);

        if (result.Success)
        {
            this.ProjectUpdateModel = new ProjectUpdateModel();
            this.DialogService.Close();
        }
    }

    private async Task OnClose(MouseEventArgs obj)
    {
        ConfirmOptions confirmOptions = new()
        {
            OkButtonText = ConfirmDialog.OkButtonText,
            CancelButtonText = ConfirmDialog.CancelButtonText
        };

        bool? result = await this.DialogService.Confirm(
            ConfirmDialog.UnSavedMessage,
            ConfirmDialog.UnSavedTitle,
            confirmOptions
        );

        if (result == true)
        {
            this.DialogService.Close();
        }
    }

    private ProjectUpdateModel CreateProjectUpdateModelFromDetails(ProjectDetailsViewModel detailsViewModel)
    {
        return new ProjectUpdateModel
        {
            projectHaveUpdates = false,
            Id = this.ProjectId,
            TribeId = detailsViewModel.TribeViewModel.Id,
            ProgrammingLanguageIds = detailsViewModel.ProgrammingLanguageViewModels
                .Select(model => model.Id).ToList(),
            Status = detailsViewModel.Status,
            Title = detailsViewModel.Title!,
            Description = detailsViewModel.Description,
        };
    }
}
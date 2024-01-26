namespace ProjectHub.Blazor.Pages.Projects;

using Microsoft.AspNetCore.Components;
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

    protected override async Task OnInitializedAsync()
    {
        this.ProjectDetailsViewModel = await this.ProjectService.LoadProjectDetails(this.ProjectId);
        this.ProjectUpdateModel = this.CreateProjectUpdateModelFromDetails(this.ProjectDetailsViewModel);

        this.EditDialogInitializer.SetProjectDetailsViewModel(this.ProjectDetailsViewModel);
        this.EditDialogInitializer.SetProjectUpdateModel(this.ProjectUpdateModel);
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
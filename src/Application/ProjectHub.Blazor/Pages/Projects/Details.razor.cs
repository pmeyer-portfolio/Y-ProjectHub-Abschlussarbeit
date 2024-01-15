namespace ProjectHub.Blazor.Pages.Projects;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;
using Radzen;

public partial class Details
{
    private string? updatedPropertyValue;

    private ProjectDetailsViewModel? ProjectDetailsViewModel { get; set; } = new();

    [Parameter]
    public int ProjectId { get; set; }

    [Inject]
    private IProjectDetailsService ProjectDetailsService { get; set; } = null!;

    [Inject]
    private IProjectUpdateService ProjectUpdateService { get; set; } = null!;

    [Inject]
    private DialogService DialogService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        this.ProjectDetailsViewModel = await this.ProjectDetailsService.LoadProjectDetails(this.ProjectId);
    }

    private async Task OpenEditDialog(string property, string value)
    {
        string? result = await this.DialogService.OpenAsync<Edit>($"{property} bearbeiten",
            new Dictionary<string, object> { { nameof(Edit.Value), value } },
            ProjectDetailsDialogOptions.GetEdit());

        if (result != null)
        {
            this.updatedPropertyValue = result;

            this.ProjectDetailsViewModel?.UpdateProperty(property, this.updatedPropertyValue);
        }
    }

    private async Task OnUpdate(MouseEventArgs obj)
    {
        Response<ProjectUpdateDto> result =
            await this.ProjectUpdateService.UpdateProjectStatus(this.ProjectId, this.updatedPropertyValue);
        if (result.Success)
        {
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
}
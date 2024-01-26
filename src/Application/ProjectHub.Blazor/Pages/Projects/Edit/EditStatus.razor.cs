namespace ProjectHub.Blazor.Pages.Projects.Edit;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Project;

public partial class EditStatus
{
    private string? DeprecatedStatus { get; set; }

    private string? UpdatedStatus { get; set; }

    private ProjectStatusViewModel? StatusViewModel { get; set; }

    protected override void OnInitialized()
    {
        this.DeprecatedStatus = this.ProjectDetailsViewModel.Status;
    }

    private void HandleItemSelected(BaseViewModel baseViewModel)
    {
        if (baseViewModel is ProjectStatusViewModel projectStatusViewModel)
        {
            this.StatusViewModel = projectStatusViewModel;
            this.UpdatedStatus = baseViewModel.Name;
        }
    }

    protected override void OnOkClick()
    {
        if (this.StatusViewModel != null)
        {
            this.ProjectDetailsViewModel.Status = this.StatusViewModel.Name;
        }

        this.DialogService.Close(this.ProjectDetailsViewModel);
    }
}
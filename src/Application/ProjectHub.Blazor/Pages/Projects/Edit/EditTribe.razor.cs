namespace ProjectHub.Blazor.Pages.Projects.Edit;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Tribe;

public partial class EditTribe : BaseEdit
{
    private string? DeprecatedTribeName { get; set; }

    private string? UpdatedTribeName { get; set; }

    private TribeViewModel? TribeViewModel { get; set; }

    protected override void OnInitialized()
    {
        this.DeprecatedTribeName = this.ProjectDetailsViewModel.TribeViewModel.Name;
    }

    protected void HandleItemSelected(BaseViewModel baseViewModel)
    {
        if (baseViewModel is TribeViewModel tribeViewModel)
        {
            this.TribeViewModel = tribeViewModel;
            this.UpdatedTribeName = tribeViewModel.Name;
        }
    }

    protected override void OnOkClick()
    {
        if (this.TribeViewModel != null)
        {
            this.ProjectDetailsViewModel.TribeViewModel.Id = this.TribeViewModel.Id;
            this.ProjectDetailsViewModel.TribeViewModel.Name = this.TribeViewModel.Name;
        }

        this.DialogService.Close(this.ProjectDetailsViewModel);
    }
}
namespace ProjectHub.Blazor.Pages.Projects.Edit;

using Microsoft.AspNetCore.Components;

public partial class EditDescription : BaseEdit
{
    private MarkupString UpdatedDescription { get; set; }

    private MarkupString DeprecatedDescription { get; set; }

    protected override void OnInitialized()
    {
        this.DeprecatedDescription = this.ProjectDetailsViewModel.Description;
    }

    private void HandleInput(string input)
    {
        this.UpdatedDescription = new MarkupString(input);
    }

    protected override void OnOkClick()
    {
        this.ProjectDetailsViewModel.Description = this.UpdatedDescription;
        this.DialogService.Close(this.ProjectDetailsViewModel);
    }
}
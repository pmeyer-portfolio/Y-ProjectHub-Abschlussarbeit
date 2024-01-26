namespace ProjectHub.Blazor.Pages.Projects.Edit;

public partial class EditTitle : BaseEdit
{
    private string? DeprecatedTitle { get; set; }

    private string? UpdatedTitle { get; set; }

    protected override void OnInitialized()
    {
        this.DeprecatedTitle = this.ProjectDetailsViewModel.Title;
    }

    private void OnTitleChange(string input)
    {
        this.UpdatedTitle = input;
    }

    protected override void OnOkClick()
    {
        this.ProjectDetailsViewModel.Title = this.UpdatedTitle;
        this.DialogService.Close(this.ProjectDetailsViewModel);
    }
}
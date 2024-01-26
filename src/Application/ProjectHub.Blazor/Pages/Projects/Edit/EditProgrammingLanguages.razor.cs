namespace ProjectHub.Blazor.Pages.Projects.Edit;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Models.ProgrammingLanguage;

public partial class EditProgrammingLanguages : BaseEdit
{
    private IList<ProgrammingLanguageViewModel>
        programmingLanguageViewModels = new List<ProgrammingLanguageViewModel>();

    private IList<ProgrammingLanguageViewModel>? ProgrammingLanguages { get; set; }

    private MarkupString? DeprecatedValueNames { get; set; }

    private MarkupString? UpdatedValueNames { get; set; }

    [Inject]
    public IProjectHubDataInitializer ProjectHubDataInitializer { get; set; } = null!;

    private const string HtmlLineBreak = "<br>";

    protected override async Task OnInitializedAsync()
    {
        this.ProgrammingLanguages = await this.ProjectHubDataInitializer.InitializeProgrammingLanguages();
        string combinedString = string.Join(HtmlLineBreak,
            this.ProjectDetailsViewModel.ProgrammingLanguageViewModels.Select(model => model.Name));
        this.DeprecatedValueNames = new MarkupString(combinedString);
    }

    private void HandleItemsSelected(List<ProgrammingLanguageViewModel> programmingLanguageViewModels)
    {
        this.programmingLanguageViewModels = programmingLanguageViewModels;

        string combinedString = string.Join(HtmlLineBreak, programmingLanguageViewModels
            .Select(model => model.Name));

        this.UpdatedValueNames = new MarkupString(combinedString);
    }

    protected override void OnOkClick()
    {
        this.ProjectDetailsViewModel.ProgrammingLanguageViewModels = this.programmingLanguageViewModels;
        this.DialogService.Close(this.ProjectDetailsViewModel);
        this.StateHasChanged();
    }

    private void OnValueChanged(object value)
    {
        if (value is IList<ProgrammingLanguageViewModel> selectedItems)
        {
            this.ProjectDetailsViewModel.ProgrammingLanguageViewModels = selectedItems
                .GroupBy(p => p.Id)
                .Select(g => g.First())
                .ToList();
        }
    }

    private void OnChanged(object value)
    {
        if (value is EnumerableQuery<ProgrammingLanguageViewModel> programmingLanguageViewModels)
        {
            this.HandleItemsSelected(programmingLanguageViewModels.ToList());
        }
    }
}
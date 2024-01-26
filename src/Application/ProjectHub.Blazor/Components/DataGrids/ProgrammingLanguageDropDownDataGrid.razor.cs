namespace ProjectHub.Blazor.Components.DataGrids;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Models.ProgrammingLanguage;

public partial class ProgrammingLanguageDropDownDataGrid
{
    [Parameter]
    public IList<string>? CurrentValues { get; set; }

    [Parameter]
    public EventCallback<IList<string>> OnProgrammingLanguageNameSelected { get; set; }

    [Parameter]
    public EventCallback<IList<ProgrammingLanguageViewModel>> OnProgrammingLanguagesSelected { get; set; }

    [Inject]
    public IProjectHubDataInitializer ProjectHubDataInitializer { get; set; } = null!;

    private IList<ProgrammingLanguageViewModel>? ProgrammingLanguages { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.ProgrammingLanguages = await this.ProjectHubDataInitializer.InitializeProgrammingLanguages();
    }

    private void OnValueChanged(object value)
    {
        if (value is EnumerableQuery<ProgrammingLanguageViewModel> programmingLanguageViewModels)
        {
            this.OnProgrammingLanguagesSelected.InvokeAsync(programmingLanguageViewModels.ToList());
        }
    }
}
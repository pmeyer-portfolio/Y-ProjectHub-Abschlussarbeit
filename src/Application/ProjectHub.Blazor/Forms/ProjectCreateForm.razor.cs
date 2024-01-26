namespace ProjectHub.Blazor.Forms;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.Base;

public partial class ProjectCreateForm
{
    [Parameter]
    public required ProjectCreateDto ProjectCreateDto { get; set; }

    private void OnDescriptionChange(string input)
    {
        this.ProjectCreateDto.Description = input;
    }

    private void OnTribeChange(TribeViewModel tribeViewModel)
    {
        this.ProjectCreateDto.TribeId = tribeViewModel.Id;
    }

    private void OnProgrammingLanguageChange(IList<ProgrammingLanguageViewModel> programmingLanguageViewModels)
    {
        this.ProjectCreateDto.Languages = programmingLanguageViewModels.Select(model => model.Id).ToList();
    }

    private void OnTitleChange(string input)
    {
        this.ProjectCreateDto.Title = input;
    }
}
namespace ProjectHub.Blazor.Initializer;

using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Options;
using ProjectHub.Blazor.Pages.Projects.Edit;
using Radzen;

public class EditDialogInitializer : IEditDialogInitializer
{
    private ProjectDetailsViewModel projectDetailsViewModel = null!;

    private ProjectUpdateModel projectUpdateModel = null!;

    private DialogService DialogService { get; }

    public EditDialogInitializer(DialogService dialogService)
    {
        this.DialogService = dialogService;
    }

    public async Task OpenEditDialogAsync(string propertyName)
    {
        ProjectDetailsViewModel? updatedProjectDetailsViewModel = null;

        switch (propertyName)
        {
            case nameof(ProjectDetailsViewModel.TribeViewModel.Name):
                updatedProjectDetailsViewModel = await this.OpenDialogAsync<EditTribe>(
                    EditDialogTitles.EditTribe,
                    ProjectDetailsDialogOptions.GetTribeOptions());
                break;
            case nameof(ProjectDetailsViewModel.ProgrammingLanguageViewModels):
                updatedProjectDetailsViewModel = await this.OpenDialogAsync<EditProgrammingLanguages>(
                    EditDialogTitles.EditProgramingLanguages,
                    ProjectDetailsDialogOptions.GetProgrammingLanguagesOptions());
                break;
            case nameof(ProjectDetailsViewModel.Status):
                updatedProjectDetailsViewModel = await this.OpenDialogAsync<EditStatus>(
                    EditDialogTitles.EditStatus,
                    ProjectDetailsDialogOptions.GetStatusOptions());
                break;
            case nameof(ProjectDetailsViewModel.Title):
                updatedProjectDetailsViewModel = await this.OpenDialogAsync<EditTitle>(
                    EditDialogTitles.EditTitle,
                    ProjectDetailsDialogOptions.GetTitleOptions());
                break;
            case nameof(ProjectDetailsViewModel.Description):
                updatedProjectDetailsViewModel = await this.OpenDialogAsync<EditDescription>(
                    EditDialogTitles.EditDescription,
                    ProjectDetailsDialogOptions.GetDescriptionOptions());
                break;
        }

        if (updatedProjectDetailsViewModel != null)
        {
            this.projectUpdateModel.projectHaveUpdates = true;
            this.UpdateProjectUpdateModel(propertyName, updatedProjectDetailsViewModel);
        }
    }

    public void SetProjectDetailsViewModel(ProjectDetailsViewModel model)
    {
        this.projectDetailsViewModel = model;
    }

    public void SetProjectUpdateModel(ProjectUpdateModel model)
    {
        this.projectUpdateModel = model;
    }

    private async Task<ProjectDetailsViewModel> OpenDialogAsync<TEdit>(string title, DialogOptions options)
        where TEdit : BaseEdit
    {
        Dictionary<string, object> parameters = new()
        {
            ["ProjectDetailsViewModel"] = this.projectDetailsViewModel
        };

        dynamic? dialogResult = await this.DialogService.OpenAsync<TEdit>(title, parameters, options);

        if (dialogResult != null)
        {
            return (dialogResult as ProjectDetailsViewModel)!;
        }

        return null!;
    }

    private void UpdateProjectUpdateModel(string propertyName, ProjectDetailsViewModel updatedProjectDetailsViewModel)
    {
        switch (propertyName)
        {
            case nameof(ProjectDetailsViewModel.TribeViewModel.Name):
                this.projectUpdateModel.TribeId = updatedProjectDetailsViewModel.TribeViewModel!.Id;
                break;
            case nameof(ProjectDetailsViewModel.ProgrammingLanguageViewModels):
                this.projectUpdateModel.ProgrammingLanguageIds =
                    updatedProjectDetailsViewModel.ProgrammingLanguageViewModels.Select(model => model.Id).ToList();
                break;
            case nameof(ProjectDetailsViewModel.Status):
                this.projectUpdateModel.Status = updatedProjectDetailsViewModel.Status;
                break;
            case nameof(ProjectDetailsViewModel.Title):
                this.projectUpdateModel.Title = updatedProjectDetailsViewModel.Title!;
                break;
            case nameof(ProjectDetailsViewModel.Description):
                this.projectUpdateModel.Description = updatedProjectDetailsViewModel.Description;
                break;
        }
    }
}
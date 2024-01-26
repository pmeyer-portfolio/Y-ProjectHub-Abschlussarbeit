using ProjectHub.Blazor.Models.Project;

namespace ProjectHub.Blazor.Initializer;

public interface IEditDialogInitializer
{
    Task OpenEditDialogAsync(string propertyName);
    void SetProjectDetailsViewModel(ProjectDetailsViewModel projectDetailsViewModel);
    void SetProjectUpdateModel(ProjectUpdateModel projectUpdateModel);
}
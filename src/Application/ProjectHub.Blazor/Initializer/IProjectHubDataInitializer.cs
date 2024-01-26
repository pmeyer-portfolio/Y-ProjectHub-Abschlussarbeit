namespace ProjectHub.Blazor.Initializer;

using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Models.Tribe;

public interface IProjectHubDataInitializer
{
    Task<IList<TribeViewModel>> InitializeTribes();
    Task<IList<ProgrammingLanguageViewModel>> InitializeProgrammingLanguages();
    Task<IList<ProjectStatusViewModel>> InitializeStatus();
}
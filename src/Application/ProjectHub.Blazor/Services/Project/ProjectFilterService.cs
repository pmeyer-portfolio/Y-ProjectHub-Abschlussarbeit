namespace ProjectHub.Blazor.Services.Project;

using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Project.Interfaces;

public class ProjectFilterService : IProjectFilterService
{
    public IList<ProjectViewModel> Filter(ProjectFilterModel filterModel, IList<ProjectViewModel> projects)
    {
        return projects.Where(project => MatchesFilter(project, filterModel)).ToList();
    }

    private static bool MatchesFilter(ProjectViewModel project, ProjectFilterModel filterModel)
    {
        return MatchesTribeName(project.TribeViewModel.Name, filterModel.TribeName) &&
               MatchesStatus(project.Status, filterModel.Status) &&
               MatchesProgrammingLanguage(project.ProgrammingLanguageViewModels.Select(model => model.Name).ToList(), filterModel.ProgrammingLanguage) &&
               MatchesDateTime(project.CreatedAt, filterModel);
    }

    public static bool MatchesTribeName(string? projectTribeName, string? filterTribeName)
    {
        return string.IsNullOrEmpty(filterTribeName) || projectTribeName == filterTribeName;
    }

    public static bool MatchesStatus(string? projectStatus, string? filterStatus)
    {
        return string.IsNullOrEmpty(filterStatus) || projectStatus == filterStatus;
    }

    public static bool MatchesProgrammingLanguage(IList<string> projectProgrammingLanguages,
        string? filterProgrammingLanguage)
    {
        return string.IsNullOrEmpty(filterProgrammingLanguage) ||
               projectProgrammingLanguages.Contains(filterProgrammingLanguage);
    }

    public static bool MatchesDateTime(DateTime projectCreatedAt, ProjectFilterModel filterModel)
    {
        if (filterModel.SpecificDateTime.HasValue)
        {
            return projectCreatedAt.Date == filterModel.SpecificDateTime.Value.Date;
        }

        bool isAfterFromDateTime = !filterModel.FromDateTime.HasValue ||
                                   projectCreatedAt.Date >= filterModel.FromDateTime.Value.Date;
        bool isBeforeToDateTime = !filterModel.ToDateTime.HasValue ||
                                  projectCreatedAt.Date <= filterModel.ToDateTime.Value.Date;
        return isAfterFromDateTime && isBeforeToDateTime;
    }
}
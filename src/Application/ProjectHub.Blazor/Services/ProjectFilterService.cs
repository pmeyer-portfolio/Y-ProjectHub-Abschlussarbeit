namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Contracts;

public class ProjectFilterService : IProjectFilterService
{
    public IList<ProjectViewModel> Filter(ProjectFilterModel filterModel, IList<ProjectViewModel> projects)
    {
        return projects.Where(project => MatchesFilter(project, filterModel)).ToList();
    }

    private static bool MatchesFilter(ProjectViewModel project, ProjectFilterModel filterModel)
    {
        return MatchesTribeName(project.TribeName, filterModel.TribeName) &&
               MatchesStatus(project.Status, filterModel.Status) &&
               MatchesProgrammingLanguage(project.ProgrammingLanguages, filterModel.ProgrammingLanguage) &&
               MatchesDateTime(project.CreatedAt, filterModel);
    }

    public static bool MatchesTribeName(string? projectTribeName, string? filterTribeName)
    {
        return string.IsNullOrEmpty(filterTribeName) || projectTribeName == filterTribeName;
    }

    public static bool MatchesStatus(string? projectStatus, string? filterStatus)
    {
        return string.IsNullOrEmpty(filterStatus) || (projectStatus == filterStatus);
    }

    public static bool MatchesProgrammingLanguage(IList<string> projectProgrammingLanguages, string? filterProgrammingLanguage)
    {
        return string.IsNullOrEmpty(filterProgrammingLanguage) || projectProgrammingLanguages.Contains(filterProgrammingLanguage);
    }

    public static bool MatchesDateTime(DateTime projectCreatedAt, ProjectFilterModel filterModel)
    {
        if (filterModel.SpecificDateTime.HasValue)
        {
            return projectCreatedAt.Date == filterModel.SpecificDateTime.Value.Date;
        }
        else
        {
            bool isAfterFromDateTime = !filterModel.FromDateTime.HasValue || projectCreatedAt.Date >= filterModel.FromDateTime.Value.Date;
            bool isBeforeToDateTime = !filterModel.ToDateTime.HasValue || projectCreatedAt.Date <= filterModel.ToDateTime.Value.Date;
            return isAfterFromDateTime && isBeforeToDateTime;
        }
    }
}

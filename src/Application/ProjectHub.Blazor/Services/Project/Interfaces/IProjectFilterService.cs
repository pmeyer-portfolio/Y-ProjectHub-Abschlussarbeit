namespace ProjectHub.Blazor.Services.Project.Interfaces;

using ProjectHub.Blazor.Models.Project;

public interface IProjectFilterService
{
    IList<ProjectViewModel> Filter(ProjectFilterModel projectFilterModel, IList<ProjectViewModel> projects);
}
namespace ProjectHub.Blazor.Services.Contracts;

using ProjectHub.Blazor.Models;

public interface IProjectFilterService
{
    IList<ProjectViewModel> Filter(ProjectFilterModel projectFilterModel, IList<ProjectViewModel> projects);
}
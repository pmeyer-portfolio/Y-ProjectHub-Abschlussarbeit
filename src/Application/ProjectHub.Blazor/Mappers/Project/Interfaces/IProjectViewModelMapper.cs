namespace ProjectHub.Blazor.Mappers.Project.Interfaces;

using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;

public interface IProjectViewModelMapper
{
    ProjectViewModel Map(ProjectDto projectDto);

    IList<ProjectViewModel> Map(IList<ProjectDto> projectDto);
}
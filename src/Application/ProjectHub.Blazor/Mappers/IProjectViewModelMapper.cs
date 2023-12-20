namespace ProjectHub.Blazor.Mappers;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public interface IProjectViewModelMapper
{
    ProjectViewModel Map(ProjectDto projectDto);

    IList<ProjectViewModel> Map(IList<ProjectDto> projectDto);
}
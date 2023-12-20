namespace ProjectHub.Abstractions.IMappers.Project;

using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Data.Abstractions.Entities;

public interface IProjectDtoMapper
{
  
    ProjectDto Map(Project project);
    IList<ProjectDto> Map(IList<Project>? projects);
}
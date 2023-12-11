namespace ProjectHub.Abstractions.IMappers.Project;

using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Data.Abstractions.Entities;

public interface IProjectDtoMapper
{
  
    ProjectViewDto Map(Project project);
    IList<ProjectViewDto> Map(IList<Project>? projects);
}
namespace ProjectHub.Abstractions.IMappers.Project;

using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Data.Abstractions.Entities;

public interface IProjectMapper
{
    Project Map(ProjectCreateDto projectCreateDto);
    IList<Project> Map(IList<ProjectCreateDto> dtos);
    Project Map(Project project, ProjectUpdateDto projectUpdateDto);
}
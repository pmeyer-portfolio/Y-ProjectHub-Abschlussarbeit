namespace ProjectHub.Abstractions.IService.Project;

using ProjectHub.Abstractions.DTOs.Project;

public interface IProjectService

{
    Task InsertAsync(ProjectCreateDto dto);
}
namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Services.Base;

public interface IProjectService
{
    Task<Response<int>> Create(ProjectCreateDto projectCreateDto);
}
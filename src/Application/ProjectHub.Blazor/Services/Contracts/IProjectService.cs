namespace ProjectHub.Blazor.Services.Contracts;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public interface IProjectService
{
    Task<Response<int>> Create(ProjectCreateDto projectCreateDto);
    Task<Response<IList<ProjectViewModel>>> GetAll();
    Task<Response<ProjectDetailsViewModel>> GetById(int id);
    Task<Response<ProjectUpdateDto>> Update(ProjectUpdateModel updateModel);
}
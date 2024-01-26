namespace ProjectHub.Blazor.Services.Project.Interfaces;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;

public interface IProjectService
{
    Task<Response<int>> Create(ProjectCreateDto projectCreateDto);
    Task<Response<IList<ProjectViewModel>>> GetAll();
    Task<Response<ProjectDetailsViewModel>> GetById(int id);
    Task<Response<ProjectUpdateDto>> Update(ProjectUpdateModel updateModel);
    Task<ProjectDetailsViewModel> LoadProjectDetails(int projectId);
}
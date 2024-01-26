namespace ProjectHub.Blazor.Services.Project.Interfaces;

using ProjectHub.Blazor.Interfaces;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;

public interface IProjectUpdateService : ISubject
{
    Task<Response<ProjectUpdateDto>> UpdateProject(ProjectUpdateModel projectUpdateModel);
}
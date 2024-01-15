namespace ProjectHub.Blazor.Services.Contracts;

using ProjectHub.Blazor.Interfaces;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public interface IProjectUpdateService : ISubject
{
    Task<Response<ProjectUpdateDto>> UpdateProjectStatus(int projectId, string newStatus);
}
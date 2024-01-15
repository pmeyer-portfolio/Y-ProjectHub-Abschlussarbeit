using ProjectHub.Blazor.Models;

namespace ProjectHub.Blazor.Services.Contracts;

public interface IProjectDetailsService
{
    Task<ProjectDetailsViewModel> LoadProjectDetails(int projectId);
}
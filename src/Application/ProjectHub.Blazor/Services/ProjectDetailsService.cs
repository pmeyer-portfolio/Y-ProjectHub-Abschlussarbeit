namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Contracts;
using Radzen;

public class ProjectDetailsService : IProjectDetailsService
{
    private readonly IProjectService projectService;

    public ProjectDetailsService(IProjectService projectService, NotificationService notificationService)
    {
        this.projectService = projectService;
    }

    public async Task<ProjectDetailsViewModel> LoadProjectDetails(int projectId)
    {
        Response<ProjectDetailsViewModel> response = await this.projectService.GetById(projectId);
        return response.Data ?? new ProjectDetailsViewModel();
    }
}
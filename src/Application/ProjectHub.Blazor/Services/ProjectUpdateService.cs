namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Interfaces;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;
using Radzen;

public class ProjectUpdateService : IProjectUpdateService
{
    private readonly NotificationService notificationService;
    private readonly IProjectService projectService;
    private readonly List<IObserver> observers = new();

    public ProjectUpdateService(IProjectService projectService, NotificationService notificationService)
    {
        this.projectService = projectService;
        this.notificationService = notificationService;
    }

    public async Task<Response<ProjectUpdateDto>> UpdateProjectStatus(int projectId, string newStatus)
    {
        ProjectUpdateModel updateModel = new()
        {
            Id = projectId,
            Status = newStatus
        };

        Response<ProjectUpdateDto> updateResponse = await this.projectService.Update(updateModel);

        if (updateResponse.Success)
        {
            this.Notify();
        }

        this.NotifyUpdateResult(updateResponse.Success);
        return updateResponse;
    }

    public void Attach(IObserver observer)
    {
        this.observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this.observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in this.observers)
        {
            observer.Update();
        }
    }

    private void NotifyUpdateResult(bool success)
    {
        NotificationMessage message = new()
        {
            Severity = success
                ? NotificationSeverity.Success
                : NotificationSeverity.Error,
            Summary = success
                ? NotificationSummary.UpdateSuccess
                : NotificationSummary.UpdateIncomplete,
            Detail = success
                ? NotificationDetails.UpdateSuccess
                : NotificationDetails.UpdateIncomplete
        };

        this.notificationService.Notify(message);
    }
}
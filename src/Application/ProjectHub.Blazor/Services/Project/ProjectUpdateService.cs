namespace ProjectHub.Blazor.Services.Project;

using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Interfaces;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Project.Interfaces;
using Radzen;

public class ProjectUpdateService : IProjectUpdateService
{
    private readonly INotificationServiceWrapper notificationServiceWrapper;
    private readonly List<IObserver> observers = new();
    private readonly IProjectService projectService;
    
    public ProjectUpdateService(IProjectService projectService, INotificationServiceWrapper notificationServiceWrapper)
    {
        this.projectService = projectService;
        this.notificationServiceWrapper = notificationServiceWrapper;
    }

    public async Task<Response<ProjectUpdateDto>> UpdateProject(ProjectUpdateModel updateModel)
    {
        if (!updateModel.projectHaveUpdates)
        {
            this.NotifyUpdateFailure();
            return new Response<ProjectUpdateDto>
            {
                Success = false,
            };
        }

        Response<ProjectUpdateDto> updateResponse = await this.projectService.Update(updateModel);

        if (updateResponse.Success)
        {
            this.NotifyUpdate();
            this.NotifyUpdateSuccess();
        }
        else
        {
            this.NotifyUpdateFailure(updateResponse.DetailMessage ?? string.Empty);
        }

        return updateResponse;
    }

    private void NotifyUpdateSuccess()
    {
        NotificationMessage message = new()
        {
            Severity = NotificationSeverity.Success,
            Summary = NotificationSummary.UpdateSuccess,
            Detail = NotificationDetails.UpdateSuccess
        };

        this.notificationServiceWrapper.Notify(message);
    }

    private void NotifyUpdateFailure()
    {
        this.NotifyUpdateFailure(NotificationDetails.UpdateIncomplete);
    }

    private void NotifyUpdateFailure(string messageDetail)
    {
        NotificationMessage message = new()
        {
            Severity = NotificationSeverity.Error,
            Summary = NotificationSummary.UpdateIncomplete,
            Detail = messageDetail
        };

        this.notificationServiceWrapper.Notify(message);
    }

    public void Attach(IObserver observer)
    {
        this.observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this.observers.Remove(observer);
    }

    public void NotifyUpdate()
    {
        foreach (IObserver observer in this.observers)
        {
            observer.Update();
        }
    }
}
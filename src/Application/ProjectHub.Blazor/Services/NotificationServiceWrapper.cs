namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Interfaces;
using Radzen;

public class NotificationServiceWrapper : INotificationServiceWrapper
{
    private NotificationService NotificationService { get; }

    public NotificationServiceWrapper(NotificationService notificationService)
    {
        this.NotificationService = notificationService;
    }

    public void Notify(NotificationMessage message)
    {
        this.NotificationService.Notify(message);
    }
}
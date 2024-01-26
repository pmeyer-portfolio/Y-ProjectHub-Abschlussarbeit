namespace ProjectHub.Blazor.Services;
using ProjectHub.Blazor.Interfaces;
using Radzen;

public class NotificationServiceWrapperWrapper :  INotificationServiceWrapper
{
    public NotificationServiceWrapperWrapper(NotificationService notificationService)
    {
        this.NotificationService = notificationService;
    }

    private NotificationService NotificationService { get; set; }

    public void Notify(NotificationMessage message)
    {
       this.NotificationService.Notify(message);
    }
}
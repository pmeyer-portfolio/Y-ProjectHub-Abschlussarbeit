namespace ProjectHub.Blazor.Interfaces;

using Radzen;

public interface INotificationServiceWrapper
{
    void Notify(NotificationMessage message);
}
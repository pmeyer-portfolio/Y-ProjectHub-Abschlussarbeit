namespace ProjectHub.Blazor.Interfaces;

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void NotifyUpdate();
}
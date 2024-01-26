namespace ProjectHub.Blazor.Models.Tribe;

using ProjectHub.Blazor.Constants;

public class TribeViewModel : BaseViewModel
{
    public static TribeViewModel NotAssigned { get; } = new() { Id = -1, Name = PlaceHolder.NotAssigned };
}
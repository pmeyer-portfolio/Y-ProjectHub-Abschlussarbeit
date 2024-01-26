namespace ProjectHub.Blazor.Mappers.Tribe;

using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.Base;

public interface ITribeViewModelMapper
{
    TribeViewModel Map(TribeDto tribeDto);
    IList<TribeViewModel> Map(IList<TribeDto> tribeDtos);
}
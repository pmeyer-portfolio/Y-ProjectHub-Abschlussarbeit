namespace ProjectHub.Blazor.Mappers.Tribe;

using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.Base;

public class TribeViewModelMapper : ITribeViewModelMapper 

{
    public TribeViewModel Map(TribeDto tribeDto)
    {
        return new TribeViewModel()
        {
            Id = tribeDto.Id,
            Name = tribeDto.Name,
        };
    }

    public IList<TribeViewModel> Map(IList<TribeDto> tribeDtos)
    {
        return tribeDtos.Select(this.Map).ToList();
    }
}

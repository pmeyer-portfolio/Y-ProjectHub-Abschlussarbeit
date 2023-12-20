namespace ProjectHub.Mappers.Tribes;

using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Abstractions.IMappers.Tribe;
using ProjectHub.Data.Abstractions.Entities;

public class TribeDtoMapper : ITribeDtoMapper
{
    public TribeDto Map(Tribe tribe)
    {
        TribeDto dto = new()
        {
            Id = tribe.Id,
            Name = tribe.Name,
        };
        return dto;
    }

    public IList<TribeDto> Map(IList<Tribe> tribes)
    {
        return tribes.Select(this.Map).ToList();
    }
}
namespace ProjectHub.Abstractions.IMappers.Tribe;

using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Data.Abstractions.Entities;

public interface ITribeDtoMapper
{
    TribeDto Map(Tribe tribe);
    IList<TribeDto> Map(IList<Tribe> tribes);
}
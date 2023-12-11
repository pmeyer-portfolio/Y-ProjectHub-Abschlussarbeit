namespace ProjectHub.Abstractions.IService.Tribe;

using ProjectHub.Abstractions.DTOs.Tribe;

public interface ITribeService
{
    Task<IList<TribeDto>> GetAllTribesAsync();

    Task<TribeDto?> GetTribeAsync(int id);
}
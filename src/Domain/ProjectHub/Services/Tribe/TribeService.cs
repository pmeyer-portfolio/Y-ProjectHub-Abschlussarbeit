namespace ProjectHub.Services.Tribe;

using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Abstractions.IMappers.Tribe;
using ProjectHub.Abstractions.IService.Tribe;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;

public class TribeService : ITribeService
{
    private readonly ITribeDtoMapper dtoMapper;
    private readonly IGenericRepository<Tribe> tribeRepository;

    public TribeService(IGenericRepository<Tribe> tribeRepository, ITribeDtoMapper dtoMapper)
    {
        this.tribeRepository = tribeRepository;
        this.dtoMapper = dtoMapper;
    }

    public async Task<IList<TribeDto>> GetAllTribesAsync()
    {
        IList<Tribe> tribes = await this.tribeRepository.GetAllAsync();
        return this.dtoMapper.Map(tribes);
    }

    public async Task<TribeDto?> GetTribeAsync(int id)
    {
        Tribe? tribe = await this.tribeRepository.GetByIdAsync(id);
        return tribe != null
            ? this.dtoMapper.Map(tribe)
            : null;
    }
}
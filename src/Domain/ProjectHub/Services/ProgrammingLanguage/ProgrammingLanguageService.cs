namespace ProjectHub.Services.ProgrammingLanguage;

using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Abstractions.IMappers.ProgrammingLanguages;
using ProjectHub.Abstractions.IService.ProgrammingLanguage;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;

public class ProgrammingLanguageService : IProgrammingLanguageService
{
    private readonly IGenericRepository<ProgrammingLanguage> programmingLanguageRepository;
    private readonly IProgrammingLanguagesDtoMapper          programmingLanguagesDtoMapper;

    public ProgrammingLanguageService(IGenericRepository<ProgrammingLanguage> genericRepository,
                                      IProgrammingLanguagesDtoMapper          programmingLanguagesDtoMapper)
    {
        this.programmingLanguageRepository = genericRepository;
        this.programmingLanguagesDtoMapper = programmingLanguagesDtoMapper;
    }

    public async Task<IList<ProgrammingLanguageDto>> GetAllAsync()
    {
        IList<ProgrammingLanguage> languages = await this.programmingLanguageRepository.GetAllAsync();
        return this.programmingLanguagesDtoMapper.Map(languages);
    }

    public async Task<ProgrammingLanguageDto?> GetByIdAsync(int id)
    {
        ProgrammingLanguage? language = await this.programmingLanguageRepository.GetByIdAsync(id);
        return language != null
            ? this.programmingLanguagesDtoMapper.Map(language)
            : null;
    }
}
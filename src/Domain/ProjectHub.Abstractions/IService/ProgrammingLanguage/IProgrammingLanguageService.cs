namespace ProjectHub.Abstractions.IService.ProgrammingLanguage;

using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;

public interface IProgrammingLanguageService
{
    Task<ProgrammingLanguageDto?> GetByIdAsync(int id);

    Task<IList<ProgrammingLanguageDto>> GetAllAsync();
}
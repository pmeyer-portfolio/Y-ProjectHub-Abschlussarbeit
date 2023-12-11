namespace ProjectHub.Abstractions.IMappers.ProgrammingLanguages;

using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Data.Abstractions.Entities;

public interface IProgrammingLanguagesDtoMapper
{
    ProgrammingLanguageDto Map(ProgrammingLanguage programmingLanguage);
    IList<ProgrammingLanguageDto> Map(IList<ProgrammingLanguage> programmingLanguages);
}
namespace ProjectHub.Mappers.ProgrammingLanguages;

using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Abstractions.IMappers.ProgrammingLanguages;
using ProjectHub.Data.Abstractions.Entities;

public class ProgrammingLanguagesDtoMapper : IProgrammingLanguagesDtoMapper
{
    public ProgrammingLanguageDto Map(ProgrammingLanguage programmingLanguage)
    {
        ProgrammingLanguageDto dto = new()
        {
            Id   = programmingLanguage.Id,
            Name = programmingLanguage.Name
        };
        return dto;
    }

    public IList<ProgrammingLanguageDto> Map(IList<ProgrammingLanguage> programmingLanguages)
    {
        return programmingLanguages.Select(this.Map).ToList();
    }
}
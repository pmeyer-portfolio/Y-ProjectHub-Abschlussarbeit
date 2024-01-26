namespace ProjectHub.Blazor.Mappers.ProgrammingLanguage;

using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Services.Base;

public class ProgrammingLanguageViewModelMapper : IProgrammingLanguageViewModelMapper
{
    public ProgrammingLanguageViewModel Map(ProgrammingLanguageDto programmingLanguageDto)
    {
        return new ProgrammingLanguageViewModel
        {
            Id = programmingLanguageDto.Id,
            Name = programmingLanguageDto.Name,
        };
    }

    public IList<ProgrammingLanguageViewModel> Map(IList<ProgrammingLanguageDto> programmingLanguageDtos)
    {
        return programmingLanguageDtos.Select(this.Map).ToList();
    }
}
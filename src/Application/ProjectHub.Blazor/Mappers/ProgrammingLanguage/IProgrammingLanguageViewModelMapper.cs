namespace ProjectHub.Blazor.Mappers.ProgrammingLanguage;

using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Services.Base;

public interface IProgrammingLanguageViewModelMapper
{
    ProgrammingLanguageViewModel Map(ProgrammingLanguageDto programmingLanguageDto);
    IList<ProgrammingLanguageViewModel> Map(IList<ProgrammingLanguageDto> programmingLanguageDtos);
}
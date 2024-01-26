namespace ProjectHub.Blazor.Services.ProgrammingLanguage;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Services.Base;

public interface IProgrammingLanguageService
{
    Task<Response<IList<ProgrammingLanguageViewModel>>> GetAll();
}
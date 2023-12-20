namespace ProjectHub.Blazor.Services.Contracts;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public interface IProgrammingLanguageService
{
    Task<Response<IList<ProgrammingLanguageDto>>> GetAll();
}
namespace ProjectHub.Blazor.Services.Contracts;

using ProjectHub.Blazor.Services.Base;

public interface IProgrammingLanguageService
{
    Task<Response<IList<ProgrammingLanguageViewDto>>> GetAll();
}
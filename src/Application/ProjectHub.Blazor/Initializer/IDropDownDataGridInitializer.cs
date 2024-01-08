namespace ProjectHub.Blazor.Initializer;

using ProjectHub.Blazor.Services.Base;

public interface IDropDownDataGridInitializer
{
    Task<IList<TribeDto>> InitializeTribes();
    Task<IList<ProgrammingLanguageDto>> InitializeProgrammingLanguages();
}